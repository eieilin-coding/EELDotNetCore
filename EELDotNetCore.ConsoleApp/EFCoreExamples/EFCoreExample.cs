using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EELDotNetCore.ConsoleApp.Dtos;

namespace EELDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        //private readonly AppDbContext db = new AppDbContext();

        private readonly AppDbContext db;

        public EFCoreExample(AppDbContext db)
        {
            this.db = db;
        }

        public void Run()
        {
            Read();
            //Edit(1);
            //Edit(17);
            //Create("title Dependency", "author Dependency", "content Injection");
            //Update(18, "title", "author", "content");
            //Delete(7);
            //Delete(8);
            //Delete(9);
        }

        private void Read()
        {
            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving successful" : "Saving Fail";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Updating successful" : "Updating Fail";
            Console.WriteLine(message);

        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting successful" : "Deleting Fail";
            Console.WriteLine(message);
        }
    }
}
