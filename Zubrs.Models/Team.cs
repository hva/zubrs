﻿namespace Zubrs.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public bool ShowInMenu { get; set; }
        public int Sortorder { get; set; }
    }
}