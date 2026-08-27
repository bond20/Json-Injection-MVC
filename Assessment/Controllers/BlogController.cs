using Assessment.Interface;
using Assessment.Service;
using System.Linq;
using System.Web.Mvc;

namespace Assessment.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogController() : this(new BlogPostService())
        {
        }

        internal BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public ActionResult Index(int? id)
        {
            var posts = _blogPostService.GetAllBlogPosts();
            var post = id.HasValue
                ? _blogPostService.GetBlogPostById(id.Value)
                : posts.OrderByDescending(blogPost => blogPost.Date).FirstOrDefault();

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
    }
}
