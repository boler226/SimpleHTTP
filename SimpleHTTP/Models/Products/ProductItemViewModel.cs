using SimpleHTTP.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SimpleHTTP.ViewModel
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public List<string> Images { get; set; }
        public BitmapImage BitmapImage { get; set; }

    }
}
