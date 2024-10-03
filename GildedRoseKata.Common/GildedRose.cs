namespace GildedRoseKata.Common
{
    public class GildedRose
    {
        IList<Item> Items;

        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {

            foreach (var item in Items)
            {
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case SULFURAS:
                    var sulfurasItem = new SulfurasItem(item);
                    sulfurasItem.UpdateQuality();
                    break;

                case AGED_BRIE:
                    var agedBrieitem = new AgedBrieItem(item);
                    agedBrieitem.UpdateQuality();
                    break;

                case BACKSTAGE_PASS:
                    var backstagePassItem = new BackstagePassItem(item);
                    backstagePassItem.UpdateQuality();
                    break;

                default:
                    var normalItem = new NormalItem(item);
                    normalItem.UpdateQuality();
                    break;

            }
        }
    }
}
