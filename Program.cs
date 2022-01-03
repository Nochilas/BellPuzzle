using System;

namespace BellPuzzle
{
    class Program
    {
        const char BELL_SOLVED = 'O';
        const char BELL_UNSOLVED = 'o';

        static void Solve(char[] bells)
        {
            int answer;
            int ticks = 10; //Ticks = warnings (prima che la serratura si rompa)
            int attempts = 0;
            bool solved = false;
            bool ansChecked;
            
            while(!solved && ticks > 0)
            {
                answer = Convert.ToInt32(Console.ReadLine());
                ansChecked = CheckAnswer(answer);

                if(ansChecked)
                    RingBell(bells, answer - 1);

                foreach(char bell in bells) //Monitora il progresso sull'array bells
                    Console.Write($"{bell} ");
                
                Console.WriteLine();
                attempts++;

                //Un Tick (warning) ogni 5 comandi
                if(attempts % 5 == 0)
                {
                    ticks--;
                    Console.WriteLine("Tick");

                //Se dopo 50 comandi diversi non si è risolto il puzzle, la serratura si rompe
                    if(ticks == 0)
                    {
                        Console.Write("CRACK\n");
                        Console.WriteLine("La serratura si rompe");
                    }
  
                }

                solved = Check(bells);
            }

            //Se l'array bells è stato trasformato in OOOO, il forziere si apre
            if(solved == true)
                Console.WriteLine("Il forziere si apre");
        }

        //Controlla se bells è stato risolto (risolto = OOOO)
        static bool Check(char[] bells)
        {
            const char BELL_SOLVED = 'O';
            bool solved = true;

            foreach(char bell in bells)
                if(bell != BELL_SOLVED)
                {
                    solved = false;
                    break;
                }

            return solved;
        }

        //Restituisce un bool in base alla risposta
        static bool CheckAnswer(int ans)
        {
            return (ans < 1 || ans > 4) ? false : true;
        }

        static void RingBell(char[] bells, int answer)
        {
            int[][] bells_to_toggle = new int[4][];
            bells_to_toggle[0] = new int[] {1, 2, 3};
            bells_to_toggle[1] = new int[] {2, 3};
            bells_to_toggle[2] = new int[] {0, 3};
            bells_to_toggle[3] = new int[] {0, 2, 3};

            for(int i = 0; i < bells.Length; i++)
                for(int j = 0; j < bells_to_toggle[answer].Length; j++)
                    if(i == bells_to_toggle[answer][j])
                    {
                        bells[i] = ToggleBell(bells[i]);
                        break;
                    }
        }

        static char ToggleBell(char ch) //Cambia 'o' in 'O' e viceversa, a seconda della campana suonata
        {
            return (ch == BELL_UNSOLVED) ? BELL_SOLVED : BELL_UNSOLVED;
        }

        static void Main(string[] args)
        {
            const int LENGTH = 4;
            char[] bells = new char[LENGTH];

            for(int i = 0; i < LENGTH; i++)
                bells[i] = BELL_UNSOLVED;

            Solve(bells);
        }
    }
}
