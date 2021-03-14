using ClosedXML.Excel;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableExtensions
{
    public class ReadColumnNameByColumnIndex : CodeActivity
    {
        [RequiredArgument]
        [Category("Input")]
        public InArgument<string> WorkbookPath { get; set; }

        [Category("Input")]
        public InArgument<int> SheetIndex { get; set; }

        [Category("Output")]
        public OutArgument<string> SheetName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var workbook = new XLWorkbook(WorkbookPath.Get(context)))
            {
                var workSheet = workbook.Worksheet(SheetIndex.Get(context));
                if (workSheet == null)
                    throw new InvalidOperationException("Worksheet is not in a valid range");

                SheetName.Set(context, workSheet.Name);
            }
        }
    }
}
