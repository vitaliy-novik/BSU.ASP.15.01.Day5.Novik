using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    public class BinarySourceAdapter : IBookListSource
    {
        string filePath;

        public BinarySourceAdapter(string path)
        {
            filePath = path;
        }

        public IEnumerable<Book> ReadBookList()
        {
            List<Book> books = new List<Book>();
            if (File.Exists(filePath))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        string author = reader.ReadString();
                        string title = reader.ReadString();
                        string publisher = reader.ReadString();
                        Book book = new Book(author, title, publisher);
                        books.Add(book);
                    }
                }
            }
            return books.AsEnumerable();
        }

        public void WriteBookList(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                }
            }
        }
    }
}
