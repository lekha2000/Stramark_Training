﻿using System;//Default APIs
using Assignment6;
using Entities;//For the Entity class
using Repository;//Repo class


namespace Entities
{
    class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int BookStock { get; set; } = 10;

        public void ShallowCopy(Book copy)
        {
            this.BookId = copy.BookId;
            this.BookStock = copy.BookStock;
            this.BookTitle = copy.BookTitle;
            this.Price = copy.Price;
            this.Publisher = copy.Publisher;
            this.Author = copy.Author;
        }

        public Book DeepCopy(Book copy)
        {
            Book book = new Book();
            book.ShallowCopy(copy);
            return book;
        }
    }
}
//datatype [] identifier = new datatype[size]
namespace Repository
{
    class BookRepository
    {
        private Book[] _books = null;
        private readonly int _size =0;
        public BookRepository(int size)
        {
            _size = size;
            _books = new Book[_size];
        }

        public int AddNewBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if(_books[i] == null)
                {
                    _books[i] = book.DeepCopy(book);
                    return 1;//To exit
                }
            }
            return _size;
        }

        public void UpdateBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == book.BookId)
                {
                    _books[i].ShallowCopy(book);
                    return;//To exit
                }
            }
            throw new Exception("No book found to update");
        }

        public void RemoveBook(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == id)
                {
                    _books[i] = null;
                    return;//To exit
                }
            }
            throw new Exception("No book found to remove");
        }

        public Book [] FindByAuthor(string author)
        {
           
            Book[] foundBooks = null;
            foreach (Book book in _books)
            {
        
                if (book != null && book.Author.Contains(author))
                {
                    Console.WriteLine("hey");
                    foundBooks = ArrayHelper.AddBook(book);
                }
            }
            return foundBooks;

        }

        public Book[] FindByTitle(string title)
        {
            Book[] foundBooks = null;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    foundBooks = ArrayHelper.AddBook(book);
                }
            }
            return foundBooks;

        }
    }
}

namespace UILayer
{
    enum Options
    {
        Add = 1, Remove = 5, Author = 3, Title = 4, Update = 2
    }
    class UIComponent
    {
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~BOOK STORE MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO ADD NEW BOOK------------------------>PRESS 1\nTO UPDATE EXISTING BOOK---------------->PRESS 2\nTO FIND BOOK BY AUTHOR----------------->PRESS 3\nTO FIND BOOK BY TITLE------------------>PRESS 4\nTO DELETE BOOK------------------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";

        private static BookRepository repo;

        public static void Run()
        {
            int size = Utilities.GetNumber("Enter the no of Books U need for the Store");
            repo = new BookRepository(size);
            bool processing = true;
            do
            {
                Options option = (Options)Utilities.GetNumber(menu);
                processing = processMenu(option);
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

        private static bool processMenu(Options option)
        {
            switch (option)
            {
                case Options.Add:
                    addingBookHelper();
                    break;
                case Options.Remove:
                    break;
                case Options.Author:
                    findingBookByAuthorHelper();
                    break;
                case Options.Title:
                    break;
                case Options.Update:
                    updatingBookHelper();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void addingBookHelper()
        {
            int id = Utilities.GetNumber("Enter the Id of Book : ");
            string Title = Utilities.Prompt("Enter the Title of Book : ");
            string Author = Utilities.Prompt("Enter the Author of Book : ");
            double Price = Utilities.GetNumber("Enter the Price of Book : ");
            string Publisher = Utilities.Prompt("Enter the Publisher of Book : ");
            int BookStock = Utilities.GetNumber("Enter the BookStock of Book : ");
            Book book = new Book
            {
                BookId = id,
                Author = Author,
                BookTitle = Title,
                BookStock = BookStock,
                Price = Price,
                Publisher = Publisher
            };
            repo.AddNewBook(book);
            Console.WriteLine(book.BookId);
            Console.WriteLine(book.BookTitle);
            Console.WriteLine(book.Author);
            Console.WriteLine(book.BookStock);
        }
        private static void updatingBookHelper()
        {
            int id = Utilities.GetNumber("Enter the Id of Book : ");
            string Title = Utilities.Prompt("Enter the NewTitle of Book : ");
            string Author = Utilities.Prompt("Enter the NewAuthor of Book : ");
            double Price = Utilities.GetNumber("Enter the Price of Book : ");
            string Publisher = Utilities.Prompt("Enter the NewPublisher of Book : ");
            int BookStock = Utilities.GetNumber("Enter the NewBookStock of Book : ");
            Book book = new Book
            {
                BookId = id,
                Author = Author,
                BookTitle = Title,
                BookStock = BookStock,
                Price = Price,
                Publisher = Publisher
            };
            repo.UpdateBook(book);

        }
        private static void findingBookByAuthorHelper()
        {
            string Author = Utilities.Prompt("Enter the Author of Book : ");
          
            try
            {
                Console.WriteLine("1");
                Book[] book = repo.FindByAuthor(Author);

              
                Console.WriteLine("The Details of the Account are as follows:");

                foreach (Book item in book)
                {
                    Console.WriteLine($"The Title: {item.BookTitle}\nThe Price : {item.Price}\nThe Book ID No: {item.BookId}" +
                        $"\nThe Book Stock: {item.BookStock}\nThe Book Publisher: {item.Publisher}");
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }


    namespace TestingApp
    {
        using Repository;
        using System;


        class App
        {
            static void Main(string[] args)
            {
                UILayer.UIComponent.Run();
            }
        }
    }
}