namespace ScanMate.ViewModel;

public partial class UserViewModel : BaseViewModel
{

    UserManagementService MyDBService;

    public ObservableCollection<User> MyShownList { get; set; } = new();

    public UserViewModel()
    {
        this.MyDBService = new();
        MyDBService.ConfigTools();
    }


    [RelayCommand]
    internal async Task FillUserTable()
    {
        IsBusy = true;

        Globals.UserSet.Tables["Access"].Clear();
        Globals.UserSet.Tables["Users"].Clear();

        await MyDBService.ReadAccessTable();
        await MyDBService.FillUser();
        await MoveIntoList();

        IsBusy = false;
    }

    [RelayCommand]
    internal async Task DeleteUser(User user)
    {
        try
        {
            await MyDBService.DeleteUser(user.UserName);
            await MoveIntoList();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Delete User", ex.Message, "OK");
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


}