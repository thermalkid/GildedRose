using System.Collections.Generic;

namespace GildedRoseKata
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
                    UpdateSulfuras(item);
                    break;

                case AGED_BRIE:
                    UpdateAgedBrie(item);
                    break;

                case BACKSTAGE_PASS:
                    UpdateBackstagePasses(item);
                    break;

                default:
                    UpdateNormalItem(item);
                    break;

            }
        }

        private static void UpdateNormalItem(Item item)
        {
            item.Quality--;

            if (item.SellIn <= 0)
            {
                item.Quality--;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }

        private static void UpdateBackstagePasses(Item item)
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

                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
            }
            else
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }

        private static void UpdateAgedBrie(Item item)
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

        private static void UpdateSulfuras(Item item)
        {
            //TODO: Sulfuras should ALWAYS have a quality of 80 and the SellIn never reduces, however this was not 
        }
    }
}
