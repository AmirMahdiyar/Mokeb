using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface IIndividualRepository
    {
        Task<bool> IsIndividualByIdenticalInformationExists(string username, string nationalCode, string passportNumber, CancellationToken ct);
        Task<IndividualPrincipal> GetIndividualByUsernameAsync(string username, string password, CancellationToken ct);
        Task<IndividualPrincipal> GetIndividualByIdAsync(Guid Id, CancellationToken ct);
        void AddIndividualPrincipal(IndividualPrincipal individualPrincipal);
        Task<List<Request>> GettingRequestsByDateAsync(DateOnly date, CancellationToken ct);
    }
}
