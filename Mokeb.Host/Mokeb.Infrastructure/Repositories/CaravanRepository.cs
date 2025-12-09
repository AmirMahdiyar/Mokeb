using Microsoft.EntityFrameworkCore;
using Mokeb.Application.Contracts;
using Mokeb.Domain.Model.Entities;
using Mokeb.Domain.Model.Enums;
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

        public async Task<CaravanPrincipal> GetCaravanByUsernameAsync(string username, string password, CancellationToken ct)
        {
            return await _principal.SingleOrDefaultAsync(x => x.IdentityInformation.Username == username && x.IdentityInformation.Password == password, ct);
        }

        public async Task<bool> IsCaravanByIdenticalInformationExistsAsync(string username, string nationalCode, string passportNumber, CancellationToken ct)
        {
            return await _principal.AnyAsync(x => x.IdentityInformation.Username == username || x.NationalCode == nationalCode || x.PassportNumber == passportNumber, ct);
        }

        public async Task<List<Request>> GetAcceptedOrOnTheWayCaravansRequestsByDateAsync(DateOnly date, CancellationToken ct)
        {
            return await _principal
                .Include(x => x.IdentityInformation)
                .Include(x => x.Requests)
                .ThenInclude(x => x.Travelers)
                .SelectMany(x => x.Requests)
                .Where(x => DateOnly.FromDateTime(x.EnterTime) == date && (x.State == State.Accepted || x.State == State.DelayInEntrance || x.State == State.Entered))
                .ToListAsync(ct);
        }

        public async Task<CaravanPrincipal> GetCaravanByIdAsync(Guid Id, CancellationToken ct)
        {
            return await _principal.SingleOrDefaultAsync(x => x.Id == Id, ct);
        }

        public async Task<List<Request>> GetAcceptedOrOutGoingCaravansRequestsByDateAsync(DateOnly date, CancellationToken ct)
        {
            return await _principal
                .Include(x => x.IdentityInformation)
                .Include(x => x.Requests)
                .ThenInclude(x => x.Travelers)
                .SelectMany(x => x.Requests)
                .Where(x => DateOnly.FromDateTime(x.ExitTime) == date && (x.State == State.Accepted || x.State == State.DelayInExit || x.State == State.Exited))
                .ToListAsync(ct);
        }
    }
}
