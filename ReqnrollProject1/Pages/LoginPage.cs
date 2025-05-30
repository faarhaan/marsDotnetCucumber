using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mars.Pages
{
    public class LoginPage
    {
        // Below method performs the login actions to open the portal mar
        public void LoginActions(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(" http://localhost:5003");
            Thread.Sleep(4000);
           // Maximiize the window
            driver.Manage().Window.Maximize();
            Thread.Sleep(4000);
            // Identify Signin Button and click on it
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();
            Thread.Sleep(2000);                                    

            // Identify User name Text box and enter user
            IWebElement enterUserName = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            enterUserName.SendKeys("faarhaan786@gmail.com");

            // Identify password box and enter passwerd
            IWebElement enterPassword = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            enterPassword.SendKeys("Pakistan_123");

            // Identify Login Button and click on it 
            IWebElement clickOnLogin = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            clickOnLogin.Click();
            Thread.Sleep(3000);
            driver.Manage().Window.Maximize();


        }
    }
}
