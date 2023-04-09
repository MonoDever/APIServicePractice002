using APIServicePractice002.BSL.IService;
using APIServicePractice002.DTO;
using APIServicePractice002.DTO.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServicePractice002.Controllers
{
    [Authorize]
    [ApiController]
    public class CarController : ControllerBase
    {
        public readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        [Route("api/[controller]/SearchAllCar")]
        public async Task<List<CarEntity>> SearchAllCar()
        {
            List<CarEntity> result = new List<CarEntity>();
            result = _carService.SearchAllCar();

            return result;
        }
        [HttpPost]
        [Route("api/[controller]/InsertCar")]
        public async Task<ResultEntity> InsertCar([FromBody] CarModel carModel)
        {
            ResultEntity result = new ResultEntity();
            result = await _carService.InsertCar(carModel);

            return result;
        }
    }
}
