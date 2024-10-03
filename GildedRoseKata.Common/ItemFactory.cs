﻿namespace GildedRoseKata.Common
{
    internal class ItemFactory
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASS = "Backstage pass";
        private const string SULFURAS = "Sulfuras";
        private const string CONJURED = "Conjured";

        public static IQualityUpdater Create(string name)
        {
            if (name.StartsWith(SULFURAS))
            {
                return new SulfurasItem();
            }
            else if (name.StartsWith(AGED_BRIE))
            {
                return new AgedBrieItem();
            }
            else if (name.StartsWith(BACKSTAGE_PASS))
            {
                return new BackstagePassItem();
            }
            else if (name.StartsWith(CONJURED))
            {
                return new ConjuredItem();
            }

            return new NormalItem();
        }
    }
}
