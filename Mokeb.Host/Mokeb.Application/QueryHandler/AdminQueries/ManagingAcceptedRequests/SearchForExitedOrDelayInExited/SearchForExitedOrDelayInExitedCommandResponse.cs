using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForExitedOrDelayInExited
{
    public class SearchForExitedOrDelayInExitedCommandResponse
    {
        public static SearchForExitedOrDelayInExitedCommandResponse SucceededResponse(List<GettingOutGoingOrAcceptedRequestsResponseDto> response)
        {
            return new SearchForExitedOrDelayInExitedCommandResponse()
            {
                Response = response,
            };
        }

        public List<GettingOutGoingOrAcceptedRequestsResponseDto> Response { get; set; }
    }
}
