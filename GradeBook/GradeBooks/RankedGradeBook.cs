using System;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("There are less then 5 students!");
            }

            var Porcent20 = (int)Math.Ceiling(Students.Count * 0.2);
            var oceny = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (oceny[Porcent20 - 1] <= averageGrade)
                return 'A';
            else if (oceny[Porcent20 * 2 - 1] <= averageGrade)
                return 'B';
            else if (oceny[Porcent20 * 3 - 1] <= averageGrade)
                return 'C';
            else if (oceny[Porcent20 * 4 - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}