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

        public Dev _desenvolvedor;

        public Dev Desenvolvedor
        {
            get { return _desenvolvedor; }
            set { _desenvolvedor = value;}
        }

        public MainViewModel()
        {
            DevServico auxDev = new DevServico();
            Desenvolvedores = auxDev.BuscaDevs().Result;
        }

        private void BuscarDev()
        {

        }
    }
}
