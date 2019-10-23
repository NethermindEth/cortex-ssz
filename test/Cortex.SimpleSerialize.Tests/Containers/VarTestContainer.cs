using System.Collections.Generic;

namespace Cortex.SimpleSerialize.Tests.Containers
{
    internal class VarTestContainer
    {
        public ushort A { get; set; }
        public IList<ushort> B { get; set; } = new List<ushort>(); // max = 1024
        public byte C { get; set; }
    }
}
