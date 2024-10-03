namespace GildedRoseKata.Common
{
    internal class NormalItem() : BaseItemUpdater
    {
        public override void UpdateQuality(Item item)
        {
            item.Quality--;

            if (item.SellIn <= 0)
            {
                item.Quality--;
            }

            base.UpdateQuality(item);
        }
    }
}
