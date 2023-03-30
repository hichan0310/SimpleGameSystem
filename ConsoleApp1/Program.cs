namespace Main
{
    public class simplegame
    {
        private static int turns = 0;

        public static void Main()
        {
            Buff buff1 = new Burn(3);
            Charector charector1 = new Charector("player1", 1000, 100, 100);
            Charector charector2 = new Charector("player2", 1000, 100, 100);

            FireBall fireBall = new FireBall(1);
            Javelin javelin = new Javelin(1);
            
            List<Charector> targets = new List<Charector>();
            targets.Add(charector2);
            fireBall.execute(charector1, targets);
            
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n\n\n\n");
            Console.WriteLine(charector1.ToString());
            Console.WriteLine(charector2.ToString());
            
            javelin.execute(charector2, charector1);
            charector1.turnover(1);
            charector2.turnover(1);
            
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n\n\n\n");
            Console.WriteLine(charector1.ToString());
            Console.WriteLine(charector2.ToString());
        }
    }
}