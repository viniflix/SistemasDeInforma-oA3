using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_do_HotelA3
{
    static class ConexaoDB
    {
        private const string servidor = "localhost";
        private const string bancoDados = "hoteldb";
        private const string usuario = "root";
        private const string senha = "Senha123@";

        static public string conexaoDB = $"server={servidor}; user={usuario}; database={bancoDados}; password={senha}";

    }
         
}
