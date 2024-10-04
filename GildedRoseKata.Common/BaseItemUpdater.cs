namespace GildedRoseKata.Common
{
    internal abstract class BaseItemUpdater : IQualityUpdater
    {
        /// <summary>
        /// Ensures boundaries of 0 and 50 are met, decrements SellIn
        /// </summary>
        /// <param name="item"></param>
        public virtual void UpdateQuality(Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }

            item.SellIn--;
        }
    }
}
