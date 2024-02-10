using PasswordVerification.Solution;

namespace PasswordVerification.ConsoleApp
{
    public class PasswordKeeper : IPasswordKeeper
    {
        public void Save(string password)
        {
            using (FileStream fileStream = new FileStream("passwords.bin", FileMode.Append, FileAccess.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    writer.Write(password);
                }
            }
        }
    }
}
