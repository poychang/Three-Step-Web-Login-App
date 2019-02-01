using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using ThreeStepWebLoginApp.Models;

namespace ThreeStepWebLoginApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Three Step Web Login App");
            Console.WriteLine("==============================");
            Run(ReadFromAppSettings().Get<AppSettingsModel>());
        }

        public static IConfigurationRoot ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
        }

        public static void Run(AppSettingsModel config)
        {
            var chromeOptions = new ChromeOptions();
            var arguments = config.HideWindow
                ? /*隱藏 Chrome 視窗*/    "headless"
                : /*設定 Chrome 視窗大小*/ "--window-size=1024,800";
            chromeOptions.AddArgument(arguments);

            using (var driver = new ChromeDriver("./", chromeOptions))
            {
                // 開啟網頁
                driver.Url = config.Url;
                // 動作
                driver.FindElement(By.XPath(config.StepXpath.Step1)).SendKeys(config.LoginInfo.Account);
                driver.FindElement(By.XPath(config.StepXpath.Step2)).SendKeys(config.LoginInfo.Password);
                driver.FindElement(By.XPath(config.StepXpath.Step3)).Click();
                Thread.Sleep(TimeSpan.FromSeconds(config.DelayClose));
            }
        }
    }
}
