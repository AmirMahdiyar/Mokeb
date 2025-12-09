using MediatR;
using Mokeb.Application.Contracts;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingAcceptedCaravansRequestsByDateQueryHandler : IRequestHandler<GettingAcceptedCaravansRequestsByDateQuery, GettingAcceptedCaravansRequestsByDateQueryResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public GettingAcceptedCaravansRequestsByDateQueryHandler(ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<GettingAcceptedCaravansRequestsByDateQueryResponse> Handle(GettingAcceptedCaravansRequestsByDateQuery request, CancellationToken cancellationToken)
        {
            var requests = await _caravanPrincipalRepository.GettingRequestsByDateAsync(request.Date, cancellationToken);
            return GettingAcceptedCaravansRequestsByDateQueryResponse.SucceededResponse(requests.ToGettingAcceptedRequestResponseDto());
        }
    }
}
