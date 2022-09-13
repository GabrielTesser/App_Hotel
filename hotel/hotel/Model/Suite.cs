using System;
using System.Collections.Generic;
using System.Text;

namespace hotel.Model
{
    public class Suite
    {
        public string Nome { get; set; }
        public double DiariaAdulto { get; set; }
        public double DiariaCrianca
        {
            get; set;
        }
    }
}
