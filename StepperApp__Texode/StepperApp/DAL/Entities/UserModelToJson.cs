using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StepperApp.DAL.Entities
{
    public class UserModelToJson : User
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        [JsonPropertyOrder(2)]
        public List<UserModelWithoutNameSteps> Days { get; set; }
    }
}
