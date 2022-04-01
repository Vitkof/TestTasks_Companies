using StepperApp.DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace StepperApp.ViewModels
{
    internal interface IUsersVM : INotifyPropertyChanged
    {
        IUserVM SelectedUser { get; set; }
        ReadOnlyObservableCollection<User> Users { get; }

        void UpdateUser();
    }
}
