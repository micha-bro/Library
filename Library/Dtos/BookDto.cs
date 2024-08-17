namespace Library.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; } = null!;
    }
}
