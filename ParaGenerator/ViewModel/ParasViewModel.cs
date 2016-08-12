using ParaGenerator.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ParaGenerator.ViewModel
{
    public class ParasViewModel
    {


        private List<Para> paras = new List<Para>();

        private List<SelectListItem> ParaLeft;
        public List<Para> Paras
        {
            get
            {
                return paras;


            }
        }
    }


}