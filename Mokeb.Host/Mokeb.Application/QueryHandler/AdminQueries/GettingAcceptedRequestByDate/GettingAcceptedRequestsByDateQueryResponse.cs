using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate
{
    public class GettingAcceptedRequestsByDateQueryResponse
    {
        public static GettingAcceptedRequestsByDateQueryResponse SucceededResponse(List<GettingAcceptedRequestsResponseDto> response)
        {
            return new GettingAcceptedRequestsByDateQueryResponse()
            {
                Response = response,
            };
        }

        public List<GettingAcceptedRequestsResponseDto> Response { get; set; }
    }
}
