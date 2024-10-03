namespace GildedRoseKata.Common
{
    internal class BackstagePassUpdater() : BaseItemUpdater
    {
        /// <summary>
        /// Backstage passes increase in quality as the SellIn approaches but are worthless afterwards
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateQuality(Item item)
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
            }
            else {

                item.Quality = 0;
            }
    
            base.UpdateQuality(item);
        }
    }
}
