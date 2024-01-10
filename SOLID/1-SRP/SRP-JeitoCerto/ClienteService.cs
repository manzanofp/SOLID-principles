using SOLID._1_SRP.SRP_JeitoCerto.Repository;

namespace SOLID._1_SRP.SRP_JeitoCerto.Services
{

    //está classe tem como reponsabilidade Validar os dados do cliente e chamar a função que adiciona ao banco, nota-se que
    // essa classe não sabe como funciona a implementação de adicionar ao banco, apenas possui essa dependencia.
    public class ClienteService
    {

        public string AdicionarCliente(Cliente cliente)
        {
            if (!cliente.IsValid()) return "Dados inválidos";

            var clienteRepository = new ClienteRepository();
            clienteRepository.AdicionarCliente(cliente);

            EmailService.Enviar("empresa@empresa.com", cliente.Email, "Bem Vindo", "Parabéns está cadastrado");

            return "Cliente Cadastrado com sucesso";
        }
    }
}