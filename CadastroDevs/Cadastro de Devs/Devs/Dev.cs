using System;

namespace Cadastro_de_Devs.Devs
{
    public class Dev
    {
        public long id { get; set; }

        public string name { get; set; }

        public string avatar { get; set; }

        public string squad { get; set; }

        public string login { get; set; }

        public string email { get; set; }

        public DateTime createdAt { get; set; }

        /*public static bool Validate(Dev dev)
        {
            long lParse;
            if (dev.email.Contains("@"))
                return false;

            return true;
        }*/

    }
}
