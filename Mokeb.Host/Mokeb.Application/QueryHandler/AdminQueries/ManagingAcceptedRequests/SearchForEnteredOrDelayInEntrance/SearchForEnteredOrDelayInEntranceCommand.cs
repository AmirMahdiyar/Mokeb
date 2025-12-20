using MediatR;
using Mokeb.Application.CommandHandler.Base;
using Mokeb.Application.CommandHandler.Base.Extension;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingAcceptedRequests.SearchForEnteredOrDelayInEntrance
{
    public class SearchForEnteredOrDelayInEntranceCommand : CommandBase, IRequest<SearchForEnteredOrDelayInEntranceCommandResponse>
    {
        public string Input { get; set; }
        public DateOnly Date { get; set; }
        public override void Validate()
        {
            new SearchForEnteredOrDelayInEntranceCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
