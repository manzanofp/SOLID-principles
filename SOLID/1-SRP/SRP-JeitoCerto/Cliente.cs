using SOLID._1_SRP.SRP_JeitoCerto.Services;

namespace SOLID._1_SRP.SRP_JeitoCerto
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool IsValid()
        {
            return EmailService.IsValid(Email) && CPFServices.IsValid(CPF);
        }
    }
}