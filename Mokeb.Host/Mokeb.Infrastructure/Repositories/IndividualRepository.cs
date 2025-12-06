using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Domain.Model.Entities;
using Mokeb.Infrastructure.Context;

namespace Mokeb.Infrastructure.Repositories
{
    public class IndividualRepository : IIndividualRepository
    {
        private readonly DbSet<IndividualPrincipal> _context;

        public IndividualRepository(MokebDbContext context)
        {
            _context = context.Set<IndividualPrincipal>();
        }

        public void AddIndividualPrincipal(IndividualPrincipal individualPrincipal)
        {
            _context.Add(individualPrincipal);
        }

        public async Task<bool> IsIndividualByIdenticalInformationExists(string username, string nationalNumber, string passportNumber, CancellationToken ct)
        {
            return await _context.AnyAsync(x => x.IdentityInformation.Username == username || x.NationalNumber == nationalNumber || x.PassportNumber == passportNumber, ct);
        }
    }
}
