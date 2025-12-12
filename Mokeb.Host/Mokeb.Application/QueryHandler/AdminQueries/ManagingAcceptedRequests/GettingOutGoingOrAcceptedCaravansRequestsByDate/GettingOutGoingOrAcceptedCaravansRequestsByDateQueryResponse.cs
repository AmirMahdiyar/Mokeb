using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingOutGoingOrAcceptedCaravansRequestsByDate
{
    public class GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse
    {
        public static GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse SucceededResponse(List<GettingOutGoingOrAcceptedRequestsResponseDto> response)
        {
            return new GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse()
            {
                Response = response,
            };
        }

        public List<GettingOutGoingOrAcceptedRequestsResponseDto> Response { get; set; }
    }
}
