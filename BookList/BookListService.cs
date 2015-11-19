using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.Xml.Serialization;
using System.Xml;

namespace BookList
{
    [Serializable]
    public class BookListService: IBookListService, IEnumerable<Book>
    {
        //private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private List<Book> books;

        public int Count { 
            get { return books.Count; } }
        
        public BookListService()
        {
            books = new List<Book>();
            //logger.Info("Empty BookListService ceated"); 
        }
        
        public void Reed(IBookListSource source)
        {
            books.AddRange(source.ReadBookList());
        }

        public void Write(IBookListSource source)
        {
            source.WriteBookList(books);
        }

        public void Add(object obj)
        {
            Book book = obj as Book;
            if (book != null)
                AddBook(book);
        }

        public void AddBook(Book book)
        {
            if (books.Contains(book))
                throw new ArgumentException();
            books.Add(book);
            //logger.Info("{0} was added", book);
        }

        public void Clear()
        {
            books.Clear();
        }

        public void RemoveBook(Book book)
        {
            if (!books.Contains(book))
                throw new ArgumentException();
            books.Remove(book);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            books.Sort(comparer);
        }

        public IEnumerable<Book> FindByTag(string author = "", string title = "", string publisher = "")
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Author.ToUpper().Contains(author.ToUpper())
                    && book.Title.ToUpper().Contains(title.ToUpper())
                    && book.Publisher.ToUpper().Contains(publisher.ToUpper()))
                    result.Add(book);
            }
            return result.AsEnumerable();
        }

        public void SerializeInXml(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(BookListService));
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
            }
        }

        public static BookListService DeserializeInXML(string filename)
        {
            XmlSerializer serializer = new
            XmlSerializer(typeof(BookListService));
            BookListService bs;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fs);
                bs = (BookListService)serializer.Deserialize(reader);
            }            
            return bs;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
