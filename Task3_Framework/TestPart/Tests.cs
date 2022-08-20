using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart;
using Task3_Framework.TestPart.Pages;

namespace Task2_SeleniumWebDriver.Steam
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ConfigUtils.GetBrowserConfig(); //log
            
            DriverUtils.getInstance(); //log

            DriverUtils.WebDriver.Manage().Window.Maximize(); //log

            ConfigUtils.GetTestData(); //log
        }


        [Test]
        public void TestCase1_MainAboutPages()
        {
            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            mainPage.GoToAlertsPage();

            AlertsFramesWindowsPage alertsPage = new AlertsFramesWindowsPage();

            Assert.IsTrue(alertsPage.isPageOpen(), "Alerts page isn't open");

            alertsPage.menuPage.OpenAlertsForm();

            Assert.IsTrue(alertsPage.alertsFormPage.isPageOpen(), "Alerts form isn't open");

            alertsPage.alertsFormPage.ClickAlert();

            WebDriverWait wait = new WebDriverWait(DriverUtils.WebDriver, TimeSpan.FromSeconds(10));

            Assert.IsTrue(BrowserUtils.AlertIsPresent(wait), "Alert isn't open");

            string simpleAlertText = BrowserUtils.GetTextFromAlert(wait);

            Assert.AreEqual(simpleAlertText, ConfigUtils.TestData["SimpleAlertMessage"], "Wrong message");

            //Assert.IsTrue(mainPage.CheckMainPageIsOpen(), "MainPage isn't open");

            //Assert.IsTrue(mainPage.mainMenuPage.FindElementAbout(), "About element not found");

            //mainPage.mainMenuPage.ClickElementAbout();

            //AboutPage aboutPage = new AboutPage();

            //Assert.IsTrue(aboutPage.CheckPageAboutIsOpen(), "AboutPage isn't open");

            //Assert.IsTrue(aboutPage.FindElementGamersOnline(), "Gamers online element not found");

            //int gamersOnlineCount = aboutPage.FindGamersOnlineCount();

            //Assert.Positive(gamersOnlineCount, "Gamers online count isn't positive");


            //Assert.IsTrue(aboutPage.FindGamersPlayingCountElement(), "Gamers playing element not found");

            //int gamersPlayingCount = aboutPage.FindGamersPlayingCount();

            //Assert.NotZero(gamersPlayingCount, "Gamers playing count isn't positive");

            //Assert.Greater(gamersOnlineCount, gamersPlayingCount, "Gamers online count smaller than gamers playing");

            //Assert.IsTrue(mainPage.mainMenuPage.FindElementStore(), "Store element not found");

            //mainPage.mainMenuPage.ClickElementStore();

            //Assert.IsTrue(mainPage.CheckMainPageIsOpen(), "MainPage isn't open");

        }


        //[Test]
        //public void TestCase2_MenuCheckBoxes()
        //{
        //    DriverUtils.SetImplicitWait(0);

        //    Helpers.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

        //    MainPage mainPage = new MainPage();

        //    Assert.IsTrue(mainPage.CheckMainPageIsOpen(), "MainPage isn't open");


        //    var wait = new WebDriverWait(DriverUtils.WebDriver, new TimeSpan(0, 0, Convert.ToInt32(DriverUtils.BrowserConfig["wait_time"])));
            
        //    Assert.IsTrue(mainPage.mainMenuPage.MoveToMenuElement(), "Can not move to menu element");

        //    Assert.IsTrue(mainPage.mainMenuPage.ExplictWaitFindVisiblePopUpElement(wait), "PopUp element not found");

        //    Assert.NotZero(mainPage.mainMenuPage.ExplictWaitTopSellersFindElement(wait), "TopSellers element not found");

        //    mainPage.mainMenuPage.ClickElementTopSellers();


        //    TopSellersPage topSellersPage = new TopSellersPage();

        //    Assert.IsTrue(topSellersPage.ExplictWaitTopSellersFindElement(wait), "TopSellers page isn't open");

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindOSCheckBox(wait), "OS check box not found");

        //    topSellersPage.ClickCheckBoxOS();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindSteamPanel(wait), "Check box OS not selected");

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindNumberOfPlayersPanel(wait), "NumberOfPlayersPanel not found");
        //    topSellersPage.ClickCheckNumberOfPlayersPanel();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindNumberOfPlayersCheckBox(wait), "NumberOfPlayers check box not found");

        //    if (topSellersPage.ExplictWaitFindVisibleCookiesAcceptElement(wait))
        //    {
        //        topSellersPage.ClickCookiesAcceptElement();
        //    }
                        
        //    topSellersPage.ClickNumberOfPlayersCheckBox();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindCheckedPlayersPanel(wait), "PlayersPanel not checked");

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindTagCheckBox(wait), "Tag Check Box not found");
        //    topSellersPage.ClickTagCheckBox();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindCheckedTagCheckBox(wait), "Tag Check Box not checked");

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindVisibleTag(wait), "Search tag are not visible");
        //    Assert.IsTrue(topSellersPage.ExplictWaitFindVisibleSearchResults(wait), "Search results are not visible");

        //    int searchResultsCount = topSellersPage.ConvertToIntSearchResults();


        //    Assert.NotZero(topSellersPage.ExplictWaitFindAllSearchResults(wait), "All results element not found");

        //    int elementsCount = topSellersPage.ExplictWaitFindAllSearchResults(wait);

        //    Assert.AreEqual(searchResultsCount, elementsCount, "Games values are not equal");


        //    GameModel gameOnTheSearchPage = new GameModel();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindVisibleGameName(wait), "Game name not found");
        //    gameOnTheSearchPage.GameName = topSellersPage.SaveGameName();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindGameReleaseDate(wait), "Game release date not found");
        //    gameOnTheSearchPage.ReleaseDate = topSellersPage.SaveGameReleaseDate();

        //    Assert.IsTrue(topSellersPage.ExplictWaitFindGamePrice(wait), "Game price not found");

        //    List<decimal> gamePrices = topSellersPage.GetPricesList();

        //    if (gamePrices.Count == 2)
        //    {
        //        gameOnTheSearchPage.FullPrice = gamePrices[0];
        //        gameOnTheSearchPage.DiscountedPrice = gamePrices[1];
        //    }
        //    else
        //    {
        //        gameOnTheSearchPage.FullPrice = gamePrices[0];
        //    }


        //    Assert.IsTrue(topSellersPage.ExplictWaitFindAllGamesElement(wait), "All games element not found");

        //    topSellersPage.ClickGameName(wait);

        //    GamePage gamePage = new GamePage();

        //    Assert.IsTrue(gamePage.ExplictWaitFindGamePageBaseElement(wait), "Game page isn't open");


        //    GameModel gameOnTheGamePage = new GameModel();

        //    Assert.IsTrue(gamePage.ExplictWaitFindGameName(wait), "Game name not found");
        //    gameOnTheGamePage.GameName = gamePage.SaveGameName();

        //    Assert.IsTrue(gamePage.ExplictWaitFindGameReleaseDate(wait), "Game release date not found");
        //    gameOnTheGamePage.ReleaseDate = gamePage.SaveGameReleaseDate();

        //    if (gamePage.IsDiscounted(wait))
        //    {
        //        Assert.IsTrue(gamePage.ExplictWaitFindDiscountedPriceElement(wait), "Discounted price element not found");
        //        gamePrices = gamePage.GetPricesList();
        //        gameOnTheGamePage.FullPrice = gamePrices[0];
        //        gameOnTheGamePage.DiscountedPrice = gamePrices[1];

        //    }
        //    else
        //    {
        //        Assert.IsTrue(gamePage.ExplictWaitFindFullPriceElement(wait), "Full price element not found");
        //        gameOnTheGamePage.FullPrice = gamePage.GetFullPrice();
        //    }

        //    Assert.AreEqual(gameOnTheGamePage, gameOnTheSearchPage, "Games are not equal");
        //}


        //[Test]
        //public void TestCase3_CommunityMarketSearch()
        //{
        //    Helpers.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

        //    MainPage mainPage = new MainPage();

        //    Assert.IsTrue(mainPage.CheckMainPageIsOpen(), "MainPage isn't open");

        //    Assert.IsTrue(mainPage.mainMenuPage.FindElementCommunity(), "Community element not found");

        //    Assert.IsTrue(mainPage.mainMenuPage.MoveToCommunityElement(), "Can not move to community element");

        //    Assert.IsTrue(mainPage.mainMenuPage.FindElementMarket(), "Market element not found");

        //    mainPage.mainMenuPage.ClickElementMarket();


        //    CommunityMarketPage communityMarketPage = new CommunityMarketPage();

        //    Assert.IsTrue(communityMarketPage.CheckCommunityMarketPageIsOpen(), "CommunityMarketPage isn't open");

        //    Assert.IsTrue(communityMarketPage.FindAdvancedSearchButton(), "Advanced search button not found");

        //    communityMarketPage.ClickAdvancedSearchButton();


        //    Assert.IsTrue(communityMarketPage.searchMenu.CheckSearchFormIsOpen(), "Search form isn't open");

        //    Assert.IsTrue(communityMarketPage.searchMenu.FindExpandListElement(), "Expand list element not found");

        //    communityMarketPage.searchMenu.ClickExpandListElement();


        //    Assert.IsTrue(communityMarketPage.searchMenu.FindAllGamesElement(), "All games element not found");

        //    communityMarketPage.searchMenu.SelectGame();

        //    Assert.IsTrue(communityMarketPage.searchMenu.FindAllHeroListElement(), "Hero list element not found");

        //    communityMarketPage.searchMenu.ClickHeroListElement();

        //    communityMarketPage.searchMenu.SelectHero();

        //    Assert.IsTrue(communityMarketPage.searchMenu.FindRarityElement(), "Rarity element not found");

        //    communityMarketPage.searchMenu.ClickRarityElement();

            
        //    Assert.IsTrue(communityMarketPage.searchMenu.FindSearchFieldElement(), "Search field element not found");

        //    communityMarketPage.searchMenu.SearchText();

        //    communityMarketPage.searchMenu.AcceptCookies();

            
        //    Assert.IsTrue(communityMarketPage.searchMenu.FindSearchButton(), "Search button not found");

        //    communityMarketPage.searchMenu.ClickSearchButton();

            
        //    Assert.IsTrue(communityMarketPage.FindFiltersElement(), "Filters element not found");

        //    List<string> filtersNames = communityMarketPage.GetFiltersNames();


        //    Assert.Multiple(() =>
        //    {
        //        Assert.AreEqual(filtersNames[0], SearchMenuComMarketPage.TestDataSearchMenu["Game"], "Game names not equal");
        //        Assert.AreEqual(filtersNames[1], SearchMenuComMarketPage.TestDataSearchMenu["Hero"], "Hero names not equal");
        //        Assert.AreEqual(filtersNames[2], SearchMenuComMarketPage.TestDataSearchMenu["Rarity"], "Rarity not equal");
        //        Assert.AreEqual(filtersNames[3], SearchMenuComMarketPage.TestDataSearchMenu["Search"], "Search text not equal");
                    
        //    });
            
        //    Assert.IsTrue(communityMarketPage.FindAllNamesElement(), "All names element not found");

        //    IReadOnlyList<IWebElement> namesElements = communityMarketPage.GetNamesElements();

        //    int itemsToCheck = Convert.ToInt32(CommunityMarketPage.TestDataCommunityMarket["SelectGamesCount"]);
        //    string textToSearch = CommunityMarketPage.TestDataCommunityMarket["ItemNameContains"];

        //    for (int i = 0; i < itemsToCheck; i++)
        //    {
        //        String textInElement = namesElements[i].Text;

        //        Assert.IsTrue(textInElement.Contains(textToSearch), string.Format("Item {0} not contains {1}", i, textToSearch));
        //    }

        //    ItemModel itemOnSearchPage = new ItemModel();

            
        //    IReadOnlyList<IWebElement> filterElements = communityMarketPage.GetFilterNamesElements();

        //    for (int i = 0; i < filterElements.Count - 1; i++)
        //    {
        //        String textInElement = filterElements[i].Text;

        //        if (textInElement.Contains(SearchMenuComMarketPage.TestDataSearchMenu["Game"]) ||
        //            textInElement.Contains(SearchMenuComMarketPage.TestDataSearchMenu["Search"]))
        //        {
        //            filterElements[i].Click();
        //            filterElements = communityMarketPage.GetFilterNamesElements();
        //            i = 0;
        //        }
        //        else if (textInElement.Contains(SearchMenuComMarketPage.TestDataSearchMenu["Hero"]))
        //        {
        //            itemOnSearchPage.HeroName = filterElements[i].Text;
        //        }
        //        else if (textInElement.Contains(SearchMenuComMarketPage.TestDataSearchMenu["Rarity"]))
        //        {
        //            itemOnSearchPage.Rarity = filterElements[i].Text;
        //        }
        //    }


        //    IReadOnlyList<IWebElement> namesElementsUpdated = communityMarketPage.GetNamesElements();

        //    bool listsAreDifferent = false;

        //    for (int i = 0; i < namesElementsUpdated.Count && i < namesElements.Count; i++)
        //    {
        //        if (namesElementsUpdated[i] != namesElements[i])
        //        {
        //            listsAreDifferent = true;
        //            break;
        //        }
        //    }

        //    Assert.IsTrue(listsAreDifferent = true);


        //    int itemCount = Convert.ToInt32(CommunityMarketPage.TestDataCommunityMarket["SeeDetailsItemCount"]) - 1;

        //    itemOnSearchPage.ItemName = namesElementsUpdated[itemCount].Text; 

        //    namesElementsUpdated[itemCount].Click();


        //    ItemPage itemPage = new ItemPage();

        //    Assert.IsTrue(itemPage.CheckItemPageIsOpen(), "Item page isn't open");

        //    Assert.IsTrue(itemPage.FindNameElement(), "Name element not found");

        //    ItemModel itemOnTheOwnPage = new ItemModel();

        //    itemOnTheOwnPage.ItemName = itemPage.SaveItemName();

            
        //    Assert.IsTrue(itemPage.FindRarityElement(), "Rarity element not found");

        //    itemOnTheOwnPage.Rarity = itemPage.SaveItemRarity();

        //    Assert.IsTrue(itemPage.FindHeroElement(), "Hero element not found");

        //    itemOnTheOwnPage.HeroName = itemPage.SaveItemHero();

        //    Assert.AreEqual(itemOnSearchPage, itemOnTheOwnPage, "Item models are not equal");
        //}


        [TearDown]
        public void close_Browser()
        {
            DriverUtils.WebDriver.Quit();
            DriverUtils.ResetDriver();
        }
    }
}