
namespace _01_MobileBg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Producer
    {
        public Producer()
            : this(string.Empty, new List<string>())
        {
        }

        public Producer(string name)
            : this(name, new List<string>())
        {
        }

        public Producer(string name, IEnumerable<string> models)
        {
            this.Name = name;
            this.Models = models;
        }

        public string Name { get; set; }

        public IEnumerable<string> Models { get; set; }
    }
}