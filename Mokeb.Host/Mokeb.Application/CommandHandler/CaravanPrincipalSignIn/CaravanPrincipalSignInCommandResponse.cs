namespace Mokeb.Application.CommandHandler.CaravanPrincipalSignIn
{
    public class CaravanPrincipalSignInCommandResponse
    {
        public static CaravanPrincipalSignInCommandResponse Succeeded => new() { Success = true };
        public bool Success { get; set; }
    }
}
