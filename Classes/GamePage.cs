using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher_Game_Automation.Classes
{
    public class GamePage : BasePage
    {
        // Locators for elements on the game page
        private By PlayButtonLocator => By.Id("startButton");
        private By OverlayLocator => By.Id("overlay");

        public GamePage(IWebDriver driver) : base(driver)
        {
        }

        // Method to click the Play button
        public void ClickPlayButton()
        {
            ClickElement(PlayButtonLocator);
            Console.WriteLine("Play button clicked successfully!");
        }

        // Method to check if the overlay is hidden
        public bool IsOverlayHidden()
        {
            return !IsElementDisplayed(OverlayLocator);
        }
    }
}
