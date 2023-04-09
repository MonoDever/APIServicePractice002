using APIServicePractice002.DTO.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DTO.Models
{
    public class FruitModel : BaseModel
    {
        public string fruitname { get; set; }
        public string fruitUrl { get; set; }
    }
}
