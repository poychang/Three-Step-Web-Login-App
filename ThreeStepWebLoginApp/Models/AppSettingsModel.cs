namespace ThreeStepWebLoginApp.Models
{
    public class AppSettingsModel
    {
        public string Url { get; set; }
        public int DelayClose { get; set; }
        public int DelayRedirect { get; set; }
        public bool HideWindow { get; set; }
        public LoginInfo LoginInfo { get; set; }
        public StepXpath StepXpath { get; set; }
    }

    public class LoginInfo
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class StepXpath
    {
        public string Step1 { get; set; }
        public string Step2 { get; set; }
        public string Step3 { get; set; }
    }
}
