using Hrdina_a_drak_2023.Rozhrani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak_2023.Postavy
{
    class Drak : Postava
    {
        public Drak(double zdravi, double maxUtok, string jmeno, INahodny nahodny) : base(zdravi, maxUtok, jmeno, nahodny)
        {
        }

    }
}
