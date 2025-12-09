using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse
    {
        public static GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse SucceededResponse(List<GettingIncomingOrAcceptedRequestsResponseDto> response)
        {
            return new GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse()
            {
                Response = response,
            };
        }

        public List<GettingIncomingOrAcceptedRequestsResponseDto> Response { get; set; }
    }
}
