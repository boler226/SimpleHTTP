using SimpleHTTP.Models;
using SimpleHTTP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductResultViewModel> GetProducts();
    }
}
