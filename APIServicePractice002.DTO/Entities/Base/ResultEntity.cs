﻿using APIServicePractice002.DTO.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DTO.Entities
{
    public class ResultEntity:BaseEntity
    {
        public int totalRecords { get; set; }
    }
}
