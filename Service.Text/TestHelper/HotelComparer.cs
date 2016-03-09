using DataModel.EntityModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Text.TestHelper
{
    public class HotelComparer : IComparer, IComparer<Hotel>
    {
        public int Compare(object expected, object actual)
        {
            var lhs = expected as Hotel;
            var rhs = actual as Hotel;
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            return Compare(lhs, rhs);
        }

        public int Compare(Hotel expected, Hotel actual)
        {
            int temp;
            return (temp = expected.Id.CompareTo(actual.Id)) != 0 ? temp : expected.Hotel_Name.CompareTo(actual.Hotel_Name);
        }
    }
}
