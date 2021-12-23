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
            Uri usuarioUri;

            client.BaseAddress = new Uri("https://61a170e06c3b400017e69d00.mockapi.io/DevTest");

            HttpResponseMessage response = client.GetAsync("/Dev").Result;
            usuarioUri = response.Headers.Location;

            var usuarios = response.Content.ReadAsStringAsync().Result;
   
            var listDev = JsonConvert.DeserializeObject<List<Dev>>(usuarios).AsEnumerable().ToList();
            return listDev;
        }
    }
}
