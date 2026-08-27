using Assessment.Interface;
using Assessment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Assessment.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly List<BlogPostModel> _blogPosts;

        public BlogPostService()
        {
            _blogPosts = LoadBlogPosts();
        }

        public List<BlogPostModel> GetAllBlogPosts()
        {
            return _blogPosts;
        }

        public BlogPostModel GetBlogPost(int id)
        {
            return _blogPosts.FirstOrDefault(post => post.Id == id);
        }

        public BlogPostModel GetBlogPostById(int id)
        {
            return GetBlogPost(id);
        }

        public List<BlogPostModel> GetBlogPosts()
        {
            return _blogPosts;
        }

        private static List<BlogPostModel> LoadBlogPosts()
        {
            var jsonFilePath = ResolveJsonPath();
            if (string.IsNullOrWhiteSpace(jsonFilePath) || !File.Exists(jsonFilePath))
            {
                return new List<BlogPostModel>();
            }

            var jsonString = File.ReadAllText(jsonFilePath);
            var document = JsonConvert.DeserializeObject<BlogPostsDocument>(jsonString);
            return document == null || document.BlogPosts == null
                ? new List<BlogPostModel>()
                : document.BlogPosts;
        }

        private static string ResolveJsonPath()
        {
            try
            {
                var hostedPath = HostingEnvironment.MapPath("~/App_Data/Blog-Posts.json");
                if (!string.IsNullOrWhiteSpace(hostedPath))
                {
                    return hostedPath;
                }
            }
            catch (InvalidOperationException)
            {
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Blog-Posts.json");
        }

        private sealed class BlogPostsDocument
        {
            [JsonProperty("blogPosts")]
            public List<BlogPostModel> BlogPosts { get; set; }
        }
    }
}
