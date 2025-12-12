using MediatR;
using Mokeb.Application.Contracts;
using ResponseModel = Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingIncomingOrAcceptedCaravansRequestsByDate.GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingIncomingOrAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQueryHandler : IRequestHandler<GettingIncomingOrAcceptedCaravansRequestsByDateQuery, ResponseModel>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public GettingIncomingOrAcceptedCaravansRequestsByDateQueryHandler(ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<ResponseModel> Handle(GettingIncomingOrAcceptedCaravansRequestsByDateQuery request, CancellationToken cancellationToken)
        {
            var requests = await _caravanPrincipalRepository.GetAcceptedOrOnTheWayCaravansRequestsByDateAsync(request.Date, cancellationToken);

            return ResponseModel.Succeed()
                                .WithRequests(requests.ToGettingAcceptedRequestResponseDto());
        }
    }
}
