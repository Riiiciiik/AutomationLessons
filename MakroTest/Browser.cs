using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakroTest
{
    class Browser
    {
        public static IWebDriver Driver { get; set; }
        public static string path;


        
        public static void CreateDriver()
        {
            Driver = new ChromeDriver(GetDriverFilePath(path));

        }

        internal static void Navigate()
        {
            Browser.Driver.Navigate().GoToUrl("http://www.makro.cz");
        }

        public static string GetDriverFilePath(string path)
        {
            path = System.AppDomain.CurrentDomain.BaseDirectory;
            return path.Remove(path.LastIndexOf("bin")) + "Drivers";
        }
    }
}
