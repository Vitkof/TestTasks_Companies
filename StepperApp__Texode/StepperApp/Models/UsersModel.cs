using StepperApp.DAL;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepperApp.Models
{
    public class UsersModel : IUsersModel
    {
        private readonly ObservableCollection<User> _users = new ObservableCollection<User>();
        public ReadOnlyCollection<User> Users { get; set; }
        public event EventHandler<UserEventArgs> UserUpdated = delegate { };

        //ctor
        internal UsersModel(IDataService dataSvc,
                            IUserService userSvc)
        {
            Users = new ReadOnlyCollection<User>(_users);
            var getAllUsersFromFiles = dataSvc.GetData();
            if (getAllUsersFromFiles != null)
            {
                var UsersDictionary = dataSvc.GetUsersDict(getAllUsersFromFiles);
                var getAllUsersNames = userSvc.GetAllNames(UsersDictionary);
                foreach (var name in getAllUsersNames)
                {
                    _users.Add(userSvc.GetUserByName(UsersDictionary, name));
                }
            }
        }


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
