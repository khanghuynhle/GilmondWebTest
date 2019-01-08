using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace GilmondWebTest
{
    [TestFixture()]
    public class VisitContactPage
    {
        //static ChromeOptions chromeOptions = new ChromeOptions();
        //static ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
        static ChromeDriver driver = new ChromeDriver();
        static WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        [SetUp]
        public void SetUpTest()
        {
            /**
            var  chromeOptions = new ChromeOptions();
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeOptions.AddArguments(new List<string>() {
                 "--silent-launch",
                "--no-startup-window",
                "no-sandbox",
                "headless",});
  
            chromeDriverService.HideCommandPromptWindow = true;    
            // This is to hidden the console.
            var driver = new ChromeDriver(chromeDriverService, chromeOptions);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver = new ChromeDriver(chromeDriverService, chromeOptions);
            **/

            //maximising the browser for more accurate at finding elements.
            driver.Manage().Window.Maximize();
            String url = "http://www.gilmond.com";
            driver.Navigate().GoToUrl(url);
            //wait for the patge is fully loaded
            var clickableElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("GilmondLogo")));
            
        }

        [Test]
        public void FillingFormToContact()
        {
            
            // 2. As 'button' is unique. find the element and click to show navigation menu
            var button = driver.FindElementByTagName("button");
            
            // 3. Click and continue to find XPath to 'Contact' page
            button.Click();
            var clickContact = driver.FindElement(by: By.XPath("//a[contains(text(),'Contact')]"));
            clickContact = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Contact')]")));
            clickContact.Click();
            
            //Filling Form Process
            var filling = driver.FindElement(By.XPath("//input[@placeholder='Name']"));
            filling.SendKeys("Khang Le");

            filling = driver.FindElement(By.XPath("//input[@placeholder='Email']"));
            filling.SendKeys("s4830295@bournemouth.ac.uk");

            filling = driver.FindElement(By.XPath("//textarea[@placeholder='Comment']"));
            filling.SendKeys("This is a test for checking the accessible of elements in the website");

        }
        [Test]
        public void BlogPage()
        {
            var button = driver.FindElementByTagName("button");
            button.Click();
            var clickBlog = driver.FindElement(by: By.XPath("//a[contains(text(),'Blog')]"));
            clickBlog = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Blog')]")));
            clickBlog.Click();
            var homePage = driver.FindElement(By.XPath("//a[@class='navbar-brand']"));
            homePage.Click();
            String title = driver.Title;
            if (title != "Home | Gilmond - Energy Supplier Services")
            {
               throw new Exception("Relative Link Error");

            }


        
        }


        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
        }



    }
}
