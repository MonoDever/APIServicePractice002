﻿using APIServicePractice002.DTO.Entities;
using APIServicePractice002.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DAL.IData
{
    public interface IFruitData
    {
        public Task<ResultEntity> InsertFruit(FruitModel fruitModel);
        public List<FruitEntity> SearchFruitCriteria(FruitModel fruitModel);
    }
}
