using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Services.Interfaces
{
    public interface IProductService
    {
        public Product getProduct(int id);
    }
}
