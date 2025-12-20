using MediatR;
using Mokeb.Application.Contracts;
using ResponseModel = Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.SearchInCaravans.SearchInCaravansCommandResponse;
namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.SearchInCaravans
{
    public class SearchInCaravansCommandHandler : IRequestHandler<SearchInCaravansCommand, SearchInCaravansCommandResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanPrincipalRepository;

        public SearchInCaravansCommandHandler(ICaravanPrincipalRepository caravanPrincipalRepository)
        {
            _caravanPrincipalRepository = caravanPrincipalRepository;
        }

        public async Task<SearchInCaravansCommandResponse> Handle(SearchInCaravansCommand request, CancellationToken cancellationToken)
        {
            var listOfCaravans = await _caravanPrincipalRepository.SearchForCaravansByNameOrFamilyName(request.Input, cancellationToken);
            return ResponseModel
                .Response()
                .WithResponse(listOfCaravans);
        }
    }
}
