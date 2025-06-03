using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class BookDTO
    {
        public int AuthorId { get; set; }
        public int BooksId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double BasePrice { get; set; }

        public CoverDTO Cover { get; set; }
    }
}
