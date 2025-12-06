using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.Contracts
{
    public interface IIndividualRepository
    {
        Task<bool> IsIndividualByIdenticalInformationExists(string username, string nationalNumber, string passportNumber, CancellationToken ct);
        void AddIndividualPrincipal(IndividualPrincipal individualPrincipal);
    }
}
