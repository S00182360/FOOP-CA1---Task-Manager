using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1___Task_Manager
{
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<string> Labels { get; set; }
        public Person ShareWith { get; set; }
        public enum Priority { None, Low, Medium, High}

    }

    class WorkTask : Task
    {

    }
}
