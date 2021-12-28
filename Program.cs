using System;

namespace BellPuzzle
{
    class Program
    {
        static void Solve(char[] bells)
        {
            char answer;
            int ticks = 10;
            int attempts = 0;
            bool solved = false;
            
            while(solved == false)
            {
                answer = Convert.ToChar(Console.ReadLine());
                bells = CheckAnswer(answer, bells);

                foreach(char c in bells)
                    {
                        Console.Write($"{c} ");
                    }
                
                    Console.WriteLine();

                attempts++;

                if(attempts % 5 == 0)
                {
                    ticks--;
                    Console.WriteLine("Tick");

                    if(ticks == 0)
                    {
                        Console.Write("CRACK\n");
                        Console.WriteLine("Il forziere si rompe");
                    }
                        
                }

                solved = Check(bells);
            }

            if(solved == true)
                Console.WriteLine("Il forziere si apre");
        }
        static bool Check(char[] bells)
        {
            int count = 0;

            foreach(char c in bells)
                if(c == 'O')
                    count++;
            
            if(count == 4)
                return true;
            
            return false;
            
        }
        static char[] CheckAnswer(char answer, char[] bells)
        {
            //Check answer
            switch(answer)
            {
                case '1':
                    RingFirstBell(bells);
                    return bells;
                    

                case '2':
                    RingSecondBell(bells);
                    return bells;

                case '3':
                    RingThirdBell(bells);
                    return bells;

                case '4':
                    RingFourthBell(bells);
                    return bells;
                
                default:
                    Console.WriteLine("Non succede nulla");
                    return bells;
            }
        }
        
        static char[] RingFirstBell(char[] bells)
        {
            for(int i = 1; i < bells.Length; i++)
                bells[i] = CaseSwitch(bells[i]);
            
            return bells;
        }

        static char[] RingSecondBell(char[] bells)
        {
            bells[2] = CaseSwitch(bells[2]);
            bells[3] = CaseSwitch(bells[3]);
            
            return bells;
        }

        static char[] RingThirdBell(char[] bells)
        {
            bells[0] = CaseSwitch(bells[0]);
            bells[3] = CaseSwitch(bells[3]);
            
            return bells;
        }

        static char[] RingFourthBell(char[] bells)
        {
            bells[0] = CaseSwitch(bells[0]);
            bells[2] = CaseSwitch(bells[2]);
            bells[3] = CaseSwitch(bells[3]);
            
            return bells;
        }

        static char CaseSwitch(char ch)
        {
            if(ch == 'o')
                return 'O';
            else
                return 'o';
        }

        static void Main(string[] args)
        {
            char[] bells = {'o', 'o', 'o', 'o'};
            
            Solve(bells);
        }
    }
}
