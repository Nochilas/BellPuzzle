using System;

namespace BellPuzzle
{
    class Program
    {
        static void Solve(char[] bells)
        {
            int answer;
            int ticks = 10; //Ticks = warnings (prima che la serratura si rompa)
            int attempts = 0;
            bool solved = false;
            
            while(!solved && ticks > 0)
            {
                answer = Convert.ToInt32(Console.ReadLine());
                RingBell(bells, answer);

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

        
        //In base al comando suona una delle 4 campane
        static void CheckAnswer(char[] bells, int answer)
        {
            while(answer < 0 || answer > 3)
            {
                Console.WriteLine("Attenzione, numero non valido");
                answer = Convert.ToInt32(Console.ReadLine());
            }

            switch(answer)
            {
                case 1:
                    RingBell(bells, answer-1);
                    break;

                case 2:
                    RingBell(bells, answer-1);
                    break;

                case 3:
                    RingBell(bells, answer-1);
                    break;

                case 4:
                    RingBell(bells, answer-1);
                    break;
                
                default:
                    Console.WriteLine("Non succede nulla");
                    break;
            }
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
                        ToggleBell(bells[i]);
                        break;
                    }
        }
        
        /*
        //Campana 1: oXXX
        static void RingFirstBell(char[] bells)
        {
            bells[1] = ToggleBell(bells[1]);
            bells[2] = ToggleBell(bells[2]);
            bells[3] = ToggleBell(bells[3]);
        }

         //Campana 2: ooXX
        static void RingSecondBell(char[] bells)
        {
            bells[2] = ToggleBell(bells[2]);
            bells[3] = ToggleBell(bells[3]);
        }

         //Campana 3: XooX
        static void RingThirdBell(char[] bells)
        {
            bells[0] = ToggleBell(bells[0]);
            bells[3] = ToggleBell(bells[3]);
        }

         //Campana 4: XoXX
        static void RingFourthBell(char[] bells)
        {
            bells[0] = ToggleBell(bells[0]);
            bells[2] = ToggleBell(bells[2]);
            bells[3] = ToggleBell(bells[3]);
        }*/

        static char ToggleBell(char ch) //Cambia 'o' in 'O' e viceversa, a seconda della campana suonata
        {
            const char BELL_SOLVED = 'O';
            const char BELL_UNSOLVED = 'o';
            
            return (ch == BELL_UNSOLVED) ? BELL_SOLVED : BELL_UNSOLVED;
        }

        static void Main(string[] args)
        {
            const char BELL_UNSOLVED = 'o';
            int length;

            Console.WriteLine("Insert n. bells");
            length = Convert.ToInt32(Console.ReadLine());

            char[] bells = new char[length];

            for(int i = 0; i < length; i++)
                bells[i] = BELL_UNSOLVED;

            Solve(bells);
        }
    }
}
