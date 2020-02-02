using System;
using System.Globalization;
using System.Text;
using static System.Console;
namespace AvancandoCSharp
{
   
    public enum TipoCliente
    {
        PessoaFisica, PessoaJuridica, OrgaoPublico, ONG
    }

    public enum StatusPedido
    {
        AguardandoPagamento = 1,
        Aprovado = 2,
        Enviado = 3
    }

    // nao faz heranca, pode fazer implementacao de interface, ocupa menos espaco
    public struct Cliente
    {
        public int matricula;
        public string nome;
        public string email;

        public void digaOi()
        {
            WriteLine($" oi {this.nome}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //Carro carro = new Carro();
            //carro.Marca = "Fusca";
            //carro.AnoFabricacao = 1998;

            //WriteLine($"Eu tenho um {carro.Marca} fabricado em {carro.AnoFabricacao}");
            //carro.buzinar();
            //carro.virar("D");
            //StatusPedido.AguardandoPagamento;

            //string frase = "Hoje à noite, sem luz, decidi xeretar a quinta gaveta de vovô: achei lingüiça, pão e fubá";
            //string[] partes = frase.Split(",");

            //for(var i = 0; i < partes.Length; i++)
            //{
            //    string parte = partes[i].Trim();
            //bool possuiX = parte.Contains("x");
            //WriteLine($"Possui X {possuiX}");
            //int posicaoInicial = parte.IndexOf("x");
            //int posicaoFinal = 10;

            //string sub = frase.Substring(posicaoInicial, posicaoFinal);
            //WriteLine(parte.ToLower());
            //WriteLine(parte.ToUpper());
            //WriteLine(parte.Replace("Xeretar", "investigar"));
            //WriteLine(parte.Replace("Xeretar", "investigar", true , CultureInfo.CurrentCulture));

            //};
            //string nome = "Cleber Santos";
            //int idade = 31;
            //double rendimento = 80000.00;
            //DateTime dataCadastro = new DateTime(2020, 02, 01);


            //string str = "O Cliente {0} tem {1} anos de idade e tem rendimento de {2:c}";
            //str += " e é cliente desde {3:dd/MM/yyyy}";
            //string frase = String.Format(str, nome, idade, rendimento, dataCadastro);
            //StringBuilder builder = new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            //builder.Append("Nunc tempus leo sit amet placerat tempus.");
            //builder.AppendLine("Morbi accumsan mauris diam, nec porta lorem interdum sed.");
            //builder.Append("Pellentesque urna lacus, porta in lobortis volutpat, ultrices non turpis.");
            //builder.AppendFormat(nome, idade, rendimento, dataCadastro);

            //WriteLine("{0}", DateTime.Now.AddDays(2));
            //WriteLine("{0}", DateTime.Now.AddDays(-2));
            //DateTime data = new DateTime(2018, 04, 02, 08, 30, 00);
            //WriteLine(data);

            //string dataDoBanco = "2018-04-02 08:30:00";

            //DateTime data = DateTime.Parse(dataDoBanco);
            //string horaFormatada = String.Format("{0:HH}h{0:mm}", data);
            //string dataFormatada = String.Format("{0:dd/MM/yyyy}", data);
            //WriteLine(horaFormatada);


            ReadLine();


            //WriteLine(builder);
        }
    }

    class Carro
    {
        private string _marca;
        public string Marca
        {
            get => _marca;
            set => _marca = value.Equals("Fusca") ? "OUTRO CARRO" : value;

            //get { return _marca;  }
            //set { _marca = value; }
        }
        //public string Marca { get; set;  }

        private int _anoFabricacao;
        public int AnoFabricacao
        {
            get => _anoFabricacao;
            set => _anoFabricacao = value;
        }

        public void buzinar()
        {
            WriteLine("Bi bi");
        }

        public void virar(string direcao)
        {
            if (direcao.Equals("D"))
            {
                WriteLine("Virando a direita ...");
            }
            else
            {
                WriteLine("Virando a equerda ...");
            }
        }

    }
}
