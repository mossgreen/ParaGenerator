using ParaGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParaGenerator.ViewModel
{
    public class ParasViewModel
    {

        public IEnumerable<Para> Paras { get; set; }

        public void Add(Para p)
        {

            Paras.ToList().Add(p);
        }
    }
}