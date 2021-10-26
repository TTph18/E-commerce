using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Shared.DTO.Product
{
    public class ProductCriteriaDTO : BaseQueryCriteriaDTO
    {
        public int CategoryID { get; set; }
    }
}
