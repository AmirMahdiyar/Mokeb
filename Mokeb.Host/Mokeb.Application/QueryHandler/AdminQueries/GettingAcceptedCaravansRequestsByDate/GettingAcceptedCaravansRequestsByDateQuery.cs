using MediatR;
using Mokeb.Application.CommandHandler.Base.Extension;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedCaravansRequestsByDate
{
    public class GettingAcceptedCaravansRequestsByDateQuery : QueryBase, IRequest<GettingAcceptedCaravansRequestsByDateQueryResponse>
    {
        public DateOnly Date { get; set; }
        public override void Validate()
        {
            new GettingAcceptedCaravansRequestsByDateQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
