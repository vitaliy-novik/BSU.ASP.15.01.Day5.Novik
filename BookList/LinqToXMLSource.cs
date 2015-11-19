using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookList
{
    public class LinqToXMLSource : IBookListSource
    {
        string filePath;

        public LinqToXMLSource(string path)
        {
            filePath = path;
        }

        public IEnumerable<Book> ReadBookList()
        {
            List<Book> books = new List<Book>();
            XDocument doc = XDocument.Load(filePath);
            foreach (XElement el in doc.Root.Elements())
            {
                string[] values = new string[3];
                int i = 0;
                foreach (XElement element in el.Elements())
                    values[i++] = element.Value;
                books.Add(new Book(values[0], values[1], values[2]));
            }
            return books.AsEnumerable();
        }

        public void WriteBookList(IEnumerable<Book> books)
        {
            XElement xBooks = new XElement("BookList",
                books.Select(book =>
                new XElement("Book",
                    new XElement("Author", book.Author),
                    new XElement("Title", book.Title),
                    new XElement("Publisher", book.Publisher))));
            XDeclaration xDecl = new XDeclaration("1.0", "UTF-8", "no");
            XDocument xDoc = new XDocument(xDecl, xBooks);
            xDoc.Save(filePath);
        }
    }
}
