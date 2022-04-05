using Newtonsoft.Json;
using StepperApp.DAL;
using StepperApp.DAL.Entities;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace StepperApp.Services
{
    internal class DataService : IDataService
    {
        private readonly string _dataSrcAdress = Environment.CurrentDirectory + @"\TestData\";
        private readonly List<UserModelFromJson> _userModels = new();

        public List<UserModelFromJson> GetData()
        {
            try
            {
                string[] namesFiles = Directory.GetFiles(_dataSrcAdress, "*.json");
                namesFiles.QuickSort(0, namesFiles.Length - 1);

                byte c = 1;
                for (byte i = 0; i < namesFiles.Length; i++, c++)
                {
                    var read = File.ReadAllText(namesFiles[i]);
                    var usersDay = JsonConvert.DeserializeObject<List<UserModelFromJson>>(read);

                    foreach (var userModelFromJson in usersDay)
                    {
                        userModelFromJson.Day = $"Day {c}";
                        _userModels.Add(userModelFromJson);
                    }
                }
                return _userModels;
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


        public string Serialize(User user)
        {
            try
            {
                var userDayList = _userModels
                    .Where(umfj => umfj.User.Equals(user.FullName))
                    .Select(u => new UserModelWithoutNameSteps()
                    {
                        Rank = u.Rank,
                        Day = u.Day,
                        Status = u.Status
                    })
                    .ToList();

                var userModelToJson = new UserModelToJson()
                {
                    FullName = user.FullName,
                    Average = user.Average,
                    Max = user.Max,
                    Min = user.Min,
                    Days = userDayList
                };
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var serialize = System.Text.Json.JsonSerializer.Serialize(userModelToJson, options);
                string path = Environment.CurrentDirectory + $"\\{user.FullName}.json";
                File.WriteAllText(path, serialize);
                return $"Successfully saved in {path}";
            }
            catch (Exception ex)
            {
                return $"An error occurred while saving: {ex.Message}";
            }
        }
    }
}
