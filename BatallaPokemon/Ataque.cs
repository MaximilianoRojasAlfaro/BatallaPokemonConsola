using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaPokemon
{
    internal class Ataque
    {
        public string NombreAtaque { get; set; }
        public string Tipo { get; set; }
        public int Daño { get; set; }
        public int PP { get; set; }

        public Ataque(string nombrePa, string tipoPa, int dañoPa, int ppPa)
        {
            NombreAtaque = nombrePa;
            Tipo = tipoPa;
            Daño = dañoPa;
            PP = ppPa;
        }
    }
}
