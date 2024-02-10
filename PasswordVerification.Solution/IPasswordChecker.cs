namespace PasswordVerification.Solution
{
    public interface IPasswordChecker
    {
        event Action<string> PasswordChecked;
        void Validate(string password);
    }
}