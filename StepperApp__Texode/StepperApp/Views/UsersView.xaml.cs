using StepperApp.Models;
using StepperApp.Services;
using StepperApp.ViewModels;
using System.Windows.Controls;

namespace StepperApp.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private readonly IUsersModel _usersModel;

        public UsersView()
        {
            InitializeComponent();
            _usersModel = new UsersModel(new DataService(), new UserService());
            DataContext = new UsersVM(_usersModel);
        }
    }
}
