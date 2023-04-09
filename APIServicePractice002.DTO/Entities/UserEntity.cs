using APIServicePractice002.DTO.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DTO.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string auth { get; set; }
    }
    public class UserEntities :ResultEntity
    {
        public List<UserEntity> user { get; set; }
    }
}
