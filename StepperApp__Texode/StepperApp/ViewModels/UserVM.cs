using StepperApp.DAL;
using StepperApp.Models;
using System;

namespace StepperApp.ViewModels
{
    internal class UserVM : Notifier, IUserVM
    {
        private string _fullName;
        private int _averageSteps;
        private int _minSteps;
        private int _maxSteps;
        private Status _estimateStatus;


        public Guid Id { get; set; }

        public string FullName
        {
            get => _fullName;
            set { _fullName = value;
                NotifyPropertyChanged("FullName");
            }
        }

        public int Average
        {
            get => _averageSteps;
            set
            {
                _averageSteps = value;
                NotifyPropertyChanged("Average");
            }
        }

        public int Min
        {
            get => _minSteps;
            set
            {
                _minSteps = value;
                NotifyPropertyChanged("Min");
            }
        }

        public int Max
        {
            get => _maxSteps;
            set
            {
                _maxSteps = value;
                NotifyPropertyChanged("Max");
            }
        }

        public Status EstimateStatus
        {
            get => _estimateStatus;
            set
            {
                _estimateStatus = value;
                NotifyPropertyChanged("EstimateStatus");
            }
        }


        //ctors
        public UserVM() { }

        public UserVM(IUser user)
        {
            if (user == null) return;
            FullName = user.FullName;
            Update(user);
        }


        public void Update(IUser user)
        {
            FullName = user.FullName;
            Average = user.Average;
            Min = user.Min;
            Max = user.Max;
        }

        public void Save(IUser user)
        {
            FullName = user.FullName;
            Average = user.Average;
            Min = user.Min;
            Max = user.Max;
        }

        private void UpEstimateStatus()
        {
            if (Min <= 0)
                EstimateStatus = Status.None;
            else if (Max > 1.3 * Average
                || Min < 0.7 * Average)
                EstimateStatus = Status.Bad;
            else
                EstimateStatus = Status.Good;
        }
    }
}
