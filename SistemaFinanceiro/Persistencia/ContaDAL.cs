using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Modelo;

namespace Persistencia
{
    public class ContaDAL
    {
       
        private SqlConnection conn;
        private CategoriaDAL categoria;

        public ContaDAL(SqlConnection conn)
        {
            this.conn = conn;
            string strConn = Db.Conexao.GetStringConnection();
            this.categoria = new CategoriaDAL(new SqlConnection(strConn));
        }

        public List<Conta> ListarTodos(string data_incial = "", string data_final = "")
        {
            List<Conta> contas = new List<Conta>();

            StringBuilder sql = new StringBuilder("Select ");
            sql.Append("con.id, con.descricao, con.valor, con.tipo, con.data_vencimento, cat.nome, cat.id as categoria_id ");
            sql.Append("FROM ");
            sql.Append("contas con inner join categorias cat ");
            sql.Append("on con.categoria_id = cat.id ");

            bool hasFiltro = !data_incial.Equals("") && !data_final.Equals("");
            if (hasFiltro)
            {
                sql.Append("where con.data_vencimento between ");
                sql.Append("@data_inicial and @data_final ");
            }


            //var command = new SqlCommand("select con.id, con.descricao, con.valor, con.tipo, con.data_vencimento, cat.nome, cat.id as categoria_id from contas con inner join categorias cat on con.categoria_id = cat.id", this.conn);
            var command = new SqlCommand(sql.ToString(), this.conn);

            if (hasFiltro)
            {
                command.Parameters.AddWithValue("@data_inicial", data_incial);
                command.Parameters.AddWithValue("@data_final", data_final);
            }
            this.conn.Open();

            using(SqlDataReader rd = command.ExecuteReader())
            {
                while(rd.Read())
                {
                    Conta conta = new Conta()
                    {
                        Id = Convert.ToInt32(rd["id"].ToString()),
                        Descricao = rd["descricao"].ToString(),
                        Tipo = Convert.ToChar(rd["tipo"].ToString()),
                        DataVencimento = DateTime.Parse(rd["data_vencimento"].ToString()),
                        Valor = Convert.ToDouble(rd["valor"].ToString())
                    };
                    int id_categoria = Convert.ToInt32(rd["id"].ToString());
                    conta.Categoria = this.categoria.GetCategoria(id_categoria);

                    contas.Add(conta);
                }
            }
            this.conn.Close();
            return contas;
        }

        public void Salvar(Conta conta)
        {
            if(conta.Id == null)
            {
                Cadastrar(conta);
            } else
            {
                Editar(conta);
            }
        }

        void Cadastrar(Conta conta)
        {
            this.conn.Open();
            SqlCommand command = this.conn.CreateCommand();
            command.CommandText = "insert into contas (descricao, tipo, valor, data_vencimento, categoria_id) values (@descricao, @tipo, @valor, @data_vencimento, @categoria_id)";
            command.Parameters.AddWithValue("@descricao", conta.Descricao);
            command.Parameters.AddWithValue("@tipo", conta.Tipo);
            command.Parameters.AddWithValue("@valor", conta.Valor);
            command.Parameters.AddWithValue("@data_vencimento", conta.DataVencimento);
            command.Parameters.AddWithValue("@categoria_id", conta.Categoria.Id);
            command.ExecuteNonQuery();
            this.conn.Close();
        }

        void Editar(Conta conta)
        {

        }
    }
}
