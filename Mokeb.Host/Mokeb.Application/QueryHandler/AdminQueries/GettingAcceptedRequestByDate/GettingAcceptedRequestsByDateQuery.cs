using MediatR;
using Mokeb.Application.CommandHandler.Base.Extension;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingAcceptedRequestByDate
{
    public class GettingAcceptedRequestsByDateQuery : QueryBase, IRequest<GettingAcceptedRequestsByDateQueryResponse>
    {
        public DateOnly Date { get; set; }
        public override void Validate()
        {
            new GettingAcceptedRequestsByDateQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
