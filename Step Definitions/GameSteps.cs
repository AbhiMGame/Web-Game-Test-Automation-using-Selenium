using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher_Game_Automation.Classes
{
    [Binding]
    public class GameSteps
    {
        private IWebDriver driver;
        private GamePage gamePage;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TestData.GameUrl);
            gamePage = new GamePage(driver);
        }

        [AfterScenario]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Given(@"I open the game URL")]
        public void GivenIOpenTheGameURL()
        {
            // This step is already handled in the Setup method
            Console.WriteLine("Game URL opened successfully!");
        }

        [Then(@"the game page should load successfully")]
        public void ThenTheGamePageShouldLoadSuccessfully()
        {
            Assert.IsNotNull(driver.Title, "The page title should not be null.");
        }

        [When(@"I click the Play button")]
        public void WhenIClickThePlayButton()
        {
            gamePage.ClickPlayButton();
        }

        [Then(@"the overlay should be hidden")]
        public void ThenTheOverlayShouldBeHidden()
        {
            Assert.IsTrue(gamePage.IsOverlayHidden(), "Overlay is still visible after clicking Play.");
        }
    }
}
