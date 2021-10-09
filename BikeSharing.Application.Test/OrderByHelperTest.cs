using BikeSharing.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BikeSharing.Application.Test
{
    public class OrderByHelperTest
    {
        [Theory]
        [MemberData(nameof(IntDataProvider))]
        public void OrderByAscendingIntTest(List<DummyForOrderBy> expected, List<DummyForOrderBy> data)
        {
            data = OrderByHelper.OrderBy(data, "Id ASC").ToList();
            bool haci = expected.SequenceEqual(data);
            Assert.Equal(expected, data, new IntClassComparer());
        }
        //TODO ASSERT EQUEAL CALISMIYOR 
        public static IEnumerable<object[]> IntDataProvider =>
           new List<object[]>
           {
                new object[] { new List<DummyForOrderBy> { new DummyForOrderBy { Id = 1 }, new DummyForOrderBy { Id = 2 }, new DummyForOrderBy { Id = 3 }, new DummyForOrderBy { Id = 4 } },
                    new List<DummyForOrderBy>{ new DummyForOrderBy { Id = 3 }, new DummyForOrderBy { Id = 2 } , new DummyForOrderBy { Id = 1 }, new DummyForOrderBy { Id = 4}} }
           };

        public class DummyForOrderBy
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class IntClassComparer : IEqualityComparer<DummyForOrderBy>
        {
            public bool Equals(DummyForOrderBy x, DummyForOrderBy y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(DummyForOrderBy obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
