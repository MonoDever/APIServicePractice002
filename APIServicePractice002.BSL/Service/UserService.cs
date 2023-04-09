using APIServicePractice002.BSL.BSLUtility;
using APIServicePractice002.BSL.IService;
using APIServicePractice002.DAL.IData;
using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace APIServicePractice002.BSL.Service
{
    public class UserService : IUserService
    {
        public readonly IUserData _userData;
        public GenerateToken _generateToken;
        private IConfiguration _configuration;
        public UserService(IConfiguration configuration, IUserData userData)
        {
            _userData = userData;
            _configuration = configuration;
            _generateToken = new GenerateToken(_configuration);
        }
        public UserEntities GetUser(UserModel userModel)
        {
            UserEntities userEntities = new UserEntities();
            try
            {
                userEntities = _userData.GetUser(userModel);
                if (userEntities.user.Count > 0)
                {
                    var stringToken = _generateToken.CreateToken(userEntities.user.FirstOrDefault());
                    userEntities.user.FirstOrDefault().auth = stringToken;
                }
                ResultHandle.SuccessHandle(userEntities);
            }
            catch (Exception ex)
            {
                ResultHandle.ExceptionHandle(ex, userEntities, Enums.Error.UserOrpasswordIsInvalid);
            }

            return userEntities;
        }
    }
}
