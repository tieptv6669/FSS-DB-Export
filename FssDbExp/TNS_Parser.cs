using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FssDbExp
{
    /// <summary>
    /// Owner: Tiep TV
    /// Create date: 19/7/2018
    /// </summary>
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
                MessageBox.Show(e.Message, TNSModel.owner, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Logging(e.Message, DateTime.Now.ToString());
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
                MessageBox.Show(e.Message, TNSModel.owner, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Logging(e.Message, DateTime.Now.ToString());
            }

            return List;
        }

        public static List<TNSModel> listConnectionStr(List<string> listTnsName, string tnsFileContent)
        {
            List<TNSModel> result = new List<TNSModel>();
            try
            {
                tnsFileContent = tnsFileContent.Replace("\r", "").Replace(" ", "").Replace("\n", "");
                int startIndex, length;
                for (int x = 0; x < listTnsName.Count - 1; x++)
                {
                    TNSModel tNSModel = new TNSModel();
                    tNSModel.TnsName = listTnsName[x];
                    startIndex = tnsFileContent.IndexOf(listTnsName[x]) + listTnsName[x].Length + 1;
                    length = tnsFileContent.IndexOf(listTnsName[x + 1]) - startIndex;
                    tNSModel.DataSource = tnsFileContent.Substring(startIndex, length).Trim().Replace("\n", "").Replace("\r", "").Replace(" ", "");
                    result.Add(tNSModel);
                }

                startIndex = tnsFileContent.IndexOf(listTnsName[listTnsName.Count - 1]) + listTnsName[listTnsName.Count - 1].Length + 1;
                length = tnsFileContent.Length - startIndex;
                TNSModel temp = new TNSModel();
                temp.TnsName = listTnsName[listTnsName.Count - 1];
                temp.DataSource = tnsFileContent.Substring(startIndex, length).Trim().Replace("\n", "").Replace("\r", "").Replace(" ", "");
                result.Add(temp);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, TNSModel.owner, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Logging(e.Message, DateTime.Now.ToString());
            }
            return result;
        }
    }
}
