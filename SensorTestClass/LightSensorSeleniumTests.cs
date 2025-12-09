using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SensorTestClass
{
	[TestClass]
	public sealed class LightSensorSeleniumTests
	{
		private static IWebDriver driver;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--headless=new");
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://lysogliv.azurewebsites.net/Vue/index.html");
		}

		[ClassCleanup]
		public static void Cleanup()
		{
			driver.Quit();
		}


		[TestMethod]
		public void TestButtonExists()
		{
			//Act
			IWebElement button = driver.FindElement(By.Id("btnSun"));
			var btnTag = button.TagName;

			//Assert
			Assert.AreEqual("button", btnTag);
		}

		[TestMethod]
		public void TestDateCorrect()
		{
			//Arrange
			IWebElement btnSun = driver.FindElement(By.Id("btnSun"));
			btnSun.Click();
			var dateNow = DateTime.UtcNow.ToString();
			IWebElement btnBurger = driver.FindElement(By.Id("btnBurger"));
			btnBurger.Click();
			IWebElement refData = driver.FindElement(By.Id("refData"));
			refData.Click();

			//Act			
			IWebElement dataEntry = driver.FindElement(By.Id("DataDate"));
			var dataDate = dataEntry.GetAttribute("timeTurnedOn");

			//Assert
			Assert.AreEqual(dateNow, dataDate);
		}
	}
}
