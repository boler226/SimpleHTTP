using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.ViewModel
{
    public class ProductResultViewModel
    {
        public List<ProductItemViewModel> List { get; set; }

        //Номер сторінки
        public int PageIndex { get; set; } = 1;
        //Кількість записів на сторінці
        public int PageSize { get; set; }
        //Загальна кількість записів
        public int TotalCount { get; set; }
        //Загальна кількість сторінок
        public int TotalPages { get; set; }
    }
}
