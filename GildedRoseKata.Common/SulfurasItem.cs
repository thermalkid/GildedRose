namespace GildedRoseKata.Common
{
    internal class SulfurasItem() : BaseItemUpdater
    {
        //As per requirements: "however __"Sulfuras"__ is a legendary item and as such its `Quality` is `80` and it never alters."
        //This is a tad ambiguous, as they're always created with a quality of 80.
        //Let's assume that we want to make it 80 regardless of how the item was created
        public override void UpdateQuality(Item item)
        {
            item.Quality = 80;
        }
    }
}
