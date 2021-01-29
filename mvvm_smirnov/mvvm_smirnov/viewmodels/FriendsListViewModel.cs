using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using mvvm_smirnov;
using mvvm_smirnov.views;

namespace mvvm_smirnov.viewmodels
{
    public class FriendsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FriendViewModel> Friends { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateFriendCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        FriendViewModel selectedFriend;

        public INavigation Navigation { get; set; }

        public FriendsListViewModel()
        {
            Friends = new ObservableCollection<FriendViewModel>();
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }
        public FriendViewModel SelectedFriend
        {


            get => selectedFriend;
            set
            {
                if (selectedFriend != value)
                {
                    FriendViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }
        public void Back()
        {
            Navigation.PopAsync();
        }
        public void SaveFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null && friend.IsValid)
            {
                Friends.Add(friend);
            }
            Back();
        }
        public void DeleteFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null)
            {
                Friends.Remove(friend);
            }
            Back();
        }
    }
}
