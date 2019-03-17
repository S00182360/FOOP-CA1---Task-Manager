using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1___Task_Manager
{
    public class Task: IComparable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> Labels { get; set; }
        //public Person ShareWith { get; set; }
        //public enum Priority { None, Low, Medium, High}
        public Task(string title, string description, DateTime dueDate, string labelString)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            SetLabels(labelString);
        }

        public Task()
        {

        }

        public void SetLabels(string labelStr)
        {
            string[] labelArr = labelStr.Split(',');
            foreach (var lab in labelArr)
            {
                Labels.Add(lab);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}", Title, DueDate.ToString("dd/MM/yyyy"), Description);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
