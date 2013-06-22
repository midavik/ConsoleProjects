using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Spelling
{
    public class CodeMapping
    {
        public int Code { get; set; }
        public int RepeatCodeNr { get; set; }

        public CodeMapping(int code, int repeatCodeNr)
        {
            Code = code;
            RepeatCodeNr = repeatCodeNr;
        }
    }
}
