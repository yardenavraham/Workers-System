﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBl
    {
        public IBL getBl()
        {
            return new Bl_imp();
        }
    }
}
