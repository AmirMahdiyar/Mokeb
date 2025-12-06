using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface ICaravanPrincipalRepository
    {
        void AddCaravan(CaravanPrincipal caravanPrincipal);
        Task<bool> IsCaravanByIdenticalInformationExists(string username, string nationalNumber, string passportNumber, CancellationToken ct);
    }
}
