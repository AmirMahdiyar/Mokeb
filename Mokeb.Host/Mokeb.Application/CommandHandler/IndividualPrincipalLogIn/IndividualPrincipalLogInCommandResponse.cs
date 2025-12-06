namespace Mokeb.Application.CommandHandler.IndividualPrincipalLogIn
{
    public class IndividualPrincipalLogInCommandResponse
    {
        public static IndividualPrincipalLogInCommandResponse Response(string jws) => new() { JwsCode = jws };
        public string JwsCode { get; set; }
    }
}
