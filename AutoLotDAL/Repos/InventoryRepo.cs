﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Models;

namespace AutoLotDAL.Repos
{
    public class InventoryRepo:BaseRepo<Test>
    {
        public override List<Test> GetAll() => Context.Cars.OrderBy(x => x.PetName).ToList();

    }
}
