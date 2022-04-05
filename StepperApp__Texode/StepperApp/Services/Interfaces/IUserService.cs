using StepperApp.DAL;
using System.Collections.Generic;

namespace StepperApp.Services.Interfaces
{
    internal interface IUserService
    {
        List<string> GetAllNames(Dictionary<string, List<int>> users);
        User GetUserByName(Dictionary<string, List<int>> users, string name);
        List<int> UserStepsByName(Dictionary<string, List<int>> users, string name);
        string WriteToJson(IDataService dataSvc, User user);
    }
}
