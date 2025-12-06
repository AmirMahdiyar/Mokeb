using Mokeb.Domain.Model.Base;

namespace Mokeb.Application.Contracts
{
    public interface IJwsService
    {
        Task<string> CreateJwsToken(Principal individualPrincipal, CancellationToken cancellationToken);
        Task DeleteJwsToken(Principal individualPrincipal, string jwsToken);

    }
}
