using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectExample
{
    class WeaponNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<NinjectExample.Program.Sword>();
        }
    }
}
