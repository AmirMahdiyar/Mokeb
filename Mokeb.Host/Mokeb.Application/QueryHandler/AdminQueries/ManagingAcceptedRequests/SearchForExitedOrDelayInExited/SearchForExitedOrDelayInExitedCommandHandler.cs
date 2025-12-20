using MediatR;
using Mokeb.Application.Contracts;
using ResponseModel = Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForExitedOrDelayInExited.SearchForExitedOrDelayInExitedCommandResponse;
namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForExitedOrDelayInExited
{
    public class SearchForExitedOrDelayInExitedCommandHandler : IRequestHandler<SearchForExitedOrDelayInExitedCommand, SearchForExitedOrDelayInExitedCommandResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;
        private readonly IIndividualRepository _individualRepository;

        public SearchForExitedOrDelayInExitedCommandHandler(ICaravanPrincipalRepository caravanPrincipalRepository, IIndividualRepository individualRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
            _individualRepository = individualRepository;
        }

        public async Task<SearchForExitedOrDelayInExitedCommandResponse> Handle(SearchForExitedOrDelayInExitedCommand request, CancellationToken cancellationToken)
        {
            var caravanRequests = await _caravanPrincipalRepository.SearchInExitedOrDelayInExitRequestWithNameOrFamilyName(request.Date, request.Input, cancellationToken);
            var individualRequests = await _individualRepository.SearchInExitedOrDelayInExitRequestWithNameOrFamilyName(request.Date, request.Input, cancellationToken);
            var requests = caravanRequests.Concat(individualRequests).ToList();
            return ResponseModel
                .SucceededResponse(requests.ToGettingOutGoingOrAcceptedRequestResponseDto());
        }
    }
}
