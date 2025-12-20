using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.SearchInCaravans
{
    public class SearchInCaravansCommandResponse
    {
        public static SearchInCaravansCommandResponse Response()
        {
            return new SearchInCaravansCommandResponse();
        }
        public SearchInCaravansCommandResponse WithResponse(List<CaravanPrincipalDto> caravanPrincipals)
        {
            CaravanPrincipals = caravanPrincipals;
            return this;
        }
        public List<CaravanPrincipalDto> CaravanPrincipals { get; set; }
    }
}
