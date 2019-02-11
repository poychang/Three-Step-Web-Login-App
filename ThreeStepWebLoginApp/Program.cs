using System;

namespace ThreeStepWebLoginApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Three Step Web Login App");
            Console.WriteLine("==============================");

            using (var instance = new Startup())
            {
                instance.Login();
                instance.Verify();
                instance.Close();
            }
        }

    }
}
