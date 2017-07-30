using System.Collections.Generic;

namespace Site.Web.Models.Views
{
    public class EventList
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private List<string> events;

        public List<string> Events
        {
            get { return events; }
            set { events = value; }
        }
    }
}