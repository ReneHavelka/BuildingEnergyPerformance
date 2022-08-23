﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class ThermalProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
    }
}
