using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace Automation
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void CheckLoginSuccessfulTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("aman@gmail.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("aaa");
            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
            string currentURL = driver.Url;
            Assert.AreEqual(currentURL, "http://localhost:50746/Employee/Remarks.aspx");
        }

        [TestMethod]
        public void CheckLoginFailTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("aman@gmail.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("aman1");
            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
            string currentURL = driver.Url;
            Assert.AreEqual(currentURL, "http://localhost:50746/Account/Login.aspx");
        }
        [TestMethod]
        public void CheckAddRemarkTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("dhruvas@tavisca.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("d");
            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
          
            var continents = driver.FindElement(By.Id("MainContent_DropDownList1"));

            var selectIndex = new SelectElement(continents);

            selectIndex.SelectByIndex(6);
            driver.FindElement(By.Id("MainContent_TextBox1")).SendKeys("d");
            driver.FindElement(By.Id("MainContent_Button1")).Click();
            string label = driver.FindElement(By.Id("MainContent_Label2")).Text;
            Assert.AreEqual(label, "Successfull!!");
        }
 
        [TestMethod]
        public void CheckEmployeeCreatedTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("dhruvas@tavisca.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("d");

            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
            driver.FindElement(By.Id("AddEmployee")).Click();
            driver.FindElement(By.Id("TextBox1")).SendKeys("akash");
            driver.FindElement(By.Id("TextBox2")).SendKeys("Hero");

            driver.FindElement(By.Id("MainContent_EmpTitle")).SendKeys("Employee");
            driver.FindElement(By.Id("MainContent_Email")).SendKeys("Hero@gmail.com");
            driver.FindElement(By.Id("MainContent_Phone")).SendKeys("847585968");
   
            driver.FindElement(By.Name("ctl00$MainContent$Submit")).Click();
            string message = driver.FindElement(By.Id("MainContent_Label6")).Text;
            Assert.AreEqual(message, "Ok");
        }


        [TestMethod]
        public void CheckPasswordChangeSuccessfulTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("aman@gmail.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("aaa");
            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_Button1")).Click();

            driver.FindElement(By.Id("FeaturedContent_TextBox2")).SendKeys("aaa");
            driver.FindElement(By.Id("FeaturedContent_TextBox3")).SendKeys("aaa");
            driver.FindElement(By.Id("FeaturedContent_TextBox4")).SendKeys("aaa");

            driver.FindElement(By.Name("ctl00$FeaturedContent$Button1")).Click();

            string message = driver.FindElement(By.Id("FeaturedContent_Label5")).Text;

            Assert.AreEqual(message, "Success!!");
        }

        [TestMethod]
        public void CheckPasswordChangeUnSuccessfulTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("aman@gmail.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("aaa");
            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_Button1")).Click();

            driver.FindElement(By.Id("FeaturedContent_TextBox2")).SendKeys("no");
            driver.FindElement(By.Id("FeaturedContent_TextBox3")).SendKeys("aaa");
            driver.FindElement(By.Id("FeaturedContent_TextBox4")).SendKeys("aaa");

            driver.FindElement(By.Name("ctl00$FeaturedContent$Button1")).Click();

            string message = driver.FindElement(By.Id("FeaturedContent_Label5")).Text;

            Assert.AreEqual(message, "Failure!!");
        }
        [TestMethod]
        public void CheckPasswordChangeUnSuccessfulTest2()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:50746/Account/Login.aspx");
            driver.FindElement(By.Id("MainContent_Login1_TextBox1")).SendKeys("aman@gmail.com");
            driver.FindElement(By.Id("MainContent_Login1_TextBox2")).SendKeys("aaa");
            driver.FindElement(By.Id("MainContent_Login1_Button1")).Click();
            driver.FindElement(By.Id("FeaturedContent_Button1")).Click();

            driver.FindElement(By.Id("FeaturedContent_TextBox2")).SendKeys("aaa");
            driver.FindElement(By.Id("FeaturedContent_TextBox3")).SendKeys("aaat");
            driver.FindElement(By.Id("FeaturedContent_TextBox4")).SendKeys("aaa5");

            driver.FindElement(By.Name("ctl00$FeaturedContent$Button1")).Click();

            string message = driver.FindElement(By.Id("FeaturedContent_CompareValidator1")).Text;

            Assert.AreEqual(message, "Password Mismatch..!!");
        }
    }
}
