using StepperApp.DAL;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StepperApp.Services
{
    class UserService : IUserService
    {
        public List<string> GetAllNames(Dictionary<string, List<int>> users)
        {
            var userNames = users.Keys.ToList();
            return userNames;
        }

        public User GetUserByName(Dictionary<string, List<int>> users, string fname)
        {
            var listSteps = users.FirstOrDefault(pair => pair.Key.Equals(fname, StringComparison.Ordinal)).Value;
            var user = new User()
            {
                FullName = fname,
                Average = AverageValue(listSteps),
                Min = MinValueFromUser(listSteps),
                Max = MaxValueFromUser(listSteps)
            };
            return user;
        }

        public List<int> UserStepsByName(Dictionary<string, List<int>> users, string name)
        {
            var listSteps = users.FirstOrDefault(pair => pair.Key.Equals(name, StringComparison.Ordinal)).Value;
            return listSteps;
        }

        public string WriteToJson(IDataService dataSvc, User user)
        {
            var serialize = dataSvc;
            var res = serialize.Serialize(user);
            return res;
        }

        #region private
        private static int AverageValue(List<int> steps)
        {
            return Convert.ToInt32(steps.Average());
        }
        private static int MinValueFromUser(List<int> steps)
        {
            return steps.Min();
        }

        private static int MaxValueFromUser(List<int> steps)
        {
            return steps.Max();
        }
        #endregion
    }
}
