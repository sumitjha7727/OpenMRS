using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenMRS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            Actions ActionProvider = new Actions(Driver);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demo.openmrs.org/openmrs/login.htm");
            Thread.Sleep(1000);

            // LOGIN

            Driver.FindElement(By.XPath("//p//input[@id='username']")).SendKeys("Admin");
            Driver.FindElement(By.XPath("//p//input[@id='password']")).SendKeys("Admin123");
            Driver.FindElement(By.XPath("//ul//li[@id='Inpatient Ward']")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//p//input[@id='loginButton']")).Click();
            Thread.Sleep(2000);

            // LOGOUT
            //Driver.FindElement(By.XPath("//ul//a[@href='/openmrs/appui/header/logout.action?successUrl=openmrs']")).Click();
            //Thread.Sleep(2000);

            
            // REGISTER A PATIENT  

            Driver.FindElement(By.XPath("//div//a[@id='referenceapplication-registrationapp-registerPatient-homepageLink-referenceapplication-registrationapp-registerPatient-homepageLink-extension']")).Click();
            Thread.Sleep(2000);
            Driver.Navigate().GoToUrl("https://demo.openmrs.org/openmrs/registrationapp/registerPatient.page?appId=referenceapplication.registrationapp.registerPatient");
            Driver.FindElement(By.XPath("//p//input[@name='givenName']")).SendKeys("Goku");
            Driver.FindElement(By.XPath("//p//input[@name='middleName']")).SendKeys("san");
            Driver.FindElement(By.XPath("//p//input[@name='familyName']")).SendKeys("Saiyan");
            Driver.FindElement(By.XPath("//div//button[@id='next-button']")).Click();
            Thread.Sleep(2000);
  
            Driver.FindElement(By.XPath("//p//option[@value='M']")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//div//button[@id='next-button']")).Click();
            Thread.Sleep(2000);


            Driver.FindElement(By.XPath("//div//input[@id='birthdateDay-field']")).SendKeys("14");
            Driver.FindElement(By.XPath("//div//input[@id='birthdateDay-field']")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//p//option[@value='3']")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div//input[@id='birthdateYear-field']")).SendKeys("1999");
            Driver.FindElement(By.XPath("//div//button[@id='next-button']")).Click();
            Thread.Sleep(2000);

            Driver.FindElement(By.XPath("//p//input[@id='address1']")).SendKeys("KOLKATA");
            Driver.FindElement(By.XPath("//p//input[@id='address2']")).SendKeys("Tollygunge");

            Driver.FindElement(By.XPath("//p//input[@id='cityVillage']")).SendKeys("Kolkata");
            Driver.FindElement(By.XPath("//p//input[@id='stateProvince']")).SendKeys("WB");
            Driver.FindElement(By.XPath("//p//input[@id='country']")).SendKeys("INDIA");
            Driver.FindElement(By.XPath("//p//input[@id='postalCode']")).SendKeys("815301");
            Driver.FindElement(By.XPath("//div//button[@id='next-button']")).Click();
            Thread.Sleep(2000);
            
            Driver.FindElement(By.XPath("//p//input[@name='phoneNumber']")).SendKeys("123456789");
            Driver.FindElement(By.XPath("//div//button[@id='next-button']")).Click();
            Thread.Sleep(2000);



            Driver.FindElement(By.XPath("//div//select[@id='relationship_type']")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div//select[@id='relationship_type']")).SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            Driver.FindElement(By.XPath("//p//input[@placeholder='Person Name']")).SendKeys("Goku San");
            Driver.FindElement(By.XPath("//div//button[@id='next-button']")).Click();
            Thread.Sleep(2000);

            Driver.FindElement(By.XPath("//p//input[@id='submit']")).Click();
            Thread.Sleep(2000);


            
            // Find a patient record
            Driver.Navigate().GoToUrl("https://demo.openmrs.org/openmrs/index.htm");
            Driver.FindElement(By.XPath("//div//a[@id='coreapps-activeVisitsHomepageLink-coreapps-activeVisitsHomepageLink-extension']")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("//div//input[@id='patient-search']")).SendKeys("Goku");
            Driver.FindElement(By.XPath("//div//input[@id='patient-search']")).SendKeys(Keys.Enter);

            Driver.FindElement(By.ClassName("odd")).Click();
            Thread.Sleep(2000);
            IWebElement doubleClickBtn = Driver.FindElement(By.ClassName("odd"));
            ActionProvider.DoubleClick(doubleClickBtn).Build().Perform();

            Driver.FindElement(By.XPath("//ul//a[@id='appointmentschedulingui.schedulingAppointmentDashboardLink']")).Click();
            Thread.Sleep(2000);

            Driver.Close();
            Driver.Quit();

        }

    }
}
