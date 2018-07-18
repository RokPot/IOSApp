using System;


namespace MobileUtripPro.Models
{
    public class CheckItem 
    {
        public string CheckTitle { get; set; }

        public string CheckDescription { get; set; }

        public string NativeNumber { get; set; }

        public string Sarza { get; set; }

        public string Notes { get; set; }

        public bool IsChecked { get; set; } = false;
    }
}
