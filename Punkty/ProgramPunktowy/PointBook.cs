using System;
using System.Collections.Generic;

namespace ProgramPunktowy
{
    public class PointBook : INotesCalculator
    {
        private string _bookCoverColor;
        public string BookName { get; set; }
        public List<float> Points;
        public ChangeBookCoverDelegate ChangeBookCover { get; set; }


        public PointBook()
        {
            _bookCoverColor = "Razzmatazz";
            Points = new List<float>();
        }

        public List<float> AddPoints()
        {
            try
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"Podaj punkty uzyskane w ruchu {i}: ");
                    float point = float.Parse(Console.ReadLine());
                    Points.Add(point);
                }
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return Points;

        }

        public virtual StaticticsOfGivenValues CalculateStatictics()
        {
            StaticticsOfGivenValues statystyka = new StaticticsOfGivenValues();

            float lacznaSumaPunktow = 0;
            foreach (var point in Points)
            {
                if (point > statystyka.WorstValue)
                {
                    statystyka.WorstValue = point;
                }
                if (point < statystyka.BestValue)
                {
                    statystyka.BestValue = point;
                }

                lacznaSumaPunktow += point;
            }

            statystyka.AverageValue = (lacznaSumaPunktow) / (Points.Count);

            return statystyka;
        }

        public string BookCoverColor
        {

            get
            {
                return _bookCoverColor;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_bookCoverColor!= value)
                    {
                        ChangeBookCover(_bookCoverColor, value);
                    }
                    _bookCoverColor = value;
                }


            }
        }

        public void AddBookCoverColor()
        {
            _bookCoverColor = Console.ReadLine();
        }

    }
}
