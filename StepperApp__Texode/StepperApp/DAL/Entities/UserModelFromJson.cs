using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StepperApp.DAL.Entities
{
    public class UserModelFromJson : UserModelWithoutName
    {
        public string User { get; set; }
    }
}
