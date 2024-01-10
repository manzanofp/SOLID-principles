namespace SOLID._1_SRP.SRP_JeitoCerto.Services
{
    // essa classe está sendo responsável apenas por validar o cpf recebido! assim tendo apenas uma unica responsabilidade
    public static class CPFServices
    {
        public static bool IsValid (string cpf)
        {
            return cpf.Length == 11;
        }
    }
}
