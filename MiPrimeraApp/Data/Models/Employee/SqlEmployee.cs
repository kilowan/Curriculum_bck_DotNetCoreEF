﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApp.Data.Models.Employee
{
    public class SqlEmployee : SqlMin
    {
		public string name;
		public string dni;
		public string surname1;
		public string surname2;
		public int? typeId;
		public bool state;
    }
}