﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Autofac.Utility
{
    public class Dog : IAnimal
    {
        public string GetAnimalName()
        {
            return "Dog";
        }
    }
}
