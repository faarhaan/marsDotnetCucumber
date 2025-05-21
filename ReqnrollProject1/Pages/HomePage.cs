using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mars.Pages
{
    public class HomePage
    {
        // verify user is login successfully
        public void UserIsInHomePage(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement MarsLogo = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/a"));


            Assert.That(MarsLogo.Text == "Mars Logo", "user is not login successfully");


            /*if (MarsLogo.Text == "Mars Logo")
            {
                Assert.Pass("User Login Successfully! Test is Passed");
            }
            else
            {
                Assert.Fail("User didn't Login! Test Failed");
            }
*/
        }
    }

}