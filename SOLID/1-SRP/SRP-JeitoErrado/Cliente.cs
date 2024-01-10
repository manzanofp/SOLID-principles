using System.Data.SqlClient;
using System.Net.Mail;

namespace SOLID._1._SRP.SRP.JeitoErrado
{
    //a classe de cliente não deve ter a responsabilidade de cadastrar o cliente no banco... ela só precisa saber se o Objeto cliente está Okay!.
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }

        //outra classe como (Repository) é necessária para adicionar o cliente no banco
        public string AdicionarCliente()
        {
            if (!Email.Contains("@"))                    //Um método de adicionar Cliente não deve ter a responsabilidade de tratar se o e-mail é valido...
                return "Cliente com e-mail Inválido";

            if (CPF.Length != 11)                        //Um método de adicionar Cliente não deve ter a responsabilidade de tratar se o CPF é valido...
                return "Cliente com CPF Inválido";

            //Essa classe não deve se adicionar ao Banco... Alguém tem que fazer isso por ela (Um repository por exemplo)!!!
            //e nem saber COMO se conecta e nem a QUAL banco se conecta.
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();
                cn.ConnectionString = "MinhaConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL, CPF, DATACADASTRO) VALUES (@nome, @email, @cpf)";

                cmd.Parameters.AddWithValue("Nome", Nome);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("cpf", CPF);
                cmd.Parameters.AddWithValue("dataCadastro", DataCadastro);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            //Essa classe também não deve saber como enviar email!! isto deveria ser um método em uma services responsável pelo envio de Email.
            var mail = new MailMessage("empresa@empresa.com", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Bem Vindo.";
            mail.Body = "Parábens! Você está cadastrado!";
            client.Send(mail);

            return "Cliente cadastrado com sucesso!";
        }
    }
}