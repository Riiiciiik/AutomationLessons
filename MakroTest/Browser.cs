using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MakroTest
{
    class Browser
    {
        public static IWebDriver Driver { get; set; }

        public static Actions Builder { get; set; }

        public static WebDriverWait Wait { get; set; }


        
        public static void CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(string.Format("user-data-dir={0}\\ChromeProfile", GetDriverFilePath()));
            options.AddLocalStatePreference("acceptSslCerts", true);
            
            Driver = new ChromeDriver(GetDriverFilePath(), options);
            Builder = new Actions(Driver);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));



        }

        internal static void Navigate()
        {
            Browser.Driver.Navigate().GoToUrl("https://www.makro.cz/");
        }

        public static string GetDriverFilePath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return path.Remove(path.LastIndexOf("bin")) + "Drivers";
        }
    }
}
