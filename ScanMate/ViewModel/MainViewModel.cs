using ScanMate.View;

namespace ScanMate.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    public string userName;
    [ObservableProperty] 
    public string password;

    [ObservableProperty]
    public bool loggedIn;

    UserManagementService MyDBService;
    public ObservableCollection<User> MyShownList { get; set; } = new();

    public MainViewModel()
    {
        this.MyDBService = new();
        MyDBService.ConfigTools();
    }

    [RelayCommand]
    public async Task GoToHomePage()
    {

        await MyDBService.ReadUserTable();
        await MyDBService.ReadAccessTable();
        await MoveIntoList();

        foreach (var user in MyShownList)
        {

            if (UserName == user.UserName && Password == user.UserPassword)
            {
                loggedIn = true;
                await Shell.Current.GoToAsync(nameof(HomePage), true);
                return; 
            }
        }
        if (loggedIn == false)
        {
            await Shell.Current.DisplayAlert("Database", "Utilisateur non trouvé", "OK");
        }

    }

    internal async Task MoveIntoList()
    {
        List<User> MyList = new();

        try
        {
            MyList = Globals.UserSet.Tables["Users"].AsEnumerable().Select(m => new User()
            {
                User_ID = m.Field<Int16>("User_ID"),
                UserName = m.Field<string>("UserName"),
                UserPassword = m.Field<string>("UserPassword"),
                UserAccessType = m.Field<Int16>("UserAccessType"),
            }).ToList();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        MyShownList.Clear();

        foreach (User item in MyList)
        {
            MyShownList.Add(item);
        }
    }

    [RelayCommand]
    public async Task GoToRegisterPage()
    {
        IsBusy = true;

        try
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation", ex.Message, "OK");
        }

        IsBusy = false;
    }

}
