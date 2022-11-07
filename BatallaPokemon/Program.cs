using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaPokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Ataques

            //Normal
            Ataque Placaje = new Ataque("Placaje", "Normal", 20, 24);
            Ataque Aranazo = new Ataque("Arañazo", "Normal", 20, 30);
            //Planta
            Ataque LatigoCepa = new Ataque("Látigo Cepa", "Planta", 20, 12);
            //Agua
            Ataque PistolaAgua = new Ataque("Pistola Agua", "Agua", 20, 12);
            //Fuego
            Ataque Ascuas = new Ataque("Ascuas", "Fuego", 20, 12);

            //Pokemon
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", "Planta", 45, 49, 49, 45, Placaje, Aranazo, LatigoCepa);
            Pokemon Charmander = new Pokemon("Charmander", "Fuego", 39, 60, 43, 65, Placaje, Aranazo, Ascuas);
            Pokemon Squirtle = new Pokemon("Squirtle", "Agua", 44, 48, 65, 43, Placaje, Aranazo, PistolaAgua);

            Console.WriteLine("Prueba de combate pokemon!\n");

            var pokemonSeleccionado = PokemonSeleccionado(Bulbasaur, Charmander, Squirtle);
            Console.WriteLine("Has elegido a " + pokemonSeleccionado.Nombre + "\n");

            var pokemonEnemigo = PokemonEnemigo(Bulbasaur, Charmander, Squirtle, pokemonSeleccionado);
            Console.WriteLine("El enemigo saca a " + pokemonEnemigo.Nombre + "\n");

            bool finBatalla = false;
            bool esEficaz = false;
            bool esPocoEficaz = false;
            bool enemigoAtacaPrimero = EnemigoAtacaPrimero(pokemonSeleccionado.VelocidadStat, pokemonEnemigo.VelocidadStat);

            int opcionAtaque;
            int opcionAtaqueEnemigo;

            int dañoCausadoInt = 0;

            while (!finBatalla)
            {
                opcionAtaqueEnemigo = OpcionAtaqueEnemigo();

                

                opcionAtaque = ElegirAtaque(pokemonSeleccionado.Ataque1, pokemonSeleccionado.Ataque2, pokemonSeleccionado.Ataque3, pokemonSeleccionado.Nombre, pokemonSeleccionado.HP);

                switch (opcionAtaque)
                {
                    case 1:

                        finBatalla = EnemigoAtaca(finBatalla, enemigoAtacaPrimero, opcionAtaqueEnemigo, pokemonEnemigo, pokemonSeleccionado, esEficaz, esPocoEficaz, dañoCausadoInt);
                        if (finBatalla)
                        {
                            break;
                        }
                        Console.WriteLine("Has usado " + pokemonSeleccionado.Ataque1.NombreAtaque);
                        esEficaz = EsEficaz(pokemonSeleccionado.Ataque1.Tipo, pokemonEnemigo.TipoPokemon);
                        esPocoEficaz = EsPocoEficaz(pokemonSeleccionado.Ataque1.Tipo, pokemonEnemigo.TipoPokemon);

                        dañoCausadoInt = pokemonSeleccionado.DañoAtaque(esEficaz, esPocoEficaz, pokemonSeleccionado.Ataque1, pokemonEnemigo.DefensaStat);
                        pokemonEnemigo.RecibirDaño(esEficaz, esPocoEficaz, dañoCausadoInt);

                        finBatalla = FinBatalla(pokemonSeleccionado.HP, pokemonEnemigo.HP, pokemonSeleccionado.Nombre, pokemonEnemigo.Nombre);
                        break;

                    case 2:

                        finBatalla = EnemigoAtaca(finBatalla, enemigoAtacaPrimero, opcionAtaqueEnemigo, pokemonEnemigo, pokemonSeleccionado, esEficaz, esPocoEficaz, dañoCausadoInt);
                        if (finBatalla)
                        {
                            break;
                        }
                        Console.WriteLine("Has usado " + pokemonSeleccionado.Ataque2.NombreAtaque);
                        esEficaz = EsEficaz(pokemonSeleccionado.Ataque2.Tipo, pokemonEnemigo.TipoPokemon);
                        esPocoEficaz = EsPocoEficaz(pokemonSeleccionado.Ataque2.Tipo, pokemonEnemigo.TipoPokemon);

                        dañoCausadoInt = pokemonSeleccionado.DañoAtaque(esEficaz, esPocoEficaz, pokemonSeleccionado.Ataque2, pokemonEnemigo.DefensaStat);
                        pokemonEnemigo.RecibirDaño(esEficaz, esPocoEficaz, dañoCausadoInt);

                        finBatalla = FinBatalla(pokemonSeleccionado.HP, pokemonEnemigo.HP, pokemonSeleccionado.Nombre, pokemonEnemigo.Nombre);
                        break;

                    case 3:

                        finBatalla = EnemigoAtaca(finBatalla, enemigoAtacaPrimero, opcionAtaqueEnemigo, pokemonEnemigo, pokemonSeleccionado, esEficaz, esPocoEficaz, dañoCausadoInt);
                        if (finBatalla)
                        {
                            break;
                        }
                        Console.WriteLine("Has usado " + pokemonSeleccionado.Ataque3.NombreAtaque);
                        esEficaz = EsEficaz(pokemonSeleccionado.Ataque3.Tipo, pokemonEnemigo.TipoPokemon);
                        esPocoEficaz = EsPocoEficaz(pokemonSeleccionado.Ataque3.Tipo, pokemonEnemigo.TipoPokemon);

                        dañoCausadoInt = pokemonSeleccionado.DañoAtaque(esEficaz, esPocoEficaz, pokemonSeleccionado.Ataque3, pokemonEnemigo.DefensaStat);
                        pokemonEnemigo.RecibirDaño(esEficaz, esPocoEficaz, dañoCausadoInt);

                        finBatalla = FinBatalla(pokemonSeleccionado.HP, pokemonEnemigo.HP, pokemonSeleccionado.Nombre, pokemonEnemigo.Nombre);
                        break;

                    default:
                        finBatalla = EnemigoAtaca(finBatalla, enemigoAtacaPrimero, opcionAtaqueEnemigo, pokemonEnemigo, pokemonSeleccionado, esEficaz, esPocoEficaz, dañoCausadoInt);
                        if (finBatalla)
                        {
                            break;
                        }
                        Console.WriteLine($"{pokemonSeleccionado.Nombre} te desobedeció..");
                        break;

                    
                }

                if (!enemigoAtacaPrimero && pokemonEnemigo.HP > 0)
                {
                    AtaqueEnemigo(opcionAtaqueEnemigo, pokemonEnemigo.Ataque1, pokemonEnemigo.Ataque2, pokemonEnemigo.Ataque3, esEficaz, esPocoEficaz, dañoCausadoInt, pokemonEnemigo, pokemonSeleccionado);
                    finBatalla = FinBatalla(pokemonSeleccionado.HP, pokemonEnemigo.HP, pokemonSeleccionado.Nombre, pokemonEnemigo.Nombre);
                }
            }

            Console.Read();
        }

        public static Pokemon PokemonSeleccionado(Pokemon Bulbasaur, Pokemon Charmander, Pokemon Squirtle)
        {
            Console.WriteLine("Elige tu pokemon");
            Console.WriteLine("1.Bulbasaur    2.Charmander    3.Squirtle\n");
            int opcionPokemon = Convert.ToInt32(Console.ReadLine());

            if (opcionPokemon == 1)
            {
                var pokemonSeleccionado = Bulbasaur;
                return pokemonSeleccionado;
            }
            else if (opcionPokemon == 2)
            {
                var pokemonSeleccionado = Charmander;
                return pokemonSeleccionado;

            }
            else
            {
                var pokemonSeleccionado = Squirtle;
                return pokemonSeleccionado;

            }

        }

        public static Pokemon PokemonEnemigo(Pokemon Bulbasaur, Pokemon Charmander, Pokemon Squirtle, Pokemon pokemonSeleccionado)
        {
            Random random = new Random();
            var pokemonEnemigo = Bulbasaur;

            do
            {
                int numPokemonEnemigo = random.Next(1, 4);

                if (numPokemonEnemigo == 1)
                {
                    pokemonEnemigo = Bulbasaur;
                }
                else if (numPokemonEnemigo == 2)
                {
                    pokemonEnemigo = Charmander;
                }
                else
                {
                    pokemonEnemigo = Squirtle;
                }
            } while (pokemonEnemigo == pokemonSeleccionado);

            return pokemonEnemigo;

        }

        public static int ElegirAtaque(Ataque ataque1, Ataque ataque2, Ataque ataque3, string nombre, int HP)
        {
            Console.WriteLine("Qué debería hacer " + nombre + "?");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"1. {ataque1.NombreAtaque}");
            Console.WriteLine($"2. {ataque2.NombreAtaque}");
            Console.WriteLine($"3. {ataque3.NombreAtaque}");
            int opcionAtaque = Convert.ToInt32(Console.ReadLine());
            return opcionAtaque;

        }

        public static int OpcionAtaqueEnemigo()
        {
            Random random = new Random();
            int opcionAtaqueEnemigo = random.Next(1, 4);
            return opcionAtaqueEnemigo;
        }

        public static void AtaqueEnemigo(int opcionAtaqueEnemigo, Ataque ataque1, Ataque ataque2, Ataque ataque3, bool esEficaz, bool esPocoEficaz, int dañoCausadoInt, Pokemon pokemonEnemigo, Pokemon pokemonSeleccionado)
        {

            switch (opcionAtaqueEnemigo)
            {
                case 1:
                    Console.WriteLine($"El enemigo ha usado {ataque1.NombreAtaque}");
                    esEficaz = EsEficaz(pokemonEnemigo.Ataque1.Tipo, pokemonSeleccionado.TipoPokemon);
                    esPocoEficaz = EsPocoEficaz(pokemonEnemigo.Ataque1.Tipo, pokemonSeleccionado.TipoPokemon);
                    dañoCausadoInt = pokemonEnemigo.DañoAtaque(esEficaz, esPocoEficaz, ataque1, pokemonSeleccionado.DefensaStat);
                    pokemonSeleccionado.RecibirDaño(esEficaz, esPocoEficaz, dañoCausadoInt);
                    break;

                case 2:
                    Console.WriteLine($"El enemigo ha usado {ataque2.NombreAtaque}");
                    esEficaz = EsEficaz(pokemonEnemigo.Ataque2.Tipo, pokemonSeleccionado.TipoPokemon);
                    esPocoEficaz = EsPocoEficaz(pokemonEnemigo.Ataque2.Tipo, pokemonSeleccionado.TipoPokemon);
                    dañoCausadoInt = pokemonEnemigo.DañoAtaque(esEficaz, esPocoEficaz, ataque2, pokemonSeleccionado.DefensaStat);
                    pokemonSeleccionado.RecibirDaño(esEficaz, esPocoEficaz, dañoCausadoInt);
                    break;

                case 3:
                    Console.WriteLine($"El enemigo ha usado {ataque3.NombreAtaque}");
                    esEficaz = EsEficaz(pokemonEnemigo.Ataque3.Tipo, pokemonSeleccionado.TipoPokemon);
                    esPocoEficaz = EsPocoEficaz(pokemonEnemigo.Ataque3.Tipo, pokemonSeleccionado.TipoPokemon);
                    dañoCausadoInt = pokemonEnemigo.DañoAtaque(esEficaz, esPocoEficaz, ataque3, pokemonSeleccionado.DefensaStat);
                    pokemonSeleccionado.RecibirDaño(esEficaz, esPocoEficaz, dañoCausadoInt);
                    break;
            }
        }

        public static bool EnemigoAtacaPrimero(int velocidadPokemonSeleccionado, int velocidadPokemonEnemigo)
        {
            if (velocidadPokemonEnemigo > velocidadPokemonSeleccionado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsEficaz(string tipoPokemonAtaqueSeleccionado, string tipoPokemonEnemigo)
        {
            if ((tipoPokemonAtaqueSeleccionado == "Planta" && tipoPokemonEnemigo == "Agua") ||
                (tipoPokemonAtaqueSeleccionado == "Fuego" && tipoPokemonEnemigo == "Planta") ||
                (tipoPokemonAtaqueSeleccionado == "Agua" && tipoPokemonEnemigo == "Fuego"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsPocoEficaz(string tipoAtaquePokemonSeleccionado, string tipoPokemonEnemigo)
        {
            if ((tipoAtaquePokemonSeleccionado == "Planta" && tipoPokemonEnemigo == "Fuego") ||
                (tipoAtaquePokemonSeleccionado == "Fuego" && tipoPokemonEnemigo == "Agua") ||
                (tipoAtaquePokemonSeleccionado == "Agua" && tipoPokemonEnemigo == "Planta"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool FinBatalla(int pokemonSeleccionadoHP, int pokemonEnemigoHP, string nombrePokemonSeleccionado, string nombrePokemonEnemigo)
        {
            if (pokemonEnemigoHP <= 0)
            {
                Console.WriteLine($"{nombrePokemonEnemigo} ha sido derrotado!\n");
                Console.WriteLine("Has ganado el combate!");
                return true;
            }
            else if (pokemonSeleccionadoHP <= 0)
            {
                Console.WriteLine($"{nombrePokemonSeleccionado} ha sido derrotado...");
                Console.WriteLine("Has perdido el combate.");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EnemigoAtaca(bool finBatalla, bool enemigoAtacaPrimero, int opcionAtaqueEnemigo, Pokemon pokemonEnemigo, Pokemon pokemonSeleccionado, bool esEficaz, bool esPocoEficaz, int dañoCausadoInt)
        {
            if (enemigoAtacaPrimero)
            {
                AtaqueEnemigo(opcionAtaqueEnemigo, pokemonEnemigo.Ataque1, pokemonEnemigo.Ataque2, pokemonEnemigo.Ataque3, esEficaz, esPocoEficaz, dañoCausadoInt, pokemonEnemigo, pokemonSeleccionado);
                finBatalla = FinBatalla(pokemonSeleccionado.HP, pokemonEnemigo.HP, pokemonSeleccionado.Nombre, pokemonEnemigo.Nombre);
            }

            return finBatalla;
        }


    }
}
