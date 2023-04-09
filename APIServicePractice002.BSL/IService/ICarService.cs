using APIServicePractice002.DTO;
using APIServicePractice002.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.BSL.IService
{
    public interface ICarService
    {
        public List<CarEntity> SearchAllCar();
        public Task<ResultEntity> InsertCar(CarModel carModel);
    }
}
