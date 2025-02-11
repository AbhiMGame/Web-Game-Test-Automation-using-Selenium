using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher_Game_Automation.Classes
{
    [TestFixture]
    public class Tests : TestBase
    {
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
            // Click the Play button
            gamePage.ClickPlayButton();

            // Assert that the overlay is hidden
            Assert.IsTrue(gamePage.IsOverlayHidden(), "Overlay is still visible after clicking Play.");
        }
    }
}
