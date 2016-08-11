using ParaGenerator.Models;
using ParaGenerator.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace ParaGenerator.Controllers
{
    public class HomeController : Controller
    {

        private ParaDBEntities db = new ParaDBEntities();
        public ActionResult Index()
        {
            /*
            1. initialize -> copy all data from para to paraleft
            2. get ids in paraleft
            3. through ids of paraLeft, get text from Paras
            4. return coresponding data to view
             
             */

            db.initialize();

            var ids = db.ParaLefts.Select(p => p.ParaId).ToList();

            var viewModel = new ParasViewModel();

            foreach (var id in ids)
            {
                var para = db.Paras.Single(p => p.ParaId == id);


                //viewModel.add(para as Para);
                viewModel.Paras.Add(para);
            }

            return View("ParaLeft", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}