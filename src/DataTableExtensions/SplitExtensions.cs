using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableExtensions
{
    public static class SplitExtensions
    {
        public static DataTable Split(this DataTable input, int skip, int take)
        {
            DataTable dtn = input.Clone();
            for (int index = skip, count = 0; index < input.Rows.Count && count < take; index++, count++)
            {
                dtn.ImportRow(input.Rows[index]);
            }

            return dtn;
        }

        public static IEnumerable<DataTable> Split(this DataTable input, int batchSize)
        {
            for (int i=0; i<input.Rows.Count; i+=batchSize)
            {
                yield return Split(input, i, batchSize);
            }
        }
    }
}
