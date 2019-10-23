using System.Collections.Generic;
using System.Linq;
using Cortex.SimpleSerialize.Tests.Containers;

namespace Cortex.SimpleSerialize.Tests.Ssz
{
    internal static class SingleFieldTestContainerExtensions
    {
        public static SszContainer ToSszContainer(this SingleFieldTestContainer item)
        {
            return new SszContainer(GetChildren(item));
        }

        public static SszElement ToSszList(this IEnumerable<SingleFieldTestContainer> list, ulong limit)
        {
            return new SszList(list.Select(x => x.ToSszContainer()), limit);
        }

        private static IEnumerable<SszElement> GetChildren(SingleFieldTestContainer item)
        {
            yield return new SszBasicElement(item.A);
        }
    }
}
