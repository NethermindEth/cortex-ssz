using System.Collections.Generic;
using Cortex.SimpleSerialize.Tests.Containers;

namespace Cortex.SimpleSerialize.Tests.Ssz
{
    // Define builder extensions that construct SSZ elements from containers

    internal static class FixedTestContainerExtensions
    {
        public static SszContainer ToSszContainer(this FixedTestContainer item)
        {
            return new SszContainer(GetValues(item));
        }

        private static IEnumerable<SszElement> GetValues(FixedTestContainer item)
        {
            yield return new SszBasicElement(item.A);
            yield return new SszBasicElement(item.B);
            yield return new SszBasicElement(item.C);
        }
    }
}
