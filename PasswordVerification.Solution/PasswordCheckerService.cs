namespace PasswordVerification.Solution
{

    public class PasswordCheckerService
    {
        private readonly IPasswordChecker Checker;
        private readonly IPasswordKeeper Keeper;

        public PasswordCheckerService(IPasswordChecker сhecker, IPasswordKeeper keeper)
        {
            Checker = сhecker;
            Keeper = keeper;
            Checker.PasswordChecked += OnPasswordChecked;
        }

        private void OnPasswordChecked(string password)
        {
            Keeper.Save(password);
        }

        public void CheckPassword(string password)
        {
            Checker.Validate(password);
        }
    }
}