namespace GildedRoseKata.Common
{
    internal class BackstagePassItem() : BaseItemUpdater
    {
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
