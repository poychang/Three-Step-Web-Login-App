using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using ThreeStepWebLoginApp.Helpers;
using ThreeStepWebLoginApp.Models;

namespace ThreeStepWebLoginApp
{
    public class Startup : IDisposable
    {
        public AppSettingsModel Config { get; set; }
        public ChromeDriver Driver { get; set; }

        public Startup()
        {
            Config = AppSettingHelper.Fetch();
            Driver = InitChromeDriver();
        }

        private ChromeDriver InitChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            var arguments = Config.HideWindow
                ? /*隱藏 Chrome 視窗*/    "headless"
                : /*設定 Chrome 視窗大小*/ "--window-size=1024,800";
            chromeOptions.AddArgument(arguments);
            return new ChromeDriver("./", chromeOptions);
        }

        public void Login()
        {
            // 開啟網頁
            Driver.Url = Config.Url;
            // 動作
            Driver.FindElement(By.XPath(Config.StepXpath.Step1)).SendKeys(Config.LoginInfo.Account);
            Driver.FindElement(By.XPath(Config.StepXpath.Step2)).SendKeys(Config.LoginInfo.Password);
            Driver.FindElement(By.XPath(Config.StepXpath.Step3)).Click();
            Thread.Sleep(TimeSpan.FromSeconds(Config.DelayRedirect));
        }

        public bool Verify()
        {
            var verify = false;
            Driver.Url = "https://www.google.com";
            try
            {
                verify = !Driver.FindElement(By.Name("q")).Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(verify ? "Login Failed..." : "Login Success!!");
            return verify;
        }

        public void Close()
        {
            Thread.Sleep(TimeSpan.FromSeconds(Config.DelayClose));
        }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
