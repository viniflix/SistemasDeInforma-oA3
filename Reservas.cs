

using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_do_HotelA3
{
    internal class Reservas
    {
        private int id;
        private string nome;
        private string email;
        private string data_reserva;
        private string pagamento;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Data_Reserva
        {
            get { return data_reserva; }
            set { data_reserva = value; }
        }

        public string Pagamento
        {
            get { return pagamento; }
            set { pagamento = value; }
        }

        //Metodo de cadastro no banco
        public bool novaReserva()
        {
            try
            {
                MySqlConnection ConectaDB = new MySqlConnection(ConexaoDB.conexaoDB);
                ConectaDB.Open();

                string insert = $" insert into reservas (nome, email, data_reserva, pagamento) values ('{Nome}', '{Email}', '{Data_Reserva}', '{Pagamento}')";

                MySqlCommand comandoSql = ConectaDB.CreateCommand();
                comandoSql.CommandText = insert;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco - Metodo novaReserva() " + ex.Message);
                return false;
            }

        }
        public bool AtualizarReserva(int id, string novoNome, string novoEmail, DateTime novaDataReserva, string novoPagamento)
        {
            try
            {
                MySqlConnection ConectaDB = new MySqlConnection(ConexaoDB.conexaoDB);
                ConectaDB.Open();

                string updateQuery = $"UPDATE reservas SET nome = '{novoNome}', email = '{novoEmail}', data_reserva = '{novaDataReserva.ToString("yyyy-MM-dd HH:mm:ss")}', pagamento = '{novoPagamento}' WHERE id = {id}";

                MySqlCommand comandoSql = new MySqlCommand(updateQuery, ConectaDB);
                int linhasAfetadas = comandoSql.ExecuteNonQuery();

                ConectaDB.Close();

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Reserva atualizada com sucesso.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nenhuma reserva encontrada para atualização.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar reserva: {ex.Message}");
                return false;
            }
        }
        public bool ExcluirReserva(int id)
        {
            try
            {
                MySqlConnection ConectaDB = new MySqlConnection(ConexaoDB.conexaoDB);
                ConectaDB.Open();

                string deleteQuery = $"DELETE FROM reservas WHERE id = {id}";

                MySqlCommand comandoSql = new MySqlCommand(deleteQuery, ConectaDB);
                int linhasAfetadas = comandoSql.ExecuteNonQuery();

                ConectaDB.Close();

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Reserva excluída com sucesso.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nenhuma reserva encontrada para exclusão.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir reserva: {ex.Message}");
                return false;
            }
        }
    }

    }


aaaaaaaaaaaaaaaaaaaaaaaa