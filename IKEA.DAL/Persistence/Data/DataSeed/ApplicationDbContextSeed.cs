﻿using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Data.DataSeed
{
    internal class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext dbContext)
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
