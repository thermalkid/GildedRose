namespace GildedRoseKata.Common
{
    internal class NormalItem(Item item) : IQualityUpdater
    {
        public void UpdateQuality()
        {
            item.Quality--;

            if (item.SellIn <= 0)
            {
                item.Quality--;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }
    }
}
