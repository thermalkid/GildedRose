namespace GildedRoseKata.Common
{
    //Note - we'd typically avoid primary constructors as all constructor parameters are public and do something like this: -
    //private readonly Item _item;
    //
    //public AgedBrieItem(Item item)
    //{
    //    _item = item;
    //}
    //
    // In our case, the item is updated so there's no real benefit in using an internal reference
    // See https://blog.nimblepros.com/blogs/where-csharp-primary-constructors-make-sense/#:~:text=The%20biggest%20problem%20with%20primary,initialize%20a%20field%20or%20property).

    internal class AgedBrieItem(Item item) : IQualityUpdater
    {
        public void UpdateQuality()
        {
            item.Quality++;

            if (item.SellIn <= 0)
            {
                item.Quality++;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }

            item.SellIn--;
        }
    }
}
