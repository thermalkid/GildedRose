using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        //SellIn & Quality reduces on UpdateQuality (normal)
        //Quality degrades 2x after SellIn (normal)
        //Quality cannot be below 0

        //Quality increases on UpdateQuality (Brie)
        //Quality cannot exceed 50 (all)

        //Sulfuras SellIn never changes
        //Sulfuras Quality never changes, is always 80

        //Backstage Passes increase in quality (+2 >=10 days, +3 >= 5days
        //Backstage Passes quality == 0 after SellIn

        //TODO: Conjured degrade twice as fast as normal items (not implemented yet) 


        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }
    }
}
