using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1___Task_Manager
{
    public static class TaskInit
    {
        //Creates an array of tasks
        public static List<Task> GetTasks()
        {
            //Create initial set of tasks
            Random rand = new Random();
            Task t1 = new Task("Feed the cat", "Feed Felix when I get home", GetRandomDate(rand), AssignLabels(rand));
            Task t2 = new Task("Get Milk", "Get milk for coffee", GetRandomDate(rand), AssignLabels(rand));
            Task t3 = new Task("Email Boss", "Send email re: holidays", GetRandomDate(rand), AssignLabels(rand));
            Task t4 = new Task("Dentist", "Book dentist appt", GetRandomDate(rand), AssignLabels(rand));
            Task t5 = new Task("Finish CA1", "Finish CA1 for FOOP202", GetRandomDate(rand), AssignLabels(rand));

            List<Task> TaskList = new List<Task>();
            TaskList.Add(t1);
            TaskList.Add(t2);
            TaskList.Add(t3);
            TaskList.Add(t4);
            TaskList.Add(t5);

            return TaskList;
        }

        //Generate random Dates in a range for Due date
        public static DateTime GetRandomDate(Random r)
        {
            //Code taken from lab 3
            DateTime startDate = DateTime.Today;
            DateTime endDate = new DateTime(2100, 12, 31);
            TimeSpan span = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, r.Next(0, (int)span.TotalMinutes), 0);
            return (startDate + newSpan);
        }

        public static string AssignLabels(Random r)
        {
            string[] labels = { "Work", "Home", "Family", "Medical", "Pets", "Food", "Money", "Car", "Friends", "Other"};
            List<string> assignedLabels = new List<string>();
            string returnedLabels;
            int randomIndex = 0;
            bool isUnique = true;
            //TODO: Add logic to assign random labels
            for (int i = 0; i < 4; i++)
            {
                randomIndex = r.Next(r.Next(0, 9));
                foreach (var lab in assignedLabels)
                {
                    if (labels[randomIndex] == lab)
                        isUnique = false;
                    else
                        isUnique = true;
                }
                if(isUnique)
                    assignedLabels.Add(labels[randomIndex]);
            }
            if (assignedLabels.Count == 0)
                assignedLabels.Add(labels[9]);
            returnedLabels = string.Join(",", assignedLabels.ToArray());
            return returnedLabels;
        }
    }
}
