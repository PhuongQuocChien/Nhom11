using System.Text.RegularExpressions;

namespace BaiTapNhom11.Models.Process
{
    public class StringProcess
    {
        public string AutoGenerateCode(string strInput)
        {
            string strResult = "", numPart = "", strPart = "";
            //Tách số và chữ
            numPart = Regex.Match(strInput, @"\d+").Value;
            //Tách chữ
            strPart = Regex.Match(strInput, @"\D+").Value;
            //Tăng lên 1 đơn vị
            int intPart = (Convert.ToInt32(numPart) + 1);
            //Bổ sung các đơn vị thiếu 0
            for (int i = 0; i < numPart.Length - intPart.ToString().Length; i++)
            {
                strPart += "0";
            }
            //Ghep phần chữ với phần số
            strResult = strPart + intPart;
            return strResult;
        }
    }
}