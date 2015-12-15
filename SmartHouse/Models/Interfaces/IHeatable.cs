using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    interface IHeatable
    {
        void NextHeat();

        void PrevHeat();

        HeatLevel Heat { get; set; }
    }
}
