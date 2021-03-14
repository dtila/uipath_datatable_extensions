using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataTableExtensions.Tests
{
    public class ReadColumnNameByColumnIndexTests
    {
        public readonly ReadColumnNameByColumnIndex _activity = new ReadColumnNameByColumnIndex();


        [Theory]
        [InlineData("Excels\\Current Asset Report.xlsx", 1, "MER_F1_dce2934d4c05c88274b599e9")]
        public void WhenFileIsValid_ColumnNameIsReadCorrectly(string excelPath, int position, string expectedColumnName)
        {
            var parameters = new Dictionary<string, object>
            {
                { nameof(ReadColumnNameByColumnIndex.WorkbookPath), excelPath},
                { nameof(ReadColumnNameByColumnIndex.SheetIndex), position },
            };

            var properties = WorkflowInvoker.Invoke(_activity, parameters);
            var sheetName = (string)properties[nameof(ReadColumnNameByColumnIndex.SheetName)];

            sheetName.Should().Be(expectedColumnName);
        }
    }
}
