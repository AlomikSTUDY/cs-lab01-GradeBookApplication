using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class WseiGradeBook : BaseGradeBook
    {
        public WseiGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Wsei;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 70)
                return 'A';
            if (averageGrade >= 60)
                return 'B';
            if (averageGrade >= 50)
                return 'C';
            if (averageGrade >= 40)
                return 'D';
            if (averageGrade >= 30)
                return 'E';
            else
                return 'F';


        }
    }
}
