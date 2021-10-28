using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Shared.ViewModels
{
    public class RatingCreateRequest
    {
        public int ProductID { get; set; }
        public int Rating { get; set; }
    }
}
