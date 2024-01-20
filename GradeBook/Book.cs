using System.Linq.Expressions;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Book
    {
        public Book(string name) 
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            } 
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Total = 0.0;
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            
            for(var index = 0; index < grades.Count; index++) //foreach, dowhile(ONCE), while, for
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Total += grades[index];
            }
            result.Average = result.Total / grades.Count;

            switch (result.Letter)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A'; 
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        List<double> grades;

        /*public string Name // OLD WAY
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }

        string name;*/

        public string Name //AUTO PROPERTY
        {
            get; 
            set;
        }

        readonly string category = "Math"; //value can be changed only here or inside

        public const string CATEGORY = "Constant"; //value cannot change after instantiation

    }
}
