namespace GradeBookTests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(82.5);
            book.AddGrade(25.4);
            book.AddGrade(42.2);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(50.0, result.Average, 1);
            Assert.Equal(150.1, result.Total, 1);
            Assert.Equal(25.4, result.Low, 1);
            Assert.Equal(82.5, result.High, 1);
            Assert.Equal('F', result.Letter);
        }

        
    }
}