using MediatR;
using Mokeb.Application.CommandHandler.Base.Extension;
using Mokeb.Application.QueryHandler.AdminQueries.GettingPrincipalInformation;
using Mokeb.Application.QueryHandler.Base;

namespace Mokeb.Application.QueryHandler.AdminQueries.GettingCaravanInformation
{
    public class GettingPrincipalInformationQuery : QueryBase, IRequest<GettingPrincipalInformationQueryResponse>
    {
        public Guid PrincipalId { get; set; }
        public override void Validate()
        {
            new GettingPrincipalInformationQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
