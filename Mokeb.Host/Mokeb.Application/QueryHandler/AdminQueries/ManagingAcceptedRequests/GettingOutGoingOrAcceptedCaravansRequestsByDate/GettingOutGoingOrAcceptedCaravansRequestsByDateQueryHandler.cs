using MediatR;
using Mokeb.Application.Contracts;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingOutGoingOrAcceptedCaravansRequestsByDate
{
    public class GettingOutGoingOrAcceptedCaravansRequestsByDateQueryHandler : IRequestHandler<GettingOutGoingOrAcceptedCaravansRequestsByDateQuery, GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public GettingOutGoingOrAcceptedCaravansRequestsByDateQueryHandler(ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse> Handle(GettingOutGoingOrAcceptedCaravansRequestsByDateQuery request, CancellationToken cancellationToken)
        {
            var requests = await _caravanPrincipalRepository.GetAcceptedOrOutGoingCaravansRequestsByDateAsync(request.Date, cancellationToken);
            return GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse.SucceededResponse(requests.ToGettingOutGoingOrAcceptedRequestResponseDto());
        }
    }
}
