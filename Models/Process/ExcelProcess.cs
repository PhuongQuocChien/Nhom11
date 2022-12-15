using System.Data;
using OfficeOpenXml;

namespace BaiTapNhom11.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is completely empty(kiểm tra xem trang tính có hoàn toàn trống không)
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //create a list to hold the column names(tạo một danh sách để giữ tên cột)
            List<string> columnNames = new List<string>();
            //needed to keep track of empty column headers(cần thiết để theo dõi các tiêu đề cột trống)
            int currentColumn = 1;
            //loop all column in the sheet and add them to the database(lặp tất cả các cột trong trang tính và thêm chúng vào cơ sở dữ liệu)
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();
                //check if the previous header was empty and add it if it was(kiểm tra xem tiêu đề trước đó có trống không và thêm nó nếu có)
                if(cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                //add the colunm name to the list to count the duplicates(thêm tên cột vào danh sách để đếm các bản sao)
                columnNames.Add(columnName);
                //count the duplicate column names and make them unique to avoid the exception(đếm các tên cột trùng lặp và làm cho chúng trở thành duy nhất để tránh ngoại lệ)
                //A column named 'Name' already belongs to this DataBase(Một cột có tên 'Tên' đã thuộc về Cơ sở dữ liệu này)
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }
                //add the column to the datable(thêm cột vào datable)
                dt.Columns.Add(columnName);
                currentColumn++;
            }

            //start adding the contents of the excel file to the datable(bắt đầu thêm nội dung của tệp excel vào datable)
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
                //loop all cells in the row(lặp tất cả các ô trong hàng)
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}