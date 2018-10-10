using Autofac;
using Ioc.Autofac.Utility;
using System;

namespace Ioc.Autofac
{
    static class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Cat>().As<IAnimal>().Keyed<IAnimal>("Cat").SingleInstance();
            containerBuilder.RegisterType<Dog>().As<IAnimal>().Keyed<IAnimal>("Dog");
            //containerBuilder.RegisterInstance<IAnimal>(new Dog());
            //containerBuilder.RegisterInstance<IAnimal>(new Cat()); 

            var container = containerBuilder.Build();

            //var ianimal = container.Resolve<IAnimal>();
            //var ianimal = container.ResolveKeyed<IAnimal>("Cat");
            //Console.WriteLine(ianimal.GetAnimalName());
            using (var scope = container.BeginLifetimeScope())
            {
                var cat = scope.ResolveKeyed<IAnimal>("Cat");
                Console.WriteLine(cat.GetAnimalName());
                Console.WriteLine(cat.GetHashCode());
                var cat2 = scope.ResolveKeyed<IAnimal>("Cat");
                Console.WriteLine(cat2.GetAnimalName());
                Console.WriteLine(cat2.GetHashCode());
                var dog = scope.ResolveKeyed<IAnimal>("Dog");
                Console.WriteLine(dog.GetAnimalName());
                Console.WriteLine(dog.GetHashCode());
                var dog2 = scope.ResolveKeyed<IAnimal>("Dog");
                Console.WriteLine(dog2.GetAnimalName());
                Console.WriteLine(dog2.GetHashCode());
            }

            Console.ReadKey();
        }
    }
}
