using System;

namespace StepperApp.DAL
{
    public class User : IUser
    {
        public virtual Guid Id { get; set; }
        public string FullName { get; set; }
        public int Average { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void Update(IUser user)
        {
            FullName = user.FullName;
            Average = user.Average;
            Min = user.Min;
            Max = user.Max;
        }

        public override string ToString() => $"Пользователь {FullName}";
    }
}
