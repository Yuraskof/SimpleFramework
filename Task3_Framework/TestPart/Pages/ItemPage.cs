using OpenQA.Selenium;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class ItemPage:BasePage 
    {
        private string itemPageBaseElement = "//*[@class=\"item_desc_description\"]";
        private string itemName = "//*[@class=\"item_desc_description\"]//h1[@id = \"largeiteminfo_item_name\"]";
        private string itemTypeRarity = "//*[@class=\"item_desc_description\"]//div[@id = \"largeiteminfo_item_type\"]";
        private string usedByHero = "//*[@id=\"largeiteminfo_item_descriptors\"]//div[@class = \"descriptor\"][contains(text(), \"Used By:\")]";

        public bool CheckItemPageIsOpen()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(itemPageBaseElement));
            return elements.Count > 0;
        }

        public bool FindNameElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(itemName));
            return elements.Count > 0;
        }

        public string SaveItemName()
        {
            string text = SaveText(itemName);
            return text;
        }

        public bool FindRarityElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(itemTypeRarity));
            return elements.Count > 0;
        }

        public string SaveItemRarity()
        {
            string text = SaveText(itemTypeRarity);

            if (text.Contains(SearchMenuComMarketPage.TestDataSearchMenu["Rarity"]))
            {
                text = SearchMenuComMarketPage.TestDataSearchMenu["Rarity"];
            }
            return text;
        }

        public bool FindHeroElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(usedByHero));
            return elements.Count > 0;
        }

        public string SaveItemHero()
        {
            string text = SaveText(usedByHero);
            if (text.Contains(SearchMenuComMarketPage.TestDataSearchMenu["Hero"]))
            {
                text = SearchMenuComMarketPage.TestDataSearchMenu["Hero"];
            }
            return text;
        }
    }
}
