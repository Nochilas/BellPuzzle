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
                        Console.WriteLine("CRACK");
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
            /* Da sistemare
            for(int i = 0; i < bells.Length; i++)
                for(int j = 0; j < bells_to_toggle[answer].Length; j++)
                    if(i == bells_to_toggle[answer][j])
                    {
                        bells[i] = ToggleBell(bells[i]);
                        break;
                    }*/
        }

        static char ToggleBell(char ch) //Cambia 'o' in 'O' e viceversa, a seconda della campana suonata
        {
            return (ch == BELL_UNSOLVED) ? BELL_SOLVED : BELL_UNSOLVED;
        }

        static void Main(string[] args)
        {
            int length;
            Console.WriteLine("Insert n. bells");

            /*
            bells_to_toggle[0] = new int[] {1, 2, 3};
            bells_to_toggle[1] = new int[] {2, 3};
            bells_to_toggle[2] = new int[] {0, 3};
            bells_to_toggle[3] = new int[] {0, 2, 3};*/

            Solve(bells);
        }
    }
}
