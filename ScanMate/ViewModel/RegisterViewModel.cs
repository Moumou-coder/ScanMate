namespace ScanMate.ViewModel;

public partial class RegisterViewModel : BaseViewModel
{

    [ObservableProperty]
    public string userNameRegist;
    [ObservableProperty] 
    public string passwordRegist;
    [ObservableProperty]
    public Int16 accesstype;

    [ObservableProperty]
    bool isNotBusy = true;

    

    UserManagementService MyDBService;

    public ObservableCollection<User> MyShownList { get; set; } = new();
    public RegisterViewModel()
    {
        this.MyDBService = new();
        MyDBService.ConfigTools();
    }

    [RelayCommand]
    public async Task GoToLoginPage()
    {
        IsBusy = true;

        try
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation", ex.Message, "OK");
        }
        
        IsBusy = false;
    }

    [RelayCommand]
    internal async Task InsertAndGoToLogin()
    {

        IsNotBusy = false;
        await MyDBService.InsertUser(UserNameRegist, PasswordRegist, Accesstype);
        await MoveIntoList();
        IsNotBusy = true;
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
}
