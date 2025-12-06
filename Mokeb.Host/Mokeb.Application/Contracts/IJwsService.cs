using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface IJwsService
    {
        Task<string> CreateJwsToken(Principal principal, CancellationToken cancellationToken);
        Task<string> CreateJwsTokenForAdmin(Admin admin, CancellationToken cancellationToken);

        Task DeleteJwsToken(Principal individualPrincipal, string jwsToken);
        Task DeleteJwsTokenForAdmin(Admin admin, string jwsToken);


    }
}
