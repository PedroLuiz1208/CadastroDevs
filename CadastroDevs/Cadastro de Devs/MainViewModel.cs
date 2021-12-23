using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro_de_Devs.Devs;

namespace Cadastro_de_Devs
{
    public class MainViewModel
    {
        public List<Dev> Desenvolvedores = new List<Dev>();

        //public Dev Desenvolvedor = new Dev();
        public MainViewModel()
        {
            DevServico auxDev = new DevServico();
            Desenvolvedores = auxDev.BuscaDevs().Result;
            //Metodo onde vai buscar os devs.
        }
    }
}
