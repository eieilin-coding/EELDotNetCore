using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EELDotNetCore.ConsoleAppRefitExamples
{
    internal class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("http://localhost:5179");
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(100);
            await CreateAsync("title r1", "author r1", "content r1");
            //await UpdateAsync(24, "title 1", "author 2", "content 3");
            //await EditAsync(24);
        }
        private async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id => {item.BlogID}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
        }
        private async Task EditAsync(int id)
        {
            // Refit.ApiException: 'Response status code does not indicate success : 404 (not found).
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlogID}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
            catch(ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message);
        }
        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            var message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }
        private async Task DeleteAsync(int id)
        {
            try
            {
                var message = await _service.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
