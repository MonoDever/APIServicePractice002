using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DTO.Entities.Base
{
    public class ErrorEntity
    {
        public bool isError => errorCode == "0000" ? false : true;
        public string errorCode { get; set; }
        public string errorMessage { get; set; } = null;
    }
}
