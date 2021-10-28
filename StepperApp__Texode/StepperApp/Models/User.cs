namespace StepperApp.Models
{
    internal class User
    {
        public string FullName { get; set; }
        public int AverageSteps { get; set; }
        public int MinSteps { get; set; }
        public int MaxSteps { get; set; }

        public override string ToString() => $"{FullName}";
    }
}
