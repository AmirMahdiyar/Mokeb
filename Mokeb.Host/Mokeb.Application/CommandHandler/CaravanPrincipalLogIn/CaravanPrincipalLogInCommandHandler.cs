using MediatR;
using Mokeb.Application.Contracts;
using Mokeb.Common.Base.Helper;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Application.CommandHandler.CaravanPrincipalLogIn
{
    public class CaravanPrincipalLogInCommandHandler : IRequestHandler<CaravanPrincipalLogInCommand, CaravanPrincipalLogInCommandResponse>
    {
        private readonly ICaravanPrincipalRepository _caravanRepository;
        private readonly IJwsService _jwsService;
        private readonly IUnitOfWork _unitOfWork;

        public CaravanPrincipalLogInCommandHandler(ICaravanPrincipalRepository caravanRepository, IJwsService jwsService, IUnitOfWork unitOfWork)
        {
            _caravanRepository = caravanRepository;
            _jwsService = jwsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<CaravanPrincipalLogInCommandResponse> Handle(CaravanPrincipalLogInCommand request, CancellationToken cancellationToken)
        {
            var caravan = await GetCaravan(request.Username, request.Password, cancellationToken);
            var jwsCode = await _jwsService.CreateJwsToken(caravan, cancellationToken);
            return CaravanPrincipalLogInCommandResponse.Response(jwsCode);

        }
        #region Private Methods
        private async Task<CaravanPrincipal> GetCaravan(string username, string password, CancellationToken ct)
        {
            var result = await _caravanRepository.GetCaravanAsync(username, Hasher.HashData(password), ct);
            if (result is null)
                throw new UsernameOrPasswordIsWrongException();
            return result;
        }
        #endregion
    }
}
