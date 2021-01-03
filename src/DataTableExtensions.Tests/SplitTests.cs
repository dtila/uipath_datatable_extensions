using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataTableExtensions.Tests
{
    public class SplitTests
    {
        [Fact]
        public void WhenNoRow_DataTable_IsEmpty()
        {
            var input = new DataTable();
            input.Columns.Add("Test", typeof(string));

            input.Split(0, 10).DataTable.Rows.Count.Should().Be(0);
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(50, 10)]
        [InlineData(50, 50)]

        public void WhenManyRows_DataTableIsSplit_ExpectedRowMatch(int rowNumber, int expectedSplit)
        {
            var input = GenerateDataTable(rowNumber);

            input.Split(0, expectedSplit).DataTable.Rows.Count.Should().Be(expectedSplit);
        }

        [Theory]
        [InlineData(50, 30)]
        [InlineData(50, 2)]

        public void WhenManyRows_DataTableIsSplit_TotalBatchesIsEqual(int rowNumber, int batchSize)
        {
            var input = GenerateDataTable(rowNumber);

            var total = 0;
            foreach (var batch in input.Split(batchSize))
            {
                total += batch.DataTable.Rows.Count;

                batch.DataTable.Rows.Count.Should().BeLessOrEqualTo(batchSize);
            }

            total.Should().Be(rowNumber);
        }


        private DataTable GenerateDataTable(int rows)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Index", typeof(int));
            dataTable.Columns.Add("Value", typeof(string));
            dataTable.Columns.Add("InsertedDate", typeof(DateTime));

            for (int i=0; i<rows; i++)
            {
                dataTable.Rows.Add(new object[] { i, "Generated row nr " + i.ToString(), DateTime.Now.AddMinutes(i) });
            }

            return dataTable;
        }
    }
}
