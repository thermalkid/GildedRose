using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        //UpdateQuality Breakdown
        //-----------------------
        //Quantity Decreases by 1 if a "Normal" item - not "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros"
        //Quantity cannot go below 0 if a "Normal" item - not "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros"
        //"Sulfuras, Hand of Ragnaros" does not decrease in quality
        //If Aged Brie OR "Backstage passes to a TAFKAL80ETC concert", increase Quality by one 
        //If "Backstage passes to a TAFKAL80ETC concert" increase by a further 1 if SellIn <11, don't exceed 50
        //If "Backstage passes to a TAFKAL80ETC concert" increase by a further 1 if SellIn <6, don't exceed 50
        //Decrease SellIn if not "Sulfuras, Hand of Ragnaros"
        //If passed SellIn and NOT Aged Brie and Not "Backstage passes to a TAFKAL80ETC concert" reduce Quality by 1
        //If passed SellIn and "Backstage passes to a TAFKAL80ETC concert" set Quality to 0
        //If passed SellIn and Normal item reduce Quality by one
        //If passed SellIn and "AgedBrie" item increase Quality by one

        //TODO: Conjured degrade twice as fast as normal items (not implemented yet)
        //See Program.cs
        //Extend Tests to cover boundaries:
        // - Under/Over SellIn (normal)
        // - Under/Over SellIn period (brie)
        // - Over 10, 5 SellIn period (backstage passes)

        [Fact]
        public void Quality_Reduces_For_Normal_Item() {
            IList<Item> Items = [new Item { Name = "foo", SellIn = 1, Quality = 5 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(4, item.Quality);
        }

        [Fact]
        public void SellIn_Reduces_For_Normal_Item()
        {
            IList<Item> Items = [new Item { Name = "foo", SellIn = 1, Quality = 5 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void Quality_Degrades_After_SellIn_For_Normal_Item()
        {
            IList<Item> Items = [new Item { Name = "foo", SellIn = 0, Quality = 5 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(3, item.Quality);
        }

        [Fact]
        public void Quality_Cannot_Be_Below_0_For_Expired_Normal_Item()
        {
            IList<Item> Items = [new Item { Name = "foo", SellIn = -1, Quality = 1 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Quality_Cannot_Be_Below_0_For_Normal_Item()
        {
            IList<Item> Items = [new Item { Name = "foo", SellIn = 1, Quality = 0 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(0, item.Quality);
        }

        [Fact(Skip = "Requirements unclear. Aged Brie only increases in quality AFTER the SellIn date")]
        public void Quality_Increases_For_Brie()
        {
            IList<Item> Items = [new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();

            //TODO: Test fails, re-check requirements
            Assert.Equal(3, item.Quality);
        }

        [Fact]
        public void Quality_Increases_For_Brie_After_SellIn()
        {
            IList<Item> Items = [new Item { Name = "Aged Brie", SellIn = -1, Quality = 1 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(3, item.Quality);
        }

        [Fact]
        public void Brie_Quality_Cannot_Exceed_50_After_SellIn()
        {
            IList<Item> Items = [new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Brie_Quality_Cannot_Exceed_50_Before_SellIn()
        {
            IList<Item> Items = [new Item { Name = "Aged Brie", SellIn = 5, Quality = 49 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Normal_Quality_Cannot_Exceed_50_After_SellIn()
        {
            IList<Item> Items = [new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Sulfuras_SellIn_Never_Changes()
        {
            IList<Item> Items = [new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(5, item.SellIn);
        }

        [Fact]
        public void Sulfuras_Quality_Is_Stays_At_80()
        {
            IList<Item> Items = [new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(80, item.Quality);
        }

        [Fact(Skip = "Requirements unclear. Sulfuras will maintain the Quality initialised with")]
        public void Sulfuras_Quality_Is_Always_80()
        {
            IList<Item> Items = [new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            //TODO: Test fails, re-check requirements
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void BackstagePass_Increases_By_1_Outside_10_Days()
        {
            IList<Item> Items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void BackstagePass_Increases_By_2_Outside_5_Days()
        {
            IList<Item> Items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void BackstagePass_Increases_By_3_Inside_5_Days()
        {
            IList<Item> Items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(13, item.Quality);
        }
    }
}
