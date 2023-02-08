namespace SodaVendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine sodaMachine = new(0, new Soda[] { 
                new Soda("Cola", 20, 10, 1),
                new Soda("Fanta", 18, 15, 2),
                new Soda("Sprite", 17, 20, 3),
                new Soda("Dr. Pepper", 15, 5, 4)
            });

            while (true)
            {
                sodaMachine.ShowStock();
                sodaMachine.ShowBalance();
                sodaMachine.ShowCommands();
            }
            
        }
    }
}