using APIServicePractice002.BSL.IService;
using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServicePractice002.Controllers
{
    [ApiController]
    public class FruitController : ControllerBase
    {
        public readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpPost]
        [Route("api/[controller]/InsertFruit")]
        public async Task<ResultEntity> InsertFruit([FromBody] FruitModel fruitModel)
        {
            ResultEntity resultEntity = new ResultEntity();
            resultEntity = await _fruitService.InsertFruit(fruitModel);
            return resultEntity;
        }
        [HttpGet]
        [Route("api/[controller]/SearchFruit")]
        public List<FruitEntity> SearchFruit([FromQuery] FruitModel fruitModel)
        {
           List<FruitEntity> fruitEntity = new List<FruitEntity>();
            fruitEntity = _fruitService.SearchFruitCriteria(fruitModel);
            return fruitEntity;
        }
    }
}
