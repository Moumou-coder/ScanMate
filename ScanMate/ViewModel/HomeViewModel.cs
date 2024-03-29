﻿using System.Linq.Expressions;

namespace ScanMate.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    BarCodeService MyBarCodeService;

    [ObservableProperty]
    string myTitle = "League Of Legend V2.0";
    [ObservableProperty]
    string myID = "48684";
    [ObservableProperty]
    string userName = "Unknown";
    [ObservableProperty]
    string totalChampions = "0";
    [ObservableProperty]
    string position = "?";
    [ObservableProperty]
    string rankImage = "lol.png";
    [ObservableProperty]
    string tier = "?";

    ProfilService profilService;
    public MainViewModel mainViewModel;
    ObservableCollection<Profil> myProfilList { get; set; } = new();

    public HomeViewModel(MainViewModel mainViewModel)
    {
        profilService = new ProfilService();
        this.mainViewModel = mainViewModel;
    }

    [RelayCommand]
    public async Task Scanner()
    {
        IsBusy = true;
        InitBarCodeService();

        try
        {
            Globals.StaticListProfil = await profilService.GetProfilData();
            foreach (Profil profil in Globals.StaticListProfil) { myProfilList.Add(profil); }
            // Find the matching profile based on MyID
            Profil matchingProfile = myProfilList.FirstOrDefault(profile => profile.Profil_ID == MyID);

            if (matchingProfile != null)
            {
                // Fetch the attributes from the matching profile
                UserName = matchingProfile.UserName;
                TotalChampions = matchingProfile.ChampionsAmount;
                Tier = matchingProfile.TierList;
                Position = matchingProfile.Position;
                RankImage = matchingProfile.Rank;

                //await Shell.Current.DisplayAlert("Profil", "trouv� ", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Profil", "user not founded ", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Scanner : ", ex.Message, "OK");
        }

        IsBusy = false;
    }

    internal void InitBarCodeService()
    {
        this.MyBarCodeService = new BarCodeService();
        MyBarCodeService.ConfigureScanner();
        MyBarCodeService.SerialBuffer.Changed += SerialBuffer_Changed;
    }

    private void SerialBuffer_Changed(object sender, EventArgs e)
    {
        BarCodeService.QueueBuffer myQueue = (BarCodeService.QueueBuffer)sender;
        MyID = myQueue.Dequeue().ToString(); //ActiveTarget
    }

    [RelayCommand]
    public async Task GoToChampionsPage()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(ChampionsPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation : ", ex.Message, "OK");
        }
    }

    [RelayCommand]
    public async Task GoToRegisterPage()
    {
        if (mainViewModel.UserAccess == 1)
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(RegisterPage));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Navigation : ", ex.Message, "OK");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Attention : ", "Vous n'avez pas les droits de créer un utilisateur", "OK");
        }
       
    }

    [RelayCommand]
    public async Task GoToUsersPage()
    {
        if (mainViewModel.UserAccess == 1)
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(UserPage));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Navigation : ", ex.Message, "OK");
            }
        }
            
    }

    [RelayCommand]
    public async Task GoToSkinsPage()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(SkinsPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation : ", ex.Message, "OK");
        }
    }

    //[RelayCommand]
    //public async Task GoToUserPage()
    //{
    //    await Shell.Current.GoToAsync(nameof(UserPage));
    //}
}