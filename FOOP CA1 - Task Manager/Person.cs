using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1___Task_Manager
{
    abstract class Person
    {
        public string Name { get; set; }
    }

    class Family:Person
    {
        enum Reltaion { Parent, Child, Spouse, Partner, Sibling, Friend, Other}

    }

    class Colleague : Person
    {
        enum WorkRelation { Superior, Equal, Subordinate}
    }
}
