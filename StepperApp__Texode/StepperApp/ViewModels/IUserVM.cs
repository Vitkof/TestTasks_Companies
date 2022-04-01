using StepperApp.DAL;


namespace StepperApp.ViewModels
{
    internal interface IUserVM : IUser
    {
        Status EstimateStatus { get; set; }
    }
}
