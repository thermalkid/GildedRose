namespace GildedRoseKata.Common
{
    internal class AgedBrieUpdater() : BaseItemUpdater
    {
        /// <summary>
        /// Aged Brie Items update in quality by 1 before SellIn and 2 afterwards
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateQuality(Item item)
        {
            item.Quality++;

            if (item.SellIn <= 0)
            {
                item.Quality++;
            }
            
            base.UpdateQuality(item);   
        }
    }
}
