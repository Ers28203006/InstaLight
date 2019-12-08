using InstagramLightWebClient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramLightWebClient.Controllers
{
    public class PostController : Controller
    {
        InstagramLightModel db = new InstagramLightModel();
        public ActionResult Index()
        {
            IEnumerable<Post> posts = db.Posts;
            ViewBag.Posts=posts;
            return View();
        }
        public ActionResult Counter(int id)
        {
            var like=db.Posts.Where(i=>i.Id==id).FirstOrDefault();
            like.Like+=1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase upload, string text, int like=0)
        {
            Post post = new Post();
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                var photoPath = "http://localhost:58501/Files/"+fileName;
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                post.PhotoPath = photoPath;
                post.Like = like;
            }
            if (text!=null)
            {
                post.Description = text;
            }
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}