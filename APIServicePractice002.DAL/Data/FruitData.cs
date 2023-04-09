using APIServicePractice002.DAL.Connection;
using APIServicePractice002.DAL.IData;
using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIServicePractice002.DAL.Data
{
    public class FruitData : IFruitData
    {
        private ExecuteCommand _executeCommand;
        private string SP_INSERT_FRUIT = "exec SP_InsertFruit";
        private string SP_SEARCH_FRUIT = "SP_SearchFruitCriteria";
        public FruitData()
        {
            ExecuteCommand executeCommand = new ExecuteCommand();
            _executeCommand = executeCommand;
        }
        public async Task<ResultEntity> InsertFruit(FruitModel fruitModel)
        {
            #region Implemented InsertFruit

            ResultEntity resultEntity = new ResultEntity();

            try
            {
                var createdDateFormat = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                fruitModel.createdBy = "Unknow";
                await Task.Run(() =>
                {
                    var output = _executeCommand.CreateData($"{SP_INSERT_FRUIT} " +
                    $"{(string.IsNullOrEmpty(fruitModel.fruitname) ? DBNull.Value : fruitModel.fruitname)}," +
                    $"'{(string.IsNullOrEmpty(fruitModel.fruitUrl) ? DBNull.Value : fruitModel.fruitUrl)}'," +
                    $"'{createdDateFormat}'," +
                    $"{(string.IsNullOrEmpty(fruitModel.createdBy) ? DBNull.Value : fruitModel.createdBy)}");

                    resultEntity.statusMessage = output;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion Implemented InsertFruit

            return resultEntity;
        }

        public List<FruitEntity> SearchFruitCriteria(FruitModel fruitModel)
        {
            List<FruitEntity> fruitEntity = new List<FruitEntity>();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter { ParameterName = "@fruitname", SqlDbType = SqlDbType.NVarChar, Value = string.IsNullOrEmpty(fruitModel.fruitname) ? DBNull.Value : fruitModel.fruitname };
            sqlParameters[1] = new SqlParameter { ParameterName = "@fruitid", SqlDbType = SqlDbType.Int, Value = 0 };
            var output = _executeCommand.ReadData<FruitEntity>(SP_SEARCH_FRUIT, sqlParameters);

            if (output != "")
            {
            fruitEntity = JsonSerializer.Deserialize<List<FruitEntity>>(output);
            }

            return fruitEntity;
        }
    }
}
