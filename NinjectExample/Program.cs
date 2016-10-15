using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectExample
{
    class Program
    {
        public static IKernel AppKernel;

        public class Bazuka : IWeapon
        {
            public void Kill()
            {
                Console.WriteLine("Bazuka");
            }
        }

        public class Sword : IWeapon
        {
            public void Kill()
            {
                Console.WriteLine("Sword");
            }
        }

        public class Warrior
        {
            readonly IWeapon _weapon;

            public Warrior(IWeapon weapon)
            {
                this._weapon = weapon;
            }

            public void Kill()
            {
                _weapon.Kill();
            }
        }

        public class AnotherWarrior
        {
            [Inject]
            public IWeapon Weapon { get; set; }

            public void Kill()
            {
                Weapon.Kill();
            }
        }



        static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new WeaponNinjectModule());
            var warrior = AppKernel.Get<Warrior>();
            warrior.Kill();

            var anotherWarrior = AppKernel.Get<AnotherWarrior>();
            anotherWarrior.Kill();
            Console.ReadLine();
        }
    }
}
