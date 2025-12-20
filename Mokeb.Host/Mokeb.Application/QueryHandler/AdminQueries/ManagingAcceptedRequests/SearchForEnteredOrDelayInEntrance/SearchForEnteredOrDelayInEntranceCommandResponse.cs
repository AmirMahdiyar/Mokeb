using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForEnteredOrDelayInEntrance
{
    public class SearchForEnteredOrDelayInEntranceCommandResponse
    {
        public static SearchForEnteredOrDelayInEntranceCommandResponse SucceededResponse(List<GettingIncomingOrAcceptedRequestsResponseDto> response)
        {
            return new SearchForEnteredOrDelayInEntranceCommandResponse()
            {
                Response = response,
            };
        }

        public List<GettingIncomingOrAcceptedRequestsResponseDto> Response { get; set; }
    }
}
