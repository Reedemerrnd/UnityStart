using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IHealing
    {
        public void Heal(float amount);
        public bool CanHeal();
    }
}
