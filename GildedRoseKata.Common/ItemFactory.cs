

namespace GildedRoseKata.Common
{
    internal class ItemFactory
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASS = "Backstage pass";
        private const string SULFURAS = "Sulfuras";

        public static IQualityUpdater Create(Item item)
        {
            if (item.Name.StartsWith(SULFURAS))
            {
                return new SulfurasItem(item);
            }
            else if (item.Name.StartsWith(AGED_BRIE))
            {
                return new AgedBrieItem(item);
            }
            else if (item.Name.StartsWith(BACKSTAGE_PASS))
            {
                return new BackstagePassItem(item);
            }

            return new NormalItem(item);
        }
    }
}
