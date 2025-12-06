using Mokeb.Application.Contracts;
using Mokeb.Infrastructure.Context;
using static Mokeb.Application.Contracts.IUnitOfWork;

namespace Mokeb.Infrastructure.unitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MokebDbContext _context;

        public UnitOfWork(MokebDbContext context)
        {
            _context = context;
        }

        public async Task<SavingResult> Commit(CancellationToken ct)
        {
            var savedChangedStateCount = await _context.SaveChangesAsync(ct);
            return new SavingResult { ChangesCount = savedChangedStateCount };
        }
    }
}
