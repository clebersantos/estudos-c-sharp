using System;

namespace Db
{
    public class Conexao
    {
        private static readonly string server = "127.0.0.1,1433";
        private static readonly string database = "Financeiro";
        private static readonly string username = "SA";
        private static readonly string password = "estudo@123456";

        public static string GetStringConnection() => $"Server={server};Database={database};User Id={username};Password={password}";


    }

}
