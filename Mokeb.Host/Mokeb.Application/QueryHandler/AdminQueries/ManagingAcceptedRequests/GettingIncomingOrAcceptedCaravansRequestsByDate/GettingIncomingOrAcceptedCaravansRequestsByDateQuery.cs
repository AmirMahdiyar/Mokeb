using MediatR;
using Mokeb.Application.CommandHandler.Base.Extension;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.GettingIncomingOrAcceptedCaravansRequestsByDate
{
    public class GettingIncomingOrAcceptedCaravansRequestsByDateQuery : QueryBase, IRequest<GettingIncomingOrAcceptedCaravansRequestsByDateQueryResponse>
    {
        public DateOnly Date { get; set; }
        public override void Validate()
        {
            new GettingIncomingOrAcceptedCaravansRequestsByDateQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
