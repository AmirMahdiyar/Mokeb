using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingPrincipalInformation
{
    public class GettingPrincipalInformationQueryResponse
    {
        public static GettingPrincipalInformationQueryResponse Response(PrincipalDto principal)
        {
            return new GettingPrincipalInformationQueryResponse() { Principal = principal };
        }
        public PrincipalDto Principal { get; set; }
    }
}
