using System;
using System.Linq.Expressions;

namespace ProgramPunktowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Gender? gender = null;

            while (gender == null)
            {
                Console.WriteLine("Podaj swoją płeć. \n 1 - Mężczyzna \n 2 - Kobieta");
                string input = Console.ReadLine();
                Gender selectedGender;
                if (!Enum.TryParse(input, true, out selectedGender))
                    continue;
                if ((int) selectedGender > 2 || selectedGender < 0)
                    continue;
                gender = selectedGender;
            }

            INotesCalculator zeszytWynikowJanusza = new DeleteExtremeValues();
            zeszytWynikowJanusza.ChangeBookCover = new ChangeBookCoverDelegate(ChangingColorDescription);

            AddBookName(zeszytWynikowJanusza);
            AddBookCoverColor(zeszytWynikowJanusza);
            zeszytWynikowJanusza.AddPoints();
            
            StaticticsOfGivenValues statystyka = zeszytWynikowJanusza.CalculateStatictics();
            Console.WriteLine("Po usunięciu skrajnych rezultatów twoje wyniki prezentują się następująco:");
            WriteStatistics(zeszytWynikowJanusza, statystyka);


            Console.ReadLine();
            
        }
        
        private static void WriteStatistics(INotesCalculator zeszytWynikowJanusza, StaticticsOfGivenValues statystyka)
        {
            StringDescription("Średnia uzyskanych przez Ciebie wyników to: ", statystyka.AverageValue);
            StringDescription("Twój najlepszy wynik to ", statystyka.WorstValue);
            StringDescription("Twój najgorszy wynik to: ", statystyka.BestValue);

        }

        private static void AddBookName(INotesCalculator zeszytWynikowJanusza)
        {
            try
            {
                Console.WriteLine("Podaj nazwę jaką ma posiadać Twój zeszyt - np. Zeszyt Punktacji Janusza");
                zeszytWynikowJanusza.BookName = Console.ReadLine();
                Console.WriteLine($"Aktualna nazwa dziennika to {zeszytWynikowJanusza.BookName}");
            }
            catch (ArgumentException aexp)
            {
                Console.WriteLine(aexp.Message);
            }

        }

        private static void AddBookCoverColor(INotesCalculator zeszytWynikowJanusza)
        {
            try
            {
                Console.WriteLine("Podaj kolor okladki jaki ma posiadac Twoj zeszyt. Aktualny kolor to Razzmatazz.");
                zeszytWynikowJanusza.AddBookCoverColor();

                Console.WriteLine($"Wybrałeś kolor {zeszytWynikowJanusza.BookCoverColor}");
            }
            catch (ArgumentException aexp)
            {
                Console.WriteLine(aexp.Message);
            }

        }
        
        private static void StringDescription(string opisWartosci, float wartosc)
        {
            Console.WriteLine($"{opisWartosci}" + ": " + $"{wartosc}");
        }

        private static void StringDescription(string opisWartosci)
        {
            Console.WriteLine($"{opisWartosci}");
        }

        private static void ChangingColorDescription (string obecnyKolor, string nowyKolor)
        {
            Console.WriteLine($"Zmieniłeś kolor z {obecnyKolor} na {nowyKolor}");
        }


    }
}

