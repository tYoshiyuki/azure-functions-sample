using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionSettingSample.Configs
{
    public class AppConfig
    {
        public string Name { get; set; }
        public Props Props { get; set; }
    }

    public class Props
    {
        public string First { get; set; }
        public string Second { get; set; }
    }
}
