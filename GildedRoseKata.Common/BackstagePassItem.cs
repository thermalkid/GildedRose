namespace GildedRoseKata.Common
{
    internal class BackstagePassItem(Item item) : IQualityUpdater
    {
        public void UpdateQuality()
        {
            if (item.SellIn > 0)
            {
                item.Quality++;

                if (item.SellIn < 11)
                {
                    item.Quality++;
                }

                if (item.SellIn < 6)
                {
                    item.Quality++;
                }

                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
            }
            else
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }
    }
}
