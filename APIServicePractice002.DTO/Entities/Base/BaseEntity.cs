using APIServicePractice002.DTO.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DTO.Entities.Base
{
    public class BaseEntity : ErrorEntity
    {
        public bool status => statusMessage == "Success" ? true : false;
        public string statusMessage { get; set; } = null;
    }
}
