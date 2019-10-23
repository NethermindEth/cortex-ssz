using System.Collections.Generic;
using Cortex.SimpleSerialize.Tests.Containers;

namespace Cortex.SimpleSerialize.Tests.Ssz
{
    internal static class SmallTestContainerExtensions
    {
        public static SszContainer ToSszContainer(this SmallTestContainer item)
        {
            return new SszContainer(GetChildren(item));
        }

        private static IEnumerable<SszElement> GetChildren(SmallTestContainer item)
        {
            yield return new SszBasicElement(item.A);
            yield return new SszBasicElement(item.B);
        }
    }
}
