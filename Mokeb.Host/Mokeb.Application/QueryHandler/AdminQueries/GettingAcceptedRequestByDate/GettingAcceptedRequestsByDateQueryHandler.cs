using MediatR;
using Mokeb.Application.Contracts;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate
{
    public class GettingAcceptedRequestsByDateQueryHandler : IRequestHandler<GettingAcceptedRequestsByDateQuery, GettingAcceptedRequestsByDateQueryResponse>
    {
        private readonly IIndividualRepository _individualRepository;
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public GettingAcceptedRequestsByDateQueryHandler(IIndividualRepository individualRepository, ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _individualRepository = individualRepository;
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<GettingAcceptedRequestsByDateQueryResponse> Handle(GettingAcceptedRequestsByDateQuery request, CancellationToken cancellationToken)
        {
            var caravanRequests = await _caravanPrincipalRepository.GettingRequestsByDateAsync(request.Date, cancellationToken);
            var individualRequests = await _individualRepository.GettingRequestsByDateAsync(request.Date, cancellationToken);
            var requests = caravanRequests.Concat(individualRequests).ToList();
            return GettingAcceptedRequestsByDateQueryResponse.SucceededResponse(requests.ToGettingAcceptedRequestResponseDto());
        }
    }
}
