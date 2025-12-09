using MediatR;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingOutGoingOrAcceptedCaravansRequestsByDate
{
    public class GettingOutGoingOrAcceptedCaravansRequestsByDateQuery : QueryBase, IRequest<GettingOutGoingOrAcceptedCaravansRequestsByDateQueryResponse>
    {
        public DateOnly Date { get; set; }
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
