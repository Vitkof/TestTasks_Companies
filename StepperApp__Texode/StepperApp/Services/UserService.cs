using StepperApp.DAL;
using StepperApp.DAL.Entities;
using StepperApp.Models;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            var listSteps = users.FirstOrDefault(pair => pair.Key.Equals(fname)).Value;
            var user = new User()
            {
                FullName = fname,
                Average = Convert.ToInt32(listSteps.Average()),
                Min = MinValueFromUser(listSteps),
                Max = MaxValueFromUser(listSteps)
            };
            return user;
        }


        public List<int> UserStepsByName(Dictionary<string, List<int>> users, string name)
        {
            var listSteps = users.FirstOrDefault(pair => pair.Key.Equals(name)).Value;
            return listSteps;
        }


        public string WriteToJson(Dictionary<string, List<int>> users, User user)
        {
            var serialize = new JsonSerialize();
            var result = serialize.Serialize(users, user);
            return result;
        }


        private int MinValueFromUser(List<int> steps)
        {
            return steps.Min();
        }


        private int MaxValueFromUser(List<int> steps)
        {
            return steps.Max();
        }
    }
}
