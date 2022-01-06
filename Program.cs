using System;

namespace BellPuzzle
{
    class Program
    {
        const char BELL_SOLVED = 'O';
        const char BELL_UNSOLVED = 'o';
        static char[] bells;
        static int [,] bells_to_toggle;

        static void CreateBells(int length)
        {
            for(int i = 0; i < length; i++)
                bells[i] = BELL_UNSOLVED;
        }
        static void Solve(char[] bells)
        {
            int answer;
            int ticks = 10; //Ticks = warnings (prima che la serratura si rompa)
            int attempts = 0;
            bool solved = false;
            bool ansChecked = false;
            
            while(!solved && ticks > 0)
            {
                while(!ansChecked)
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                    ansChecked = CheckAnswer(answer);

                    if(ansChecked)
                        RingBell(bells, answer - 1);
                    else
                        Console.WriteLine("Valore non valido");
                }
                    
                foreach(char bell in bells) //Checking progress on bells array
                    Console.Write($"{bell} ");
                
                Console.WriteLine();
                attempts++;

                //A Tick (warning) every 5 attempts
                if(attempts % 5 == 0)
                {
                    ticks--;
                    Console.WriteLine("Tick");

                //Lock breaks after 50 attempts
                    if(ticks == 0 && !solved)
                    {
                        Console.WriteLine("CRACK");
                        Console.WriteLine("The lock breaks");
                    }
                }

                solved = Check(bells);
            }

            //If bells array is solved (= OOOO) the chest is unlocked
            if(solved == true)
                Console.WriteLine("The chest is unlocked");
        }

        //Checks if bells is solved (solved = OOOO)
        static bool Check(char[] bells)
        {
            bool solved = true;

            foreach(char bell in bells)
                if(bell != BELL_SOLVED)
                {
                    solved = false;
                    break;
                }

            return solved;
        }

        //Checks the answer and returns a bool
        static bool CheckAnswer(int ans)
        {
            return (ans < 1 || ans > 4) ? false : true;
        }

        static void RingBell(char[] bells, int answer)
        {
            /* TODO: Fix
            for(int i = 0; i < bells.Length; i++)
                for(int j = 0; j < bells_to_toggle[answer].Length; j++)
                    if(i == bells_to_toggle[answer][j])
                    {
                        bells[i] = ToggleBell(bells[i]);
                        break;
                    }*/
        }

        //Changes 'o' in 'O' and vice versa
        static char ToggleBell(char ch)
        {
            return (ch == BELL_UNSOLVED) ? BELL_SOLVED : BELL_UNSOLVED;
        }

        static void Main(string[] args)
        {
            int length;
            Console.WriteLine("Insert n. bells");

            /* TODO: fix
            bells_to_toggle[0] = new int[] {1, 2, 3};
            bells_to_toggle[1] = new int[] {2, 3};
            bells_to_toggle[2] = new int[] {0, 3};
            bells_to_toggle[3] = new int[] {0, 2, 3};*/

            Solve(bells);
        }
    }
}
