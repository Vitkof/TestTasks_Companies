using StepperApp.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepperApp.Models
{
    internal interface IUsersModel
    {
        ReadOnlyObservableCollection<User> Users { get; }
        ICollectionView UsersView { get; }
        string UsersFilter { get; set; }
        event EventHandler<UserEventArgs> UserUpdated;
        void UpdateUser(IUser user);
        void LoadData();
    }


    public class UserEventArgs : EventArgs
    {
        public IUser User { get; set; }
        //ctor
        public UserEventArgs(IUser user)
        {
            User = user;
        }
    }
}
