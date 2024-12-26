using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PetUITestProject
{
    public class Tests
    {
        public ChromeDriver driver = new ChromeDriver();

        public const string searchFildNameTag = "q";
        public const string googleImageTag = "img[alt*='Google']";


        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.google.com";
        }

        [Test]
        public void GoToGooglePage()
        {
            var googleImage = driver.FindElement(By.CssSelector(googleImageTag));

            googleImage.Displayed.Should().BeTrue();
        }

        [Test]
        public void SearchSelenium()
        {
            var searchField = driver.FindElement(By.Name(searchFildNameTag));
            searchField.Click();
            searchField.SendKeys("Selenium" + Keys.Enter);
            Thread.Sleep(2000);
            var result = driver.FindElements(By.CssSelector("cite")).Select(c => c.Text.Equals("https://www.selenium.dev"));
            result.Should().NotBeEmpty();

        }

        [OneTimeTearDown]
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}