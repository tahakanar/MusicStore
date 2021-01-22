using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore
{
    public class ChartItem
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public byte[] CoverImage { get; set; }

        public int Quantity { get; set; }

        public decimal  Price { get; set; }

        public decimal Amount => Quantity * Price;
    }
}