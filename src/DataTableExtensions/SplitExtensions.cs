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
        /// <summary>
        /// Split the current DataTable by the row number specified by parameters <paramref name="skip"/> and <paramref name="take"/>
        /// </summary>
        /// <param name="input">The input <seealso cref="DataTable"/> that is given to be split</param>
        /// <param name="skip">Number of rows that are skipped from top to bottom</param>
        /// <param name="take">Number of rows that are included in the resulted <seealso cref="DataTable"/></param>
        /// <returns>A new DataTable that matches the original structure of the one specified in the input</returns>
        public static SplitOperation Split(this DataTable input, int skip, int take)
        {
            DataTable dtn = input.Clone();
            for (int index = skip, count = 0; index < input.Rows.Count && count < take; index++, count++)
            {
                dtn.ImportRow(input.Rows[index]);
            }

            return new SplitOperation(dtn, skip);
        }

        /// <summary>
        /// Split a DataTable equally in number of batches by the row number
        /// </summary>
        /// <param name="input"></param>
        /// <param name="batchSize"></param>
        /// <returns></returns>
        public static IEnumerable<SplitOperation> Split(this DataTable input, int batchSize)
        {
            for (int i=0; i<input.Rows.Count; i+=batchSize)
            {
                yield return Split(input, i, batchSize);
            }
        }
    }
}
