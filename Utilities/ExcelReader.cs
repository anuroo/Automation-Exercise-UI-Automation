
using ClosedXML.Excel;
using Spire.Xls.Core.Spreadsheet;

namespace AutomationFramework.Utilities
{
    public class ExcelReader
    {
    public List<Dictionary<string,string>> ReadExcelData(string filePath,string sheetName)
    {
        var dataList=new List<Dictionary<string,string>>();
        using(var workbook=new XLWorkbook(filePath))
        {
            var worksheet=workbook.Worksheet(sheetName);
	        var rows=worksheet.RangeUsed().RowsUsed();
            var headersRow=rows.First();
	        var headers=headersRow.Cells().Select(c => c.Value.ToString()).ToList();
	        foreach(var row in rows.Skip(1))
            {	     
		        var dict=new Dictionary<string,string>();
		        for(int i=0;i<headers.Count;i++)
		    {
			        dict[headers[i]]=row.Cell(i+1).Value.ToString();
            		dataList.Add(dict);
      		}
            }
            return dataList;
        }
    }
    }
}
