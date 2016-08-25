namespace CodeRefactoringEvents
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> orderedByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> orderedByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location, StringBuilder output)
        {
            Event newEvent = new Event(date, title, location);

            this.orderedByTitle.Add(title.ToLower(), newEvent);
            this.orderedByDate.Add(newEvent);

            Messages.EventAdded(output);
        }

        public void DeleteEvents(string titleToDelete, StringBuilder output)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.orderedByTitle[title])
            {
                removed++;
                this.orderedByDate.Remove(eventToRemove);
            }

            this.orderedByTitle.Remove(title);
            Messages.EventDeleted(removed, output);
        }

        public void ListEvents(DateTime date, int count, StringBuilder output)
        {
            OrderedBag<Event>.View eventsToShow = this.orderedByDate.RangeFrom(new Event(date, "", ""), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow, output);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound(output);
            }
        }
    }
}
