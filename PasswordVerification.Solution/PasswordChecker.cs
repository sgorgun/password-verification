using PasswordVerification.Solution;

namespace PasswordVerification.ConsoleApp
{
    public class PasswordChecker : IPasswordChecker
    {
        public event Action<string>? PasswordChecked;

        public void Validate(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"{password} is null or empty.", nameof(password));
            }

            if (password == string.Empty)
            {
                PasswordChecked?.Invoke($"{password} is empty");
                return;
            }

            if (password.Length <= 7)
            {
                PasswordChecked?.Invoke($"{password} length too short");
                return;
            }

            if (password.Length >= 15)
            {
                PasswordChecked?.Invoke($"{password} length too long");
                return;
            }

            if (!password.Any(char.IsLetter))
            {
                PasswordChecked?.Invoke($"{password} hasn't alphanumerical chars");
                return;
            }

            if (!password.Any(char.IsNumber))
            {
                PasswordChecked?.Invoke($"{password} hasn't digits");
                return;
            }

            PasswordChecked?.Invoke(password);
        }
    }
}
