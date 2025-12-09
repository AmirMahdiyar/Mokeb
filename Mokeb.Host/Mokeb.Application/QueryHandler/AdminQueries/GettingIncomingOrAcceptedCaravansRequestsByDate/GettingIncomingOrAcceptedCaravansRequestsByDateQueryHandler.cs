using MediatR;
using Mokeb.Application.Contracts;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQueryHandler : IRequestHandler<GettingIncomingOrAcceptedCaravansRequestsByDateQuery, GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public GettingIncomingOrAcceptedCaravansRequestsByDateQueryHandler(ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse> Handle(GettingIncomingOrAcceptedCaravansRequestsByDateQuery request, CancellationToken cancellationToken)
        {
            var requests = await _caravanPrincipalRepository.GetAcceptedOrOnTheWayCaravansRequestsByDateAsync(request.Date, cancellationToken);
            return GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse.SucceededResponse(requests.ToGettingAcceptedRequestResponseDto());
        }
    }
}
