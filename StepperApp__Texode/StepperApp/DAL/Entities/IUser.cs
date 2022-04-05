using StepperApp.DAL.Entities;

namespace StepperApp.DAL
{
    public interface IUser : IBaseEntity
    {
        string FullName { get; set; }
        int Average { get; set; }
        int Min { get; set; }
        int Max { get; set; }
        void Update(IUser user);
    }
}
