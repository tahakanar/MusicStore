using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore
{
    public class ShoppingChart
    {
        public List<ChartItem> Items { get; set; } = new List<ChartItem>();

        public void Add(ChartItem chartItem)
        {
            var item = Items.SingleOrDefault(p => p.AlbumId == chartItem.AlbumId);
            if (item != null)
            {
                item.Quantity++;
            }
            else
                Items.Add(chartItem);
        }

        public void Add(int AlbumId) => Items.Single(p => p.AlbumId == AlbumId).Quantity++;
        //{
        //    var item = Items.Single(p => p.AlbumId == AlbumId);
        //    item.Quantity++;
        //}

        public void DecreaseQuantity(int AlbumId)
        {
            var item = Items.Single(p => p.AlbumId == AlbumId);
            item.Quantity--;
            if (item.Quantity == 0)
            {
                Items.Remove(item);
            }
        }

        public void Remove(int AlbumId) => Items.Remove(Items.Single(p => p.AlbumId == AlbumId));
        //{
        //    var item = Items.Single(p => p.AlbumId == AlbumId);
        //    Items.Remove(item);
        //}

        public void Clear() => Items = new List<ChartItem>();

        //{
        //    Items = new List<ChartItem>();
        //}

        public decimal GrandTotal => Items.Sum(p => p.Amount);
        //{
        //    var t = 0m;
        //    foreach (var item in Items)
        //    {
        //        t += item.Amount;
        //    }
        //    return t;
        //}
    }
}