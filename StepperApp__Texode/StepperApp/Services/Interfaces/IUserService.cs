using StepperApp.DAL;
using StepperApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepperApp.Services.Interfaces
{
    internal interface IUserService
    {
        List<string> GetAllNames(Dictionary<string, List<int>> users);
        User GetUserByName(Dictionary<string, List<int>> users, string name);
        List<int> UserStepsByName(Dictionary<string, List<int>> users, string name);
        string WriteToJson(Dictionary<string, List<int>> users, User user);
    }
}
