using APIServicePractice002.DAL.Connection;
using APIServicePractice002.DAL.IData;
using APIServicePractice002.DTO;
using APIServicePractice002.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIServicePractice002.DAL.Data
{
    public class CarData : ICarData
    {
        ExecuteCommand executeCommand;
        private string SP_SEARCH_ALL_CAR = "SP_GetAllCar";
        private string SP_INSERT_CAR = "exec SP_InsertCar";
        public CarData()
        {
            executeCommand = new ExecuteCommand();
        }

        public async Task<ResultEntity> InsertCar(CarModel carModel)
        {
            ResultEntity resultEntity = new ResultEntity();

            try
            {

            var stringOutput = executeCommand.CreateData($"{SP_INSERT_CAR} " +
                $"{carModel.Name = (!string.IsNullOrEmpty(carModel.Name) ? carModel.Name : "") }," +
                $"'{ carModel.LinkImage = (!string.IsNullOrEmpty(carModel.LinkImage) ? carModel.LinkImage : "")}'");

               await Task.Run( () =>
               {
                   resultEntity.statusMessage = stringOutput;//"SUCCESS"
               });
            }
            catch (Exception ex)
            {

            }

            return resultEntity;
        }

        public List<CarEntity> SearchAllCar()
        {
            var stringOutput = executeCommand.ReadData<CarEntity>(SP_SEARCH_ALL_CAR,null);
            var objOutput = JsonSerializer.Deserialize<List<CarEntity>>(stringOutput);
            return objOutput;
        }
    }
}
