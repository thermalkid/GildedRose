namespace GildedRoseKata.Common
{
    /// <summary>
    /// Normal items reduce by one before SellIn and 2 afterwards.
    /// </summary>
    internal class NormalUpdater() : BaseItemUpdater
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
