using System;
using System.Collections.Generic;

namespace Dictionary.Models
{
    public partial class LevelTwoClass
    {
        public int LevelOneClassId { get; set; }
        public int LevelTwoClassId { get; set; }
        public string LevelTwoClassDescription { get; set; }
        public string LevelTwoClassAbb { get; set; }
    }
}
