namespace GildedRoseKata.Common
{
    internal class ConjuredItem() : BaseItemUpdater
    {
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

