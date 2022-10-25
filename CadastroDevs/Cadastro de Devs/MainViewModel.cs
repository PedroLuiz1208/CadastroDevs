using Cadastro_de_Devs.Devs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_Devs
{
    public class MainViewModel
    {
        public List<Dev> Desenvolvedores = new List<Dev>();

        private Dev _desenvolvedor = new Dev();

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
            return Desenvolvedores.FirstOrDefault(x => x.name.Contains(name));
        }

        public async Task Alterar()
        {
            DevServico auxDev = new DevServico();
            await auxDev.AlteraDev(Desenvolvedor);
        }

        public async Task Incluir()
        {
            Desenvolvedor.id = Desenvolvedores.OrderBy(x => x.id).LastOrDefault().id + 1;
            Desenvolvedor.createdAt = DateTime.Now;
            DevServico auxDev = new DevServico();
            await auxDev.IncluirDev(Desenvolvedor);
        }

        public async Task<string> Ajustar(string email)
        {
            if (!email.Contains("@"))
                return email;

            return email.Split('@')[0] + "@developer.com.br";
        }
        public async Task Ajustar()
        {
            Desenvolvedores?.ForEach(async x =>
            {
                DevServico auxDev = new DevServico();
                if (x.email.Contains("@developer.com.br"))
                    return;
                x.email = await Ajustar(x.email);
                await auxDev.AlteraDev(x);
            });
        }
    }
}
