using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableExtensions
{
    /// <summary>
    /// A split operation
    /// </summary>
    public readonly struct SplitOperation
    {
        /// <summary>
        /// The split DataTable
        /// </summary>
        public DataTable DataTable { get; }

        /// <summary>
        /// The 0 indexed starting index, where this DataTable was created from
        /// </summary>
        public int StartingIndex { get; }

        public SplitOperation(DataTable dataTable, int startingIndex)
        {
            DataTable = dataTable ?? throw new ArgumentNullException(nameof(dataTable));
            StartingIndex = startingIndex;
        }

        /// <summary>
        /// Returns an Excel column name starting position that this <see cref="DataTable"/> can be written to
        /// </summary>
        /// <param name="columnName">The Excel column naming. By default the value is A</param>
        /// <returns>An Excel column format like A1</returns>
        public string ExcelNumbering(string columnName = "A") => columnName + (StartingIndex + 1);
    }
}
