using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingAcceptedCaravansRequestsByDateQueryResponse
    {
        public static GettingAcceptedCaravansRequestsByDateQueryResponse SucceededResponse(List<GettingAcceptedRequestsResponseDto> response)
        {
            return new GettingAcceptedCaravansRequestsByDateQueryResponse()
            {
                Response = response,
            };
        }

        public List<GettingAcceptedRequestsResponseDto> Response { get; set; }
    }
}
