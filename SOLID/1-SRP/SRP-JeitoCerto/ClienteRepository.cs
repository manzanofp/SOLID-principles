using System.Data.SqlClient;
using System.Net.Mail;

namespace SOLID._1_SRP.SRP_JeitoCerto.Repository
{
    //Repository tem como responsabilidade ser a camada de acesso ao banco de dados contendo as suas operações, CRUD e etc...
    public class ClienteRepository
    {
        public string AdicionarCliente(Cliente cliente)
        {
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();
                cn.ConnectionString = "MinhaConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL, CPF, DATACADASTRO) VALUES (@nome, @email, @cpf)";

                cmd.Parameters.AddWithValue("Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("email", cliente.Email);
                cmd.Parameters.AddWithValue("cpf", cliente.CPF);
                cmd.Parameters.AddWithValue("dataCadastro", cliente.DataCadastro);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Cliente cadastrado com sucesso!";
        }
    }
}
