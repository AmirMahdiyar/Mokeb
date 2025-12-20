using MediatR;
using Mokeb.Application.CommandHandler.Base.Extension;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.ManagingCaravans.SearchInCaravans
{
    public class SearchInCaravansCommand : QueryBase, IRequest<SearchInCaravansCommandResponse>
    {
        public string Input { get; set; }
        public override void Validate()
        {
            new SearchInCaravansCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
