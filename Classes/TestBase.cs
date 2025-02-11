using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher_Game_Automation.Classes
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected GamePage gamePage;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();
            // Navigate to the game URL
            driver.Navigate().GoToUrl(TestData.GameUrl);
            // Initialize the GamePage
            gamePage = new GamePage(driver);
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and clean up
            driver.Quit();
            driver.Dispose();
        }
    }
}
