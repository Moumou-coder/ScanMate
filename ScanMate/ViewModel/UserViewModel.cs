﻿using ScanMate.Services;

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
    internal async Task FillAccessTable()
    {
        IsBusy = true;

        Globals.UserSet.Tables["Users"].Clear();
        Globals.UserSet.Tables["Access"].Clear();

        try
        {
            await MyDBService.ReadAccessTable();
            await MyDBService.ReadUserTable();

            await MyDBService.FillUser();
            await MoveIntoList();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }

        IsBusy = false;
    }

    [RelayCommand]
    internal async Task FillUserTable()
    {
        IsBusy = true;

        Globals.UserSet.Tables["Users"].Clear();
        Globals.UserSet.Tables["Access"].Clear();

        await MyDBService.FillUser();

        await MoveIntoList();

        IsBusy = false;
    }

    [RelayCommand]
    internal async Task UpdateTable()
    {
        IsBusy = true;

        DataRow User1 = Globals.UserSet.Tables["Users"].NewRow();
        User1[1] = "aaeztza";
        User1[2] = "aaa";
        User1[3] = 1;

        DataRow User2 = Globals.UserSet.Tables["Users"].NewRow();
        User2[1] = "bbgsdgs";
        User2[2] = "bbb";
        User2[3] = 2;

        Globals.UserSet.Tables["Users"].Rows.Add(User1);
        Globals.UserSet.Tables["Users"].Rows.Add(User2);

        await MyDBService.UpdateUser();

        await MoveIntoList();

        IsBusy = false;
    }

    [RelayCommand]
    internal async Task InsertDB()
    {
        IsBusy = true;
        await MyDBService.InsertUser("Fred", "abab", 1);
        await MoveIntoList();
        IsBusy = false;
    }
    [RelayCommand]
    internal async Task DeleteDB()
    {
        IsBusy = true;
        await MyDBService.DeleteUser("Fred");
        await MoveIntoList();
        IsBusy = false;
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