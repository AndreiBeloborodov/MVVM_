using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using mvvm_smirnov.viewmodels;
using mvvm_smirnov.models;
using System;

namespace mvvm_smirnov.viewmodels
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FriendsListViewModel lvm;
        public Friend Friend { get; private set; }
        public FriendViewModel()
        {
            Friend = new Friend();
        }
        public FriendsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModle");
                }
            }
        }
        public string Name
        {
            get => Friend.Name;
            set
            {
                if (Friend.Name != value)
                {
                    Friend.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Email
        {
            get { return Friend.Email; }
            set
            {
                if (Friend.Email != value)
                {
                    Friend.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get => Friend.Phone;
            set
            {
                if (Friend.Phone == value)
                {
                    return;
                }
                Friend.Phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Email.Trim())) ||
                    (!string.IsNullOrEmpty(Phone.Trim())));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public static implicit operator FriendViewModel(FriendsListViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
