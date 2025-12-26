using MediatR;
using Mokeb.Application.Contracts;
using Mokeb.Application.Exceptions;
using Mokeb.Application.QueryHandler.AdminQueries;
using Mokeb.Domain.Model.Entities;
using ResponseModel = Mokeb.Application.QueryHandler.CaravanRequests.CaravanRequestsQueryResponse;
namespace Mokeb.Application.QueryHandler.CaravanRequests
{
    public class CaravanRequestsQueryHandler : IRequestHandler<CaravanRequestsQuery, CaravanRequestsQueryResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public CaravanRequestsQueryHandler(ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<CaravanRequestsQueryResponse> Handle(CaravanRequestsQuery request, CancellationToken cancellationToken)
        {
            var caravan = await GetPrincipal(request.CaravanId, cancellationToken);
            return ResponseModel
                .Response()
                .WithRequests(caravan.Requests.ToRequestDto());
        }
        #region Private Methods
        private async Task<CaravanPrincipal> GetPrincipal(Guid caravanId, CancellationToken ct)
        {
            var caravan = await _caravanPrincipalRepository.GetCaravanByIdAsync(caravanId, ct);
            if (caravan is null)
                throw new PrincipalNotFoundApplicationException();
            return caravan;
        }
        #endregion
    }
}
