using Mokeb.Application.Dtos;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse
    {
        public static GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse Succeed()
        {
            return new GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse
            {

            };
        }

        public GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse WithRequests(List<GettingIncomingOrAcceptedRequestsResponseDto> requests)
        {
            this.Requests = requests;

            return this;
        }

        public List<GettingIncomingOrAcceptedRequestsResponseDto> Requests { get; set; }
    }
}
