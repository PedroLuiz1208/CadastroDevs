using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Cadastro_de_Devs.Devs;

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
            return Desenvolvedores.FirstOrDefault(x => x.Name.Contains(name));
        }

        public async Task Alterar()
        {
            DevServico auxDev = new DevServico();
            await auxDev.AlteraDev(Desenvolvedor);
        }

        public async Task Incluir()
        {
            Desenvolvedor.Id = Desenvolvedores.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            Desenvolvedor.CreatedAt = DateTime.Now;
            DevServico auxDev = new DevServico();
            await auxDev.IncluirDev(Desenvolvedor);
        }

        public async Task<string> Ajustar(string email)
        {
            if (!email.Contains("@"))
                return email;

            return email.Split('@')[0] + "@prosoft.com.br";
        }
        public async Task Ajustar()
        {
            Desenvolvedores?.ForEach(async x =>
            {
                DevServico auxDev = new DevServico();
                x.Email = await Ajustar(x.Email);
                await auxDev.AlteraDev(x);
            });
        }
    }
}
