using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;

namespace APIServicePractice002.DAL.IData
{
    public interface IUserData
    {
        public UserEntities GetUser(UserModel userModel);
    }
}
