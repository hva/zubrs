using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class HomeViewModel
    {
        public Game[][] Games { get; set; }
        public Article[] GeneralNews { get; set; }
        public Article[] KidNews { get; set; }
        public Video Video { get; set; }
    }
}