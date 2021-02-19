﻿using LSR.Vehicles;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosSantosRED.lsr.Interface
{
    public interface IEntityLoggable
    {
        void AddEntity(VehicleExt vehicle);
        void AddEntity(Blip blip);
        void AddEntity(Cop cop);
    }
}