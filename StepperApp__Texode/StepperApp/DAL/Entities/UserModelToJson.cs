using System;
using System.Collections.Generic;


namespace StepperApp.DAL.Entities
{
    public class UserModelToJson
    {
        public string FullName { get; set; }
        public int AverageSteps { get; set; }
        public int MaxSteps { get; set; }
        public int MinSteps { get; set; }

        public List<UserModelWithoutName> UsersModelWithoutName { get; set; }
    }
}
