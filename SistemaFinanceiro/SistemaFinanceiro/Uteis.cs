using System;
using static System.Console;
namespace SistemaFinanceiro
{
    public class Uteis
    {
        public static void MontaMenu()
        {
            MontaHeader("CONTROLE FINANCEIRO - SON");
            WriteLine("Selecione uma opção abaixo: ");
            WriteLine("----------------------------");
            WriteLine("1 - Listar");
            WriteLine("2 - Cadastrar");
            WriteLine("3 - Editar");
            WriteLine("4 - Excluir");
            WriteLine("5 - Relatório");
            WriteLine("6 - Sair");
            Write("Opção: ");
        }

        public static void MontaHeader(string titulo, char cod = '=', int len = 5)
        {
            WriteLine(new string(cod, len) +" "+ titulo + " " + new string(cod, len));
        }
    }
}
