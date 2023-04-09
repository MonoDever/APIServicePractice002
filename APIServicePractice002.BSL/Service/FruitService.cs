using APIServicePractice002.BSL.IService;
using APIServicePractice002.DAL.IData;
using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.BSL.Service
{
    public class FruitService : IFruitService
    {
        public readonly IFruitData _fruitData;
        public FruitService(IFruitData fruitData)
        {
            _fruitData = fruitData;
        }
        public async Task<ResultEntity> InsertFruit(FruitModel fruitModel)
        {
            ResultEntity resultEntity = new ResultEntity();
            resultEntity = await _fruitData.InsertFruit(fruitModel);

            return resultEntity;
        }

        public List<FruitEntity> SearchFruitCriteria(FruitModel fruitModel)
        {
            List<FruitEntity> fruitEntity = new List<FruitEntity>();
            fruitEntity = _fruitData.SearchFruitCriteria(fruitModel);

            return fruitEntity;
        }
    }
}
