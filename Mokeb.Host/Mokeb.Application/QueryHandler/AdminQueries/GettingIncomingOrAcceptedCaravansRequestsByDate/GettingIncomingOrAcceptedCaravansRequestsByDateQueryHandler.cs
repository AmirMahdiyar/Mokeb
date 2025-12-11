using MediatR;
using Mokeb.Application.Contracts;
using ResponseModel = Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate.GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQueryHandler : IRequestHandler<GettingIncomingOrAcceptedCaravansRequestsByDateQuery, GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse>
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
