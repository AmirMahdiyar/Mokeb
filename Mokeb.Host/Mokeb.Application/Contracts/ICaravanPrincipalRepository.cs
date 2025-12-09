using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface ICaravanPrincipalRepository
    {
        void AddCaravan(CaravanPrincipal caravanPrincipal);
        Task<bool> IsCaravanByIdenticalInformationExistsAsync(string username, string nationalCode, string passportNumber, CancellationToken ct);
        Task<CaravanPrincipal> GetCaravanAsync(string username, string password, CancellationToken ct);
    }
}
