

namespace ScanMate.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    public string userNameEntry;
    [ObservableProperty] 
    public string passwordEntry;

    UserManagementService MyDBService;
    public ObservableCollection<User> MyShownList { get; set; } = new();

    public MainViewModel()
    {
        this.MyDBService = new();
        MyDBService.ConfigTools();
    }

    public async Task ReadAccess()
    {
        try
        {
            await MyDBService.ReadAccessTable();
            await MyDBService.ReadUserTable();
        }
        catch (Exception ex)
        {
            // Handle the exception appropriately (e.g., log the error)
            Console.WriteLine($"Database error: {ex.Message}");
        }
    }

    public async Task RemplirDB()
    {
        IsBusy = true;

        List<User> usersTemp = new List<User>();

        MyShownList.Clear();

        try
        {
            usersTemp = Globals.UserSet.Tables["Users"].AsEnumerable().Select(m => new User()
            {
                User_ID = m.Field<Int16>("User_ID"),
                UserName = m.Field<string>("UserName"),
                UserPassword = m.Field<string>("UserPassword"),
                UserAccessType = m.Field<Int16>("UserAccessType"),
            }).ToList();
        }
        catch (Exception ex)
        {
            // Handle the exception appropriately (e.g., log the error)
            Console.WriteLine($"Database error: {ex.Message}");
        }

        foreach (var user in usersTemp)
        {
            MyShownList.Add(user);
        }

        IsBusy = false;
    }

    [RelayCommand]
    public async Task Connexion()
    {
        await ReadAccess();
        await RemplirDB();

        bool userFound = false;
        
        foreach (var user in MyShownList)
        {

            if (UserNameEntry == user.UserName && PasswordEntry == user.UserPassword)
            {
                userFound = true;
                Console.WriteLine("Successful login");
                await Shell.Current.GoToAsync(nameof(HomePage), true);
                break;
            }
            await Shell.Current.DisplayAlert("data", $"user-name : {user.UserName}", "OK");
        }

        if (!userFound)
        {
            await Shell.Current.DisplayAlert("Database", $"Utilisateur non trouvé", "OK");
        }
    }

    [RelayCommand]
    public async Task GoToHomePage()
    {
        IsBusy = true;

        Globals.UserSet.Tables["Users"].Clear();
        Globals.UserSet.Tables["Access"].Clear();

        try
        {
            //await MyDBService.ReadAccessTable();
            //await MyDBService.ReadUserTable();

            //await MyDBService.FillUser();
            //await MoveIntoList();

            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation", ex.Message, "OK");
        }
        
        IsBusy = false;
    }

    //internal async Task MoveIntoList()
    //{
    //    List<User> MyList = new();

    //    try
    //    {
    //        MyList = Globals.UserSet.Tables["Users"].AsEnumerable().Select(m => new User()
    //        {
    //            User_ID = m.Field<Int16>("User_ID"),
    //            UserName = m.Field<string>("UserName"),
    //            UserPassword = m.Field<string>("UserPassword"),
    //            UserAccessType = m.Field<Int16>("UserAccessType"),
    //        }).ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
    //    }
    //    MyShownList.Clear();

    //    foreach (User item in MyList)
    //    {
    //        MyShownList.Add(item);
    //    }
    //}

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
