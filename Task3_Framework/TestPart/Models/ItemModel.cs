namespace Task2_SeleniumWebDriver.Steam.TestPart.Models
{
    class ItemModel
    {
        public string ItemName { get; set; }
        public string HeroName { get; set; }
        public string Rarity { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ItemModel other = (ItemModel)obj;

            return ItemName.Equals(other.ItemName) && HeroName.Equals(other.HeroName) && Rarity.Equals(other.Rarity);
        }
    }
}
