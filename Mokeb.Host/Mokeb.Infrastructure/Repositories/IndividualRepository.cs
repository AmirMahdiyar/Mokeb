using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Domain.Model.Entities;
using Mokeb.Infrastructure.Context;

namespace Mokeb.Infrastructure.Repositories
{
    public class IndividualRepository : IIndividualRepository
    {
        private readonly DbSet<IndividualPrincipal> _individual;

        public IndividualRepository(MokebDbContext context)
        {
            _individual = context.Set<IndividualPrincipal>();
        }

        public void AddIndividualPrincipal(IndividualPrincipal individualPrincipal)
        {
            _individual.Add(individualPrincipal);
        }

        public async Task<IndividualPrincipal> GetIndividualAsync(string username, string password, CancellationToken ct)
        {
            return await _individual.SingleOrDefaultAsync(x => x.IdentityInformation.Username == username && x.IdentityInformation.Password == password, ct);
        }

        public async Task<bool> IsIndividualByIdenticalInformationExists(string username, string nationalNumber, string passportNumber, CancellationToken ct)
        {
            return await _individual.AnyAsync(x => x.IdentityInformation.Username == username || x.NationalNumber == nationalNumber || x.PassportNumber == passportNumber, ct);
        }
    }
}
