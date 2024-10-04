namespace GildedRoseKata.Common
{
    internal class ConjuredUpdater() : BaseItemUpdater
    {
        /// <summary>
        /// Conjured Items reduce in quality at twice the rate of NormalItems
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateQuality(Item item)
        {
            item.Quality-= 2;

            if (item.SellIn <= 0)
            {
                item.Quality-= 2;
            }

            base.UpdateQuality(item);
        }
    }
}

