using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface IIndividualRepository
    {
        Task<bool> IsIndividualByIdenticalInformationExists(string username, string nationalCode, string passportNumber, CancellationToken ct);
        Task<IndividualPrincipal> GetIndividualAsync(string username, string password, CancellationToken ct);
        void AddIndividualPrincipal(IndividualPrincipal individualPrincipal);
    }
}
