namespace ScanMate.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public bool isBusy;
        public bool IsNotBusy => !IsBusy;

        public BaseViewModel() { }

        
    }
}
