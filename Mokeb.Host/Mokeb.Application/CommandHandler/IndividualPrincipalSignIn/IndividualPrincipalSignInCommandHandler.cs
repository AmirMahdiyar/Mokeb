using MediatR;
using Mokeb.Application.Contracts;
using Mokeb.Common.Base.ApplicationExceptions;

namespace Mokeb.Application.CommandHandler.IndividualPrincipalSignIn
{
    public class IndividualPrincipalSignInCommandHandler : IRequestHandler<IndividualPrincipalSignInCommand, IndividualPrincipalSignInCommandResponse>
    {
        private readonly IIndividualRepository _individualRepository;
        private readonly IUnitOfWork _unitOfWork;
        public IndividualPrincipalSignInCommandHandler(IJwsService jwsService, IIndividualRepository individualRepository, IUnitOfWork unitOfWork)
        {
            _individualRepository = individualRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IndividualPrincipalSignInCommandResponse> Handle(IndividualPrincipalSignInCommand request, CancellationToken cancellationToken)
        {
            await CheckIndividualExistance(request.Username, request.NationalNumber, request.PassportNumber, cancellationToken);
            _individualRepository.AddIndividualPrincipal(request.ToIndividualPrincipal());

            var savingResult = await _unitOfWork.Commit(cancellationToken);
            savingResult.ThrowIfNoChanges<NoChangesApplicationException>();

            return IndividualPrincipalSignInCommandResponse.Succeeded;
        }
        #region Private Methods
        private async Task CheckIndividualExistance(string username, string nationalNumber, string passportNumber, CancellationToken ct)
        {
            var result = await _individualRepository.IsIndividualByIdenticalInformationExists(username, nationalNumber, passportNumber, ct);
            if (result)
                throw new IndividualExistException();
        }
        #endregion
    }
}
