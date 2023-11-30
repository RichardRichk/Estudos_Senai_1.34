using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG_de_dois_personagens
{
    public class Personagens
    {
        //propriedades:
        public string nome;

        public int idade;

        public int armadura = 200;

        public string nomeArmadura;

        public string ia;

        //Metodos:
        public void AtacarEnergia()
        {
            Console.WriteLine($"O {nome} atacou com energia");
        }

        public void AtacarSoco()
        {
            Console.WriteLine($"O {nome} atacou com um poderoso soco");
        }
        public void DefenderEnergia()
        {
            Console.WriteLine($"O {nome} defendeu energia!");

            armadura = (armadura + 40);
        }
        public void DefenderSoco()
        {
            Console.WriteLine($"O {nome} defendeu soco!");

            armadura = (armadura + 20);
            
        }
        public void RestaurarArmadura()
        {
            Console.WriteLine($"O {nome} restaurou a armadura!");  

            armadura = (armadura + 15);         
        }

        public void DanoEnergia(){
            armadura = (armadura - 40);
        }

        public void DanoSoco(){
            armadura = (armadura - 20);
        }
    }
}