using System.Collections.Generic;

namespace FssDbExp
{
    public class PathMaster
    {
        public List<string> ListPath { get; set; }

        public PathMaster(string verName, bool isBDSHOST, bool isHOST, string dirType, string rootPath)
        {
            ListPath = new List<string>();
            if(dirType == "FlexDB")
            {
                // level 1
                ListPath.Add(rootPath + "\\" + "1.Objects");
                ListPath.Add(rootPath + "\\" + "2.Service");
                ListPath.Add(rootPath + "\\" + "3.Client");
                ListPath.Add(rootPath + "\\" + "4.Reports");
                ListPath.Add(rootPath + "\\" + "5.Templates");

                // level 2
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "1.View");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "2.Trigger");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "3.Procedure");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "4.Function");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "5.Package");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "6.Type");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "8.HotfixScript");

                ListPath.Add(rootPath + "\\" + "2.Service" + "\\" + "1.HostService");
                ListPath.Add(rootPath + "\\" + "2.Service" + "\\" + "2.BdsService");

                // level 3
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts" + "\\" + "1.BDSHOST");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts" + "\\" + "2.HOST");

                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "ALLCODE");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPMODULES");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPRULES");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPRVRQD");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPTX");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "CMDMENU");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "CRBTXMAP");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "CRBTXMAPEXT");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "DEFERROR");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FEEMAP");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FEEMASTER");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FILEMAP");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FILEMASTER");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "TRANS");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "PRCHK");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "RPTFIELDS");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "RPTMASTER");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "SBBATCHCTL");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "SEARCH_SEARCHFLD");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "SYSVAR");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "GRMASTER");

                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "8.HotfixScript" + "\\" + "1.BDSHOST");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "8.HotfixScript" + "\\" + "2.HOST");

                if(verName.Length > 0)
                {
                    if (isBDSHOST)
                    {
                        ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts" + "\\" + "1.BDSHOST" + "\\" + verName);
                    }
                    if (isHOST)
                    {
                        ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts" + "\\" + "2.HOST" + "\\" + verName);
                    }
                }
            }

            if(dirType == "FDSFlexDB")
            {
                // level 1
                ListPath.Add(rootPath + "\\" + "1.Objects");
                ListPath.Add(rootPath + "\\" + "2.Service");
                ListPath.Add(rootPath + "\\" + "3.Client");
                ListPath.Add(rootPath + "\\" + "4.Reports");
                ListPath.Add(rootPath + "\\" + "5.Templates");

                // level 2
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "1.View");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "2.Trigger");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "3.Procedure");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "4.Function");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "5.Package");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "6.Type");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "8.HotfixScript");

                ListPath.Add(rootPath + "\\" + "2.Service" + "\\" + "1.HostService");
                ListPath.Add(rootPath + "\\" + "2.Service" + "\\" + "2.BdsService");

                // level 3
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FDSSTATICSDATA");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPMODULES");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPRULES");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPRVRQD");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "APPTX");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "CMDMENU");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "VSDTXMAP");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "VSDTXMAPEXT");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "DEFERROR");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FEEMAP");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FEEMASTER");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FILEMAP");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FILEMASTER");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "TRANS");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "PRCHK");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "RPTFIELDS");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "RPTMASTER");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FDSBATCHCTL");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "SEARCH_SEARCHFLD");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "FDSSYSCONFIG");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "VSDTRFCODE");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "VSDBICCODE");
                ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "7.Parameters" + "\\" + "GRMASTER");

                if (verName.Length > 0)
                {
                    ListPath.Add(rootPath + "\\" + "1.Objects" + "\\" + "0.ChangeScripts" + "\\" + verName);
                }
            }
        }
    }
}
