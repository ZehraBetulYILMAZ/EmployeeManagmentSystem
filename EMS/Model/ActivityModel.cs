using System;

namespace EMS.WebUI.Model
{
    public class ActivityModel
    {
        public string eventName { get; set; }
        public bool isActive { get; set; }
        public string type { get; set; }
        public DateTime? eventDate { get; set; }
        public string info { get; set; }



    }
} 