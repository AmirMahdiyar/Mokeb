using MediatR;
using Mokeb.Application.CommandHandler.Base.Extension;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForExitedOrDelayInExited
{
    public class SearchForExitedOrDelayInExitedCommand : QueryBase, IRequest<SearchForExitedOrDelayInExitedCommandResponse>
    {
        public DateOnly Date { get; set; }
        public string Input { get; set; }
        public override void Validate()
        {
            new SearchForExitedOrDelayInExitedCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
