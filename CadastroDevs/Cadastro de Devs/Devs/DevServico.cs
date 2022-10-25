using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Text.Json;
using System.Data;

namespace Cadastro_de_Devs.Devs
{
    public class DevServico
    {
        public DevServico() { }

        public async Task<List<Dev>> BuscaDevs()
        {
            List<Dev> devs = new List<Dev>();   
            HttpClient client = new HttpClient();
            
            try
            {
                devs = await BuscaDevsAsync(client);
                return devs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Busccar Desenvolvedores");
                return devs;
            }
        }

        public async Task<List<Dev>> BuscaDevsAsync(HttpClient client)        
        {        
            client.BaseAddress = new Uri("Default");

            HttpResponseMessage response = client.GetAsync("/Dev").Result; //HttpResponseMessage response = await client.GetAsync("/Dev");
            var usuarios = await response.Content.ReadAsStringAsync();
   
            var listDev = JsonConvert.DeserializeObject<List<Dev>>(usuarios).AsEnumerable().ToList();
            return listDev;
        }

        public async Task AlteraDev(Dev Desenvolvedor)
        {
            try
            {
                HttpClient client = new HttpClient();
                await AlteraDevAsyn(client, Desenvolvedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Alterar Desenvolvedor:{Desenvolvedor.name}");

            }
        }
        public async Task AlteraDevAsyn(HttpClient client, Dev dev)
        {
            client.BaseAddress = new Uri("Default");

            var jsonDev = JsonConvert.SerializeObject(dev);
            
            HttpContent httpContent = new StringContent(jsonDev, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"Default/DevTest/Dev/{dev.id}", httpContent).Result;

        }

        public async Task IncluirDev(Dev Desenvolvedor)
        {
            try
            {
                HttpClient client = new HttpClient();
                await IncluirDevAsyn(client, Desenvolvedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Incluir Desenvolvedor:{Desenvolvedor.name}");

            }
        }
        public async Task IncluirDevAsyn(HttpClient client, Dev dev)
        {
            client.BaseAddress = new Uri("Default/DevTest/Dev");

            var jsonDev = JsonConvert.SerializeObject(dev);

            HttpContent httpContent = new StringContent(jsonDev, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync($"Default/DevTest/Dev", httpContent).Result;

        }
    }
}
