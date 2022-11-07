using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaPokemon
{
    internal class Pokemon
    {
        public string Nombre { get; }
        public string TipoPokemon { get; }
        public int HP { get; set; }
        public int AtaqueStat { get; set; }
        public int DefensaStat { get; set; }
        public int VelocidadStat { get; set; }

        public Ataque Ataque1 { get; }
        public Ataque Ataque2 { get; }
        public Ataque Ataque3 { get; }

        public Pokemon(string nombrePa, string tipoPa, int hpPa, int ataquePa, int defensaPa, int velocidadPa, Ataque ataque1Pa, Ataque ataque2Pa, Ataque ataque3Pa)
        {
            Nombre = nombrePa;
            TipoPokemon = tipoPa;
            HP = hpPa;
            AtaqueStat = ataquePa;
            DefensaStat = defensaPa;
            VelocidadStat = velocidadPa;
            Ataque1 = ataque1Pa;
            Ataque2 = ataque2Pa;
            Ataque3 = ataque3Pa;

        }

        public int DañoAtaque(bool esEficaz, bool esPocoEficaz, Ataque ataque, int defensaEnemigoStat)
        {
            double daño;

            if (esEficaz)
            {
                daño = 1;
            }
            else if (esPocoEficaz)
            {
                daño = 0.25;
            }
            else
            {
                daño = 0.5;
            }


            double dañoCausado = 0.01 * daño * ((((0.2 * 5 + 1) * AtaqueStat * ataque.Daño) / 25 * defensaEnemigoStat) + 2) / 2;
            int dañoCausadoInt = Convert.ToInt32(Math.Round(dañoCausado));

            return dañoCausadoInt;

        }

        public void RecibirDaño(bool esEficaz, bool esPocoEficaz, int dañoCausadoInt)
        {
            if (esEficaz)
            {
                Console.WriteLine("Fue muy eficaz! el daño es: " + dañoCausadoInt + "\n");
            }
            else if (esPocoEficaz)
            {
                Console.WriteLine("No fue muy eficaz.. el daño es: " + dañoCausadoInt + "\n");
            }
            else
            {
                Console.WriteLine("El daño es: " + dañoCausadoInt + "\n");
            }

            HP -= dañoCausadoInt;
            if (HP <= 0)
            {
                Console.WriteLine($"El HP de {Nombre} es: 0");
            }
            else
            {
                Console.WriteLine($"El HP de {Nombre} es: {HP}");
            }
            
        }

        
    }
}
