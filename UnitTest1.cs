using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Catcher_Game_Automation
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        // Define your game URL (adjust the path as needed)
        private readonly string gameUrl = "file:///C:/Users/lenovo/Desktop/HTML5%20quiz%20game/ladoo%20catcher/index.html";

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver before each test
            driver = new ChromeDriver();
            // Navigate to the game URL in the setup so every test starts on the game page
            driver.Navigate().GoToUrl(gameUrl);
        }

        [Test]
        public void OpenGameUrl()
        {
            // Confirm that the page title is not null
            Console.WriteLine("Game opened successfully!");
            Assert.IsNotNull(driver.Title, "The page title should not be null.");

            // Wait for 5 seconds to observe the page (for debugging)
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void TestGameStart()
        {
            // Create a WebDriverWait instance to wait for elements and conditions
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait until the Play Now button (startButton) is clickable
            IWebElement playButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("startButton")));

            // Click the Play Now button
            playButton.Click();
            Console.WriteLine("Play button clicked successfully!");

            // Wait until the overlay element's display style becomes "none"
            bool overlayIsHidden = wait.Until(driver =>
            {
                try
                {
                    IWebElement overlay = driver.FindElement(By.Id("overlay"));
                    // The element is considered hidden if .Displayed is false.
                    return !overlay.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // If the overlay is not found, we can consider it hidden.
                    return true;
                }
            });

            // Now assert that the overlay is hidden
            IWebElement overlayElement = driver.FindElement(By.Id("overlay"));
            Assert.IsFalse(overlayElement.Displayed, "Overlay is still visible after clicking Play.");
        }

        [TearDown]
        public void Teardown()
        {
             //Close the browser after each test
           driver.Quit();
           driver.Dispose();
        }
    }
}
