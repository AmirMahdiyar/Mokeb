using MediatR;
using Mokeb.Application.CommandHandler.Base;

namespace Mokeb.Application.CommandHandler.CaravanPrincipalSignIn
{
    public class CaravanPrincipalSignInCommand : CommandBase, IRequest<CaravanPrincipalSignInCommandResponse>
    {

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
