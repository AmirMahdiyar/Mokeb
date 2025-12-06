using Mokeb.Domain.Model.Enums;
using Mokeb.Domain.Model.Exceptions.CaravanExceptions;

namespace Mokeb.Domain.Model.ValueObjects
{
    public class IdentityInformation
    {
        public IdentityInformation(string username, string password, Role role)
        {
            CheckUsername(username);
            CheckPassword(password);

            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public Role Role { get; protected set; }

        #region Behaviors
        public void ChangeUsername(string username)
        {
            CheckUsername(username);
            Username = username;
        }
        public void ChangePassword(string password)
        {
            CheckPassword(password);
            Password = password;
        }
        #endregion
        #region Validations
        public void CheckUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new UsernameIsInvalidException();
        }

        public void CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordInvalidException();
        }
        #endregion
    }
}
