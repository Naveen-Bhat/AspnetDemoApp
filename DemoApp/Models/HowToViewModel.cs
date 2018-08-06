using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class HowToViewModel
    {
        public HowToViewModel()
        {
            this.HowToElements = new List<HowToElementViewModel>();
        }

        public List<HowToElementViewModel> HowToElements { get; set; }
    }
}
