using Modelo;
using System;
using System.Collections.Generic;
using static System.Console;
using Persistencia;
using System.Data.SqlClient;
using ConsoleTables;

namespace SistemaFinanceiro
{
    class Program
    {
        private List<Conta> contas;
        private List<Categoria> categorias;

        private ContaDAL conta;
        private CategoriaDAL categoria;
        
        public Program()
        {
            string strConn = Db.Conexao.GetStringConnection();
            this.conta = new ContaDAL(new SqlConnection(strConn));
            this.categoria = new CategoriaDAL(new SqlConnection(strConn));
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            ConsoleTable table;
            int opc;
            do
            {
                Title = "CONTROLE FINANCEIRO SON";
                Uteis.MontaMenu();
                opc = Convert.ToInt32(ReadLine());

                if (opc < 1 || opc > 6)
                {
                    Clear();
                    BackgroundColor = ConsoleColor.Red;
                    ForegroundColor = ConsoleColor.White;
                    Uteis.MontaHeader("INFORME UMA OPÇÃO VÁLIDA!", 'X', 20);
                    ResetColor();
                } else
                {
                    Clear();

                   switch(opc)
                    {
                        case 1:
                            Title = "LISTAGEM DE CONTAS - CONTROLE FINANCEIRO";
                            Uteis.MontaHeader("LISTAGEM DE CONTAS");
                            ListarContas(p);
                            ReadLine();
                            Clear();
                            
                            break;
                        case 2:
                            Title = "NOVA CONTA - CONTROLE FINANCEIRO";
                            Uteis.MontaHeader("CADASTRANDO UMA NOVA CONTA");
                            CadastrarConta(p);
                            ReadLine();
                            Clear();

                            break;
                        case 3:
                            Title = "EDITAR CONTAS - CONTROLE FINANCEIRO";
                            Uteis.MontaHeader("EDITANTO UMA CONTA");
                            ReadLine();
                            Clear();
                            break;
                        case 4:
                            Title = "EXCLUIR CONTA - CONTROLE FINANCEIRO";
                            Uteis.MontaHeader("EXCLUINDO UMA CONTA");
                            ReadLine();
                            Clear();
                            break;
                        case 5:
                            Title = "RELATÓRIO - CONTROLE FINANCEIRO";
                            Uteis.MontaHeader("FILTRAR UMA CONTA");

                            Write("Informe a data inicial (yyyy-mm-dd): ");
                            string data_inicial = ReadLine();

                            Write("Informe a data final (yyyy-mm-dd): ");
                            string data_final = ReadLine();

                            ListarContas(p, data_inicial, data_final);
                            ReadLine();
                            Clear();
                            break;

                    }
                }
            } while (opc != 6);
        }

        static void ListarContas(Program p, string data_inicial = "", string data_final = "")
        {
            p.contas = p.conta.ListarTodos(data_inicial, data_final);

            ConsoleTable table = new ConsoleTable("ID", "Descrição", "Tipo", "Valor", "Data Vencimento");

            foreach (var c in p.contas)
            {
                table.AddRow(c.Id, c.Descricao, c.Tipo.Equals('R') ? "Receber" : "Pagar", String.Format("{0:c}", c.Valor), String.Format("{0:dd/MM/yyyy}", c.DataVencimento));
            }
            table.Write();
        }

        static void CadastrarConta(Program p)
        {
            string descricao = "";
            do
            {
                Write("Informe a descricao da conta: ");
                descricao = ReadLine();

                if (descricao.Equals(""))
                {
                    BackgroundColor = ConsoleColor.Red;
                    ForegroundColor = ConsoleColor.White;
                    Uteis.MontaHeader("INFORME UMA DESCRICAO PARA A CONTA!", 'X', 20);
                    ResetColor();
                }

            } while (descricao.Equals(""));

            Write("Informe o valor: ");
            double valor = Convert.ToDouble(ReadLine());

            Write("Informe o Tipo (R para receber ou P para pagar): ");
            char tipo = Convert.ToChar(ReadLine());


            Write("Informe a data de vencimento (dd/mm/aaaa): ");
            DateTime dataVencimento = DateTime.Parse(ReadLine());

            WriteLine("Selecine uma Categoria pela ID: \n");

            ConsoleTable table = new ConsoleTable("ID", "Nome");

            p.categorias = p.categoria.ListarTodos();

            foreach (var cat in p.categorias)
            {
                table.AddRow(cat.Id, cat.Nome);
            }
            table.Write();

            Write("Categoria: ");
            int cat_id = Convert.ToInt32(ReadLine());
            Categoria categoria_cadastro = p.categoria.GetCategoria(cat_id);


            Conta conta = new Conta()
            {
                Descricao = descricao,
                Valor = valor,
                Tipo = tipo,
                DataVencimento = dataVencimento,
                Categoria = categoria_cadastro
            };

            p.conta.Salvar(conta);

            BackgroundColor = ConsoleColor.DarkGreen;
            ForegroundColor = ConsoleColor.White;
            Uteis.MontaHeader("Conta Salva com sucesso!", '+', 20);
            ResetColor();
        }
    }
}
