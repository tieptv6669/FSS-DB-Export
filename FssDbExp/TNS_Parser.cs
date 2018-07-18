using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FssDbExp
{
    public class TNS_Parser
    {
        public static string getTnsFileContent(string FP)
        {
            string inputString = "";
            try
            {
                StreamReader streamReader = File.OpenText(FP.Trim()); // FP is the filepath of TNS file
                inputString = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return inputString;
        }

        public static List<string> getListTnsName(string inputString)
        {
            List<string> List = new List<string>();
            inputString = inputString.Replace("\r", "").Replace(" ", "");
            try
            {
                string[] temp = inputString.Split('\n');
             
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Trim(' ', '(').Contains("DESCRIPTION"))
                    {
                        string DS = temp[i - 1].Trim('=', ' ');
                        List.Add(DS);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return List;
        }

        public static List<string> listConnectionStr(List<string> listTnsName, string tnsFileContent)
        {
            List<string> result = new List<string>();
            tnsFileContent = tnsFileContent.Replace("\r", "").Replace(" ", "").Replace("\n", "");
            int startIndex, length;
            for (int x = 0; x < listTnsName.Count - 1; x++)
            {
                startIndex = tnsFileContent.IndexOf(listTnsName[x]) + listTnsName[x].Length + 1;
                length = tnsFileContent.IndexOf(listTnsName[x + 1]) - startIndex;
                result.Add( tnsFileContent.Substring(startIndex, length).Trim().Replace("\n", "").Replace("\r", "").Replace(" ", ""));
            }

            startIndex = tnsFileContent.IndexOf(listTnsName[listTnsName.Count - 1]) + listTnsName[listTnsName.Count - 1].Length + 1;
            length = tnsFileContent.Length - startIndex;
            result.Add(tnsFileContent.Substring(startIndex, length).Trim().Replace("\n", "").Replace("\r", "").Replace(" ", ""));

            return result;
        }
    }
}
