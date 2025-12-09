using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface ICaravanPrincipalRepository
    {
        void AddCaravan(CaravanPrincipal caravanPrincipal);
        Task<bool> IsCaravanByIdenticalInformationExistsAsync(string username, string nationalCode, string passportNumber, CancellationToken ct);
        Task<CaravanPrincipal> GetCaravanByUsernameAsync(string username, string password, CancellationToken ct);
        Task<CaravanPrincipal> GetCaravanByIdAsync(Guid Id, CancellationToken ct);
        Task<List<Request>> GetAcceptedOrOnTheWayCaravansRequestsByDateAsync(DateOnly date, CancellationToken ct);
        Task<List<Request>> GetAcceptedOrOutGoingCaravansRequestsByDateAsync(DateOnly date, CancellationToken ct);


    }
}
