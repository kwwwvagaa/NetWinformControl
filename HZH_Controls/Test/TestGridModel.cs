using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class TestGridModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public List<TestGridModel> Childrens { get; set; }
    }
}
