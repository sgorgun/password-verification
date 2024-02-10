using PasswordVerification.Solution;
using System;
using System.IO;
using System.Linq;

namespace PasswordVerification.ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            IPasswordChecker checker = new PasswordChecker();
            IPasswordKeeper keeper = new PasswordKeeper();

            PasswordCheckerService passwordCheckerTools = new(checker, keeper);

            Console.Write("Enter your password: ");
            string? password = Console.ReadLine();

            passwordCheckerTools.CheckPassword(password!);

            Console.ReadKey();
        }
    }
}
