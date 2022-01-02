using System;

namespace BellPuzzle
{
    class Program
    {
        static void Solve(char[] bells)
        {
            char answer;
            int ticks = 10; //Ticks = warnings (prima che la serratura si rompa)
            int attempts = 0;
            bool solved = false;
            
            while(!solved && ticks > 0)
            {
                answer = Convert.ToChar(Console.ReadLine());
                CheckAnswer(answer, bells);

                foreach(char c in bells) //Monitora il progresso sull'array bells
                    Console.Write($"{c} ");
                
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
        static void CheckAnswer(char answer, char[] bells)
        {
            switch(answer)
            {
                case '1':
                    RingFirstBell(bells);
                    break;

                case '2':
                    RingSecondBell(bells);
                    break;

                case '3':
                    RingThirdBell(bells);
                    break;

                case '4':
                    RingFourthBell(bells);
                    break;
                
                default:
                    Console.WriteLine("Non succede nulla");
                    break;
            }
        }
        
        //Campana 1: oXXX
        static void RingFirstBell(char[] bells)
        {
            for(int i = 1; i < bells.Length; i++)
                bells[i] = ToggleBell(bells[i]);
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
        }

        static char ToggleBell(char ch) //Cambia 'o' in 'O' e viceversa, a seconda della campana suonata
        {
            const char BELL_SOLVED = 'O';
            const char BELL_UNSOLVED = 'o';
            
            return (ch == BELL_UNSOLVED) ? BELL_SOLVED : BELL_UNSOLVED;
        }

        static void Main(string[] args)
        {
            char[] bells = {'o', 'o', 'o', 'o'};
            
            Solve(bells);
        }
    }
}
