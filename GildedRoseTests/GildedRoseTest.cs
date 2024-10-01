using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        //TODO: Conjured degrade twice as fast as normal items (not implemented yet) 


        //SellIn & Quality reduces on UpdateQuality (normal)
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

        //Quality degrades 2x after SellIn (normal)
        [Fact]
        public void Quality_Degrades_After_SellIn_For_Normal_Item()
        {
            IList<Item> Items = [new Item { Name = "foo", SellIn = 0, Quality = 5 }];
            GildedRose app = new(Items);
            app.UpdateQuality();

            var item = Items.First();
            Assert.Equal(3, item.Quality);
        }


        //Quality cannot be below 0
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

        //Quality increases on UpdateQuality (Brie)
        [Fact]
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

        //Quality cannot exceed 50 (all)
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

        //Sulfuras SellIn never changes
        //Sulfuras Quality never changes, is always 80

        //Backstage Passes increase in quality (+2 >=10 days, +3 >= 5days
        //Backstage Passes quality == 0 after SellIn



        //[Fact]
        //public void foo()
        //{
        //    IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        //    GildedRose app = new GildedRose(Items);
        //    app.UpdateQuality();
        //    Assert.Equal("fixme", Items[0].Name);
        //}
    }
}
