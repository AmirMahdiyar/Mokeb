using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Domain.Model.Entities;
using Mokeb.Infrastructure.Context;

namespace Mokeb.Infrastructure.Repositories
{
    public class CaravanRepository : ICaravanPrincipalRepository
    {
        private readonly DbSet<CaravanPrincipal> _principal;

        public CaravanRepository(MokebDbContext principal)
        {
            _principal = principal.Set<CaravanPrincipal>();
        }

        public void AddCaravan(CaravanPrincipal caravanPrincipal)
        {
            _principal.Add(caravanPrincipal);
        }

        public async Task<bool> IsCaravanByIdenticalInformationExists(string username, string nationalNumber, string passportNumber, CancellationToken ct)
        {
            return await _principal.AnyAsync(x => x.IdentityInformation.Username == username || x.NationalNumber == nationalNumber || x.PassportNumber == passportNumber, ct);
        }
    }
}
