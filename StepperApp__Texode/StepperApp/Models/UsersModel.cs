using StepperApp.DAL;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace StepperApp.Models
{
    public class UsersModel : Notifier, IUsersModel
    {
        private ObservableCollection<User> _users = new();
        private ReadOnlyObservableCollection<User> _readUsers;
        private CollectionViewSource _usersViewSource;

        public event EventHandler<UserEventArgs> UserUpdated = delegate { };


        //ctor
        internal UsersModel(IDataService dataSvc,
                            IUserService userSvc)
        {
            _readUsers = new ReadOnlyObservableCollection<User>(_users);

            var getAllUsersFromFiles = dataSvc.GetData();
            if (getAllUsersFromFiles != null)
            {
                var UsersDictionary = dataSvc.GetUsersDict(getAllUsersFromFiles);
                var getAllUsersNames = userSvc.GetAllNames(UsersDictionary);
                foreach (string name in getAllUsersNames)
                {
                    _users.Add(userSvc.GetUserByName(UsersDictionary, name));
                }
            }
        }


        #region Users : ReadOnlyObservableCollection<User> - коллекция пользователей
        public ReadOnlyObservableCollection<User> Users
        {
            get => _readUsers;
            set
            {
                if (Set(ref _readUsers, value))
                {
                    _usersViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions = {
                            new SortDescription(nameof(User.FullName),
                                                ListSortDirection.Ascending)
                        }
                    };

                    _usersViewSource.Filter += OnUsersFilter;
                    _usersViewSource.View.Refresh();
                    OnPropertyChanged(nameof(UsersView));
                }
            }
        }
        #endregion

        public ICollectionView UsersView => _usersViewSource?.View;

        #region UsersFilter : string - искомый пользователь
        private string _usersFilter;
        public string UsersFilter
        {
            get => _usersFilter;
            set
            {
                if (Set(ref _usersFilter, value))
                    _usersViewSource.View.Refresh();
            }
        }
        private void OnUsersFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not User user || string.IsNullOrEmpty(UsersFilter))
                return;

            if (!user.FullName.Contains(UsersFilter))
                e.Accepted = false;
        }
        #endregion


        public void UpdateUser(IUser user)
        {
            GetUserByName(user.FullName).Update(user);
            UserUpdated(this,
                new UserEventArgs(user));
        }

        private User GetUserByName(string fname)
        {
            return Users.FirstOrDefault(
                u => u.FullName == fname);
        }
    }
}
