namespace GildedRoseKata.Common
{
    internal class ItemFactory
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASS = "Backstage pass";
        private const string SULFURAS = "Sulfuras";
        private const string CONJURED = "Conjured";

        /// <summary>
        /// Returns the appropriate Item based on the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IQualityUpdater Create(string name)
        {
            if (name.StartsWith(SULFURAS))
            {
                return new SulfurasUpdater();
            }
            else if (name.StartsWith(AGED_BRIE))
            {
                return new AgedBrieUpdater();
            }
            else if (name.StartsWith(BACKSTAGE_PASS))
            {
                return new BackstagePassUpdater();
            }
            else if (name.StartsWith(CONJURED))
            {
                return new ConjuredUpdater();
            }

            return new NormalUpdater();
        }
    }
}
