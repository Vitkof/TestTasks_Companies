using StepperApp.DAL;
using StepperApp.Infrastructure.Commands;
using StepperApp.Models;
using StepperApp.Services;
using StepperApp.Services.Interfaces;
using StepperApp.ViewModels.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace StepperApp.ViewModels
{
    internal class MainWindowVM : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IUserService _userService;
        private readonly IUsersModel _usersModel;

        internal List<User> UsersList { get; private set; }

        public UsersVM UsersVM { get; }

        //ctor
        public MainWindowVM(UsersVM usersVM)
        {
            UsersVM = usersVM;
        }
        public MainWindowVM()
        {
            _dataService = new DataService();
            _userService = new UserService();
            _usersModel = new UsersModel(_dataService, _userService);
            CloseApplicationCmd = new LambdaCommand(OnCloseApplicationCmdExecuted, CanCloseApplicationCmdExecute);
        }


        #region Title : string - Заголовок
        private string _title = "StepperApp";
        ///<summary>Заголовок окна<summary
        public string Title 
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region CurrentModel : Notifier - Текущая дочерняя модель-представления
        private Notifier _currentModel;
        /// <summary>Текущая дочерняя модель-представления</summary>
        public Notifier CurrentModel
        {
            get => _currentModel;
            private set => Set(ref _currentModel, value);
        }
        #endregion


        #region Command ShowUsersViewCommand - Отобразить представление пользователей

        private ICommand _showUsersViewCommand;

        /// <summary>Отобразить представление пользователей</summary>
        public ICommand ShowUsersViewCommand => _showUsersViewCommand
            ??= new LambdaCommand(OnShowUsersViewCommandExecuted, CanShowUsersViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление пользователей</summary>
        private bool CanShowUsersViewCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Отобразить представление пользователей</summary>
        private void OnShowUsersViewCommandExecuted(object p)
        {
            CurrentModel = new UsersVM(_usersModel);
        }
        #endregion

        #region Command ShowGroupsViewCommand - Отобразить представление групп

        private ICommand _showGroupsViewCommand;

        /// <summary>Отобразить представление групп</summary>
        public ICommand ShowGroupsViewCommand => _showGroupsViewCommand
            ??= new LambdaCommand(OnShowGroupsViewCommandExecuted, CanShowGroupsViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление групп</summary>
        private bool CanShowGroupsViewCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Отобразить представление групп</summary>
        private void OnShowGroupsViewCommandExecuted(object p)
        {
            CurrentModel = new GroupsVM();
        }
        #endregion

        #region Command CloseApplicationCmd - Закрыть приложение
        public ICommand CloseApplicationCmd { get; }
        private bool CanCloseApplicationCmdExecute(object p) => true;
        private void OnCloseApplicationCmdExecuted(object p)
        {
            //(RootObject as Window)?.Close();
            Application.Current.Shutdown();
        }
        #endregion
    }
}
