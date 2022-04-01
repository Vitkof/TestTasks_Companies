using StepperApp.Models;
using StepperApp.Infrastructure.Commands;
using System;
using StepperApp.DAL;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StepperApp.ViewModels
{
    internal class UsersVM : Notifier, IUsersVM
    {
        public const string SELECTED_USER_PROP_NAME
            = "SelectedUser";

        private readonly IUsersModel _model;
        private readonly ICommand _updateCmd;
        private readonly ICommand _loadDataCmd;
        private readonly ICommand _saveUserCmd;


        //ctor
        public UsersVM(IUsersModel model)
        {
            _model = model;
            _model.UserUpdated += model_UserUpdated;
            _updateCmd = new UpdateCmd(this);
            _loadDataCmd = new LoadDataCmd(this);
            _saveUserCmd = new SaveUserCmd(this);
        }

        //prop
        public ICommand UpdateCmd => _updateCmd;
        public ICommand LoadDataCmd => _loadDataCmd;
        public ICommand SaveCmd => _saveUserCmd;
        public ICollectionView UsersView => _model.UsersView;
        public ReadOnlyObservableCollection<User> Users => _model.Users;

        public string UsersFilter
        {
            get => _model.UsersFilter;
            set => _model.UsersFilter = value;
        }

        public CoordinateGridVM CoordinateGridVM { get; set; } =
            new CoordinateGridVM(new CoordinateGridModel());


        #region SelectedValue
        /// <summary>
        /// Свойство SelectedValue привязывается в представлении к номеру выбранного элемента в
        /// ComboBox, т.е. ComboBox.SelectedIndex. При этом в самом свойстве обновляется другое
        /// свойство SelectedProject и обновляется статус через свойство DetailsEstimateStatus.
        /// </summary>
        public string? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                User user = GetUser(value);

                if (SelectedUser == null)
                    SelectedUser = new UserVM(user);
                else
                    SelectedUser.Update(user);

                EstimateStatus =
                    SelectedUser.EstimateStatus;
                CoordinateGridVM.Data.FullName = value;
            }
        }
        #endregion

        #region SelectedUser : IUserVM - выбранный пользователь
        private IUserVM _selectedUser;
        public IUserVM SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (value == null)
                {
                    _selectedUser = value;
                    DetailsEnabled = false;
                }
                else
                {
                    if (_selectedUser == null)
                    {
                        _selectedUser = new UserVM(value);
                    }
                    _selectedUser.Update(value);
                    DetailsEnabled = true;
                    EstimateStatus = _selectedUser.EstimateStatus;
                    
                    NotifyPropertyChanged(SELECTED_USER_PROP_NAME);
                }
            }
        }
        #endregion

        #region DetailsEnabled : bool
        private bool _detailsEnabled;
        public bool DetailsEnabled
        {
            get => _detailsEnabled;
            set
            {
                _detailsEnabled = value;
                NotifyPropertyChanged("DetailsEnabled");
            }
        }
        #endregion

        #region EstimateStatus : Status
        private Status _estimateStatus = Status.None;

        internal Status EstimateStatus
        {
            get => _estimateStatus;
            set
            {
                _estimateStatus = value;
                NotifyPropertyChanged("EstimateStatus");
            }
        }
        #endregion


        private User GetUser(string userFName)
        {
            return (from u in Users
                    where u.FullName == userFName
                    select u).FirstOrDefault();
        }

        public void LoadData()
        {
            _model.LoadData();
        }

        public void UpdateUser()
        {
            EstimateStatus = SelectedUser.EstimateStatus;
            _model.UpdateUser(SelectedUser);
        }


        /// <summary>
        /// Обработчик событий, вызывающийся в ответ на событие
        /// IUsersModel.UserUpdated. Этот обработчик сначала обновляет 
        /// коллекцию Users, а затем будет изменять свойство SelectedUser, 
        /// если его FullName такое же, как и у обновленного пользователя
        /// </summary>
        public void model_UserUpdated(object sender,
                                    UserEventArgs e)
        {
            GetUser(e.User.FullName).Update(e.User);
            if(SelectedUser != null &&
                e.User.FullName == SelectedUser.FullName)
            {
                SelectedUser.Update(e.User);
                EstimateStatus =
                    SelectedUser.EstimateStatus;
            }
        }
    }
}

