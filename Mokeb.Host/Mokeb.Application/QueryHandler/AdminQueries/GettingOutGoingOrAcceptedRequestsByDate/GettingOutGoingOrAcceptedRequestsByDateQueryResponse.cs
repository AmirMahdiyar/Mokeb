using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingOutGoingAcceptedCaravansRequestsByDate
{
    public class GettingOutGoingOrAcceptedRequestsByDateQueryResponse
    {
        public static GettingOutGoingOrAcceptedRequestsByDateQueryResponse SucceededResponse(List<GettingOutGoingOrAcceptedRequestsResponseDto> response)
        {
            return new GettingOutGoingOrAcceptedRequestsByDateQueryResponse()
            {
                Response = response,
            };
        }

        public List<GettingOutGoingOrAcceptedRequestsResponseDto> Response { get; set; }
    }
}
