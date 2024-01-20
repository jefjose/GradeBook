namespace GradeBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Josh's Book");
            book.GradeAdded += OnGradeAdded;


            /*string input; // FIRST TRY
            do
            {
                Console.Write("Enter a grade or 'q' to quit: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty");
                }

                if(input.ToLower() != "q" && input != null)
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
            } while (input.ToLower() != "q");*/

            /*var done = false; // SECOND TRY

            while (!done)
            {
                Console.Write("Enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();

                if(input != null && input != "") { 
                    if(input.ToLower() != "q" )
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    } 
                    else
                    {
                        done = true;
                    }
                } 
                else
                {
                    Console.WriteLine("Input cannot be empty");
                }

            }*/

            while (true)
            {
                Console.Write("Enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                } 
                catch(ArgumentException e) 
                { 
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

            var stats = book.GetStatistics();

                 
            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For book named {book.Name}");
            Console.WriteLine($"The Lowest Grade {stats.Total}");
            Console.WriteLine($"The Highest Grade {stats.High}");
            Console.WriteLine($"The Total is {stats.Total:N1}");
            Console.WriteLine($"The average is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");


            /*if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            } else
            {
                Console.WriteLine("Hello!");
            }*/
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade Added");
        }
    }
}