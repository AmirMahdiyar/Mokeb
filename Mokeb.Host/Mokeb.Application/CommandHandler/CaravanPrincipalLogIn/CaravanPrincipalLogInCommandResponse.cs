namespace Mokeb.Application.CommandHandler.CaravanPrincipalLogIn
{
    public class CaravanPrincipalLogInCommandResponse
    {
        public static CaravanPrincipalLogInCommandResponse Response(string jws) => new() { JwsCode = jws };
        public string JwsCode { get; set; }
    }
}
