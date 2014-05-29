namespace Zubrs.Mvc.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public bool IsActive { get; set; }
        public MenuItem[] SubItems { get; set; }
    }
}