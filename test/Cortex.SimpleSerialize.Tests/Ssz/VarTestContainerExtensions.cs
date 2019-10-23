using System.Collections.Generic;
using System.Linq;
using Cortex.SimpleSerialize.Tests.Containers;

namespace Cortex.SimpleSerialize.Tests.Ssz
{
    internal static class VarTestContainerExtensions
    {
        public static SszContainer ToSszContainer(this VarTestContainer item)
        {
            return new SszContainer(GetChildren(item));
        }

        private static IEnumerable<SszElement> GetChildren(VarTestContainer item)
        {
            yield return new SszBasicElement(item.A);
            yield return new SszBasicList(item.B.ToArray(), limit: 1024);
            yield return new SszBasicElement(item.C);
        }
    }
}
