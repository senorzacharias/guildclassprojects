﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(ProductType productType);

    }
}
