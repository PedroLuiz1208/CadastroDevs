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

        private Dev _desenvolvedor;

        public Dev Desenvolvedor
        {
            get { return _desenvolvedor; }
            set { _desenvolvedor = value; }
        }

        public MainViewModel()
        {
            DevServico auxDev = new DevServico();
            Desenvolvedores = auxDev.BuscaDevs().Result;
        }

        public async Task<bool> BuscarDev(string name)
        {
            if (Desenvolvedores == null || Desenvolvedores.Count == 0)
                return false;

            var dev = await FindDev(name);

            if (dev != null)
                Desenvolvedor = dev;
            return true;
        }

        public async Task<Dev> FindDev(string name)
        {
            return Desenvolvedores.FirstOrDefault(x => x.Name.Contains(name));
        }

        public async Task Alterar()
        {
            DevServico auxDev = new DevServico();
            await auxDev.AlteraDev(Desenvolvedor);
        }
    }
}
