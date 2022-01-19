using StepperApp.DAL.Entities;
using System.Collections.Generic;


namespace StepperApp.Services.Interfaces
{
    internal interface IDataService
    {
        List<UserModelFromJson> GetData();
        Dictionary<string, List<int>> GetUsersDict(List<UserModelFromJson> users);
    }
}
