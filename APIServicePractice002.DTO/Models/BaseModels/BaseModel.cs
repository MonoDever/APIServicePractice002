using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DTO.Models.BaseModels
{
    public class BaseModel
    {
        public DateTime? createdDate { get; set; } = null;
        public string createdBy { get; set; } = null;
        public DateTime? updatedDate { get; set; } = null;
        public string updatedBy { get; set; } = null;
    }
}
