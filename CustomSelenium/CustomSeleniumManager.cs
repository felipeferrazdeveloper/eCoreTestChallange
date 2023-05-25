﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CustomSelenium;

public static class CustomSeleniumManager
{
    private static IWebDriver? _driver;

    private static IWebDriver GetWebDriver() => _driver ?? throw new Exception("No driver session available");

    public static void StartSession(string url)
    {
        _driver ??= new ChromeDriver(url);
        _driver.Navigate().GoToUrl(url);
    }

    public static void FinishSession()
    {
        _driver?.Quit();
        _driver = null;
    }

    public static void SelectNextTab()
    {            
        IList<string> allTabs = new List<string>(GetWebDriver().WindowHandles);
        allTabs.Remove(GetWebDriver().CurrentWindowHandle);                        
            
        GetWebDriver().SwitchTo().Window(allTabs.First());
    }
}