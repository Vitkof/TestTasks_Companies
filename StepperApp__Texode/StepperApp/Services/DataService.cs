using Newtonsoft.Json;
using StepperApp.DAL.Entities;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;


namespace StepperApp.Services
{
    internal class DataService : IDataService
    {
        private string _dataSrcAdress = Environment.CurrentDirectory + @"\TestData\";
        public List<UserModelFromJson> ListUsersFromFiles { get; set; }

        public List<UserModelFromJson> GetData()
        {
            try
            {
                var res = ListUsersFromFiles = new List<UserModelFromJson>();
                string[] namesFiles = Directory.GetFiles(_dataSrcAdress, "*.json");

                for (byte i = 0; i < namesFiles.Length;)
                {
                    var read = File.ReadAllText(namesFiles[i]);
                    res = JsonConvert.DeserializeObject<List<UserModelFromJson>>(read);

                    foreach (var userModelFromJson in res)
                    {
                        userModelFromJson.Day = $"Day {++i}";
                    }
                }
                return res;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public Dictionary<string, List<int>> GetUsersDict(List<UserModelFromJson> users)
        {
            var res = new Dictionary<string, List<int>>();

            foreach(var user in users)
            {
                string name = user.User;

                if (!res.ContainsKey(name))
                {
                    res[name] = new List<int> { user.Steps };
                }
                else
                {
                    res[name].Add(user.Steps);
                }
            }
            return res;
        }
    }
}
