
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CW_06_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{

            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();



            //    var authors = new List<Author>
            //    {
            //        new Author {  Name = "George Orwell" },
            //        new Author {  Name = "J.K. Rowling" },
            //        new Author {  Name = "Ernest Hemingway" }
            //    };

            //    var genres = new List<Genre>
            //    {
            //        new Genre {  Name = "Dystopian" },
            //        new Genre { Name = "Fantasy" },
            //        new Genre {  Name = "Classics" }
            //    };

            //    var books = new List<Book>
            //    {
            //        new Book {  Title = "1984", AuthorId = 1, GenreId = 1, Price = 9.99m, Author = authors[0], Genre = genres[0] },
            //        new Book {  Title = "Harry Potter and the Philosopher's Stone", AuthorId = 2, GenreId = 2, Price = 19.99m, Author = authors[1], Genre = genres[1] },
            //        new Book {  Title = "The Old Man and the Sea", AuthorId = 3, GenreId = 3, Price = 14.99m, Author = authors[2], Genre = genres[2] }
            //    };


            //    db.Genres.AddRange(genres);
            //    db.Authors.AddRange(authors);
            //    db.Books.AddRange(books);

            //    db.SaveChanges();
            //}

        }




    }



    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new();
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; } = new();
    }


    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R3LQDV9;Database = testDB1;Trusted_Connection =True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b=>b.Author).WithMany(b=>b.Books).HasForeignKey(b=>b.AuthorId);

            modelBuilder.Entity<Book>().HasOne(b => b.Genre).WithMany(a => a.Books).HasForeignKey(b => b.GenreId);

        }
    }
}
