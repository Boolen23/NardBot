using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Command
    {
        public static Command FromString(string str)
        {
            var commandData = str.Split().Select(i => i.Trim()).Select(int.Parse).ToArray();
            return new Command() { SourceFourth = commandData[0], SourceCellNumber = commandData[1], MoveCount = commandData[2] };
        }
        public int SourceFourth { get; set; }
        public int SourceCellNumber { get; set; } 
        public int MoveCount { get; set; }

        public override string ToString()
        {
            return $"{SourceFourth}-{SourceCellNumber}-{MoveCount}";
        }
    }
}
