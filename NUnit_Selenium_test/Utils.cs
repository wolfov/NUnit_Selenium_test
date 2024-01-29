using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace NUnit_Selenium_test
{
    public class Utils
    {
        public static IWebElement WaitElementForVisible(IWebDriver driver, By by)
        {
            if (driver == null || by == null)
                throw new NullReferenceException();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(driver =>
            {
                try
                {
                    IWebElement elementToBeVisible = driver.FindElement(by);
                    if (elementToBeVisible != null && elementToBeVisible.Displayed)
                        return elementToBeVisible;
                    throw new NoSuchElementException();
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
    }
}
