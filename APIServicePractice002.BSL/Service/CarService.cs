using APIServicePractice002.BSL.IService;
using APIServicePractice002.DAL.IData;
using APIServicePractice002.DTO;
using APIServicePractice002.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.BSL.Service
{
    public class CarService : ICarService
    {
        public readonly ICarData _carData;
        public CarService(ICarData carData)
        {
            _carData = carData;
        }

        public async Task<ResultEntity> InsertCar(CarModel carModel)
        {
            ResultEntity resultEntity = new ResultEntity();
            resultEntity = await _carData.InsertCar(carModel);
            return resultEntity;
        }

        public List<CarEntity> SearchAllCar()
        {
            List<CarEntity> carModel = new List<CarEntity>();
            carModel = _carData.SearchAllCar();
            return carModel;
        }
    }
}
