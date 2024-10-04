namespace GildedRoseKata.Common
{
    internal class SulfurasUpdater() : BaseItemUpdater
    {
        /// <summary>
        /// As per requirements: "however __"Sulfuras"__ is a legendary item and as such its `Quality` is `80` and it never alters."
        /// Let's assume that we want to make it 80 regardless of how the item was created
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateQuality(Item item)
        {
            item.Quality = 80;
        }
    }
}
