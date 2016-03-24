using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H9BookShop {
    public class Book {
        #region PROPERTIES
        private int id;
        public int ID {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string author;
        public string Author {
            get { return author; }
            set { author = value; }
        }

        private string country;
        public string Country {
            get { return country; }
            set { country = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }

        #endregion
        #region CONSTRUCTORS
        public Book(int id) {
            this.id = id;
        }
        public Book(int id, string name, string author, string country, int year) {
            this.id = id;
            this.name = name;
            this.author = author;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name + " written by " + author;
        }
        #endregion
    }

    public static class Bookshop {
        public static List<Book> GetTestBooks() {
            List<Book> temp = new List<Book>();
            temp.Add(new Book(1, "Sota ja rauha", "Leo Tolstoi", "Venäjä", 1867));
            temp.Add(new Book(2, "Anna Karenina", "Leo Tolstoi", "Venäjä", 1877));
            return temp;
        }
    }
}
