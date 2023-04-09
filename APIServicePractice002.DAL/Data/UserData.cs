using APIServicePractice002.DAL.Connection;
using APIServicePractice002.DAL.IData;
using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;

namespace APIServicePractice002.DAL.Data
{
    public class UserData : IUserData
    {
        private ExecuteCommand _executeCommand;
        private string SP_GET_USER = "SP_GETUSER";
        public UserData()
        {
            _executeCommand = new ExecuteCommand();
        }
        public UserEntities GetUser(UserModel userModel)
        {
            UserEntities userEntities = new UserEntities();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter { ParameterName = "username", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(userModel.username) ? DBNull.Value : userModel.username };
                param[1] = new SqlParameter { ParameterName = "password", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(userModel.password) ? DBNull.Value : userModel.password };

                var output = _executeCommand.ReadData<UserEntity>(SP_GET_USER, param);

                if (output != "")
                {
                    var listUser = JsonSerializer.Deserialize<List<UserEntity>>(output);
                    userEntities.user = listUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userEntities;
        }
    }
}
