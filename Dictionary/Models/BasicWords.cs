using System;
using System.Collections.Generic;

namespace Dictionary.Models
{
    public partial class BasicWords
    {
        public string Word { get; set; }
        public string Explain { get; set; }
        public int? TypeId { get; set; }
        public int? ClassOneId { get; set; }
        public int? ClassTwoId { get; set; }
    }
}
