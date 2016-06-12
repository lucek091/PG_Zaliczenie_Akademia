using System.Collections.Generic;

namespace ProgramPunktowy
{
    public interface INotesCalculator
    {
        List<float> AddPoints();
        StaticticsOfGivenValues CalculateStatictics();
        string BookCoverColor { get; }
        void AddBookCoverColor();
        ChangeBookCoverDelegate ChangeBookCover { get; set; }
        string BookName { get; set; }

    }
    }
