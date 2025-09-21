using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreViewLab_NET8_FULL_VN.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int TotalPage { get; set; }
    }

    public class BookRepository
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book { Id=1, Title="Chí Phèo", AuthorId=1, GenreId=1, Image="/images/products/b1.jpg", Price=500000, Summary="Tác phẩm Nam Cao", TotalPage=250 },
            new Book { Id=2, Title="Lão Hạc", AuthorId=1, GenreId=1, Image="/images/products/b2.jpg", Price=700000, Summary="Tác phẩm cảm động", TotalPage=300 },
            new Book { Id=3, Title="Conan Phiêu Lưu Ký", AuthorId=2, GenreId=2, Image="/images/products/b3.jpg", Price=550000, Summary="Truyện trinh thám", TotalPage=320 },
            new Book { Id=4, Title="Đường Xưa Mây Trắng", AuthorId=3, GenreId=1, Image="/images/products/b4.jpg", Price=850000, Summary="Tiểu thuyết lãng mạn", TotalPage=400 },
            new Book { Id=5, Title="Dế Mèn Phiêu Lưu Ký", AuthorId=4, GenreId=3, Image="/images/products/b5.jpg", Price=300000, Summary="Văn học thiếu nhi", TotalPage=150 },
            new Book { Id=6, Title="Harry Potter", AuthorId=5, GenreId=4, Image="/images/products/b6.jpg", Price=950000, Summary="Fantasy nổi tiếng", TotalPage=600 }
        };

        public List<Book> GetBookList() => _books.ToList();

        public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book b)
        {
            var next = _books.Any() ? _books.Max(x => x.Id) + 1 : 1;
            b.Id = next;
            _books.Add(b);
        }

        public void Update(Book b)
        {
            var ex = GetBookById(b.Id);
            if (ex == null) return;
            ex.Title = b.Title;
            ex.AuthorId = b.AuthorId;
            ex.GenreId = b.GenreId;
            ex.Image = b.Image;
            ex.Price = b.Price;
            ex.Summary = b.Summary;
            ex.TotalPage = b.TotalPage;
        }

        public void Delete(int id)
        {
            var ex = GetBookById(id);
            if (ex != null) _books.Remove(ex);
        }
    }
}
