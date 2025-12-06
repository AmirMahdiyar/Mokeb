using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface IJwsService
    {
        Task<string> CreateJwsToken(IndividualPrincipal individualPrincipal, CancellationToken cancellationToken);
        Task DeleteJwsToken(IndividualPrincipal individualPrincipal, string jwsToken);

    }
}
