using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_commerce.Data.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PictureUrl { get; set; }
        public int? Rate { get; set; }
        //Navigation Propeties
        public int? CategoryID { get; set; }
        [JsonIgnore]
        public Categories? Category { get; set; }
    }
}
