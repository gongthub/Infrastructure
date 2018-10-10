using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc_Autofac.Utility
{
    public class Cat : IAnimal
    {
        public string GetAnimalName()
        {
            return "Cat";
        }
    }
}
