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
            
            while(solved == false)
            {
                answer = Convert.ToChar(Console.ReadLine());
                bells = CheckAnswer(answer, bells);

                foreach(char c in bells) //Monitora il progresso sull'array bells
                    {
                        Console.Write($"{c} ");
                    }
                
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

        static bool Check(char[] bells) //Controlla se bells è stato risolto (risolto = OOOO)
        {
            int count = 0;

            foreach(char c in bells)
                if(c == 'O')
                    count++;
            
            if(count == 4)
                return true;
            
            return false;
            
        }

        static char[] CheckAnswer(char answer, char[] bells) //In base al comando suona una delle 4 campane
        {
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
        
        static char[] RingFirstBell(char[] bells) //Campana 1: oXXX
        {
            for(int i = 1; i < bells.Length; i++)
                bells[i] = CaseSwitch(bells[i]);
            
            return bells;
        }

        static char[] RingSecondBell(char[] bells) //Campana 2: ooXX
        {
            bells[2] = CaseSwitch(bells[2]);
            bells[3] = CaseSwitch(bells[3]);
            
            return bells;
        }

        static char[] RingThirdBell(char[] bells) //Campana 3: XooX
        {
            bells[0] = CaseSwitch(bells[0]);
            bells[3] = CaseSwitch(bells[3]);
            
            return bells;
        }

        static char[] RingFourthBell(char[] bells) //Campana 4: XoXX
        {
            bells[0] = CaseSwitch(bells[0]);
            bells[2] = CaseSwitch(bells[2]);
            bells[3] = CaseSwitch(bells[3]);
            
            return bells;
        }

        static char CaseSwitch(char ch) //Cambia 'o' in 'O' e viceversa, a seconda della campana suonata
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
