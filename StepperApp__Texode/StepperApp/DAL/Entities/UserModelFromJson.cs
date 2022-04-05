namespace StepperApp.DAL.Entities
{
    public class UserModelFromJson : UserModelWithoutNameSteps
    {
        public string User { get; set; }
        public int Steps { get; set; }
    }
}
