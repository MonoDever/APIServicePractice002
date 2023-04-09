using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.BSL.BSLUtility
{
    public class Enums
    {
        public enum Status
        {
            None = 0,
            Success = 1,
            Unsuccess = 2
        }
        public enum Error
        {
            None = 0000,
            UserOrpasswordIsInvalid = 0001,
            test = 0002
        }
    }
}
