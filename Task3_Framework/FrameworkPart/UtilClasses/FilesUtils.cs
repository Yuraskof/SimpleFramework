using System;
using System.IO;
using log4net;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class FilesUtils
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static bool CheckDownloadFile(string name)
        {
            DirectoryInfo downloadDir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\downloads");
            FileInfo[] downloadFiles = downloadDir.GetFiles(name);
            DateTime dateTime = DateTime.Now;

            while (downloadFiles.Length == 0)
            {
                if (dateTime.AddSeconds(Convert.ToInt32(DriverUtils.BrowserConfig["wait_time"])) < DateTime.Now)
                {
                    log.Info(string.Format("File {1} download isn't completed during = {0} sec", DriverUtils.BrowserConfig["wait_time"], name));
                    return false;
                }
                downloadFiles = downloadDir.GetFiles(name);
            }
            log.Info(string.Format("File {0} download completed", name));
            return true;
        }

        public static void ClearDownloadFolder()
        {
            if (Directory.Exists(@Directory.GetCurrentDirectory() + "\\downloads"))
            {
                log.Info("Download folder cleared");
                System.IO.DirectoryInfo directory = new DirectoryInfo(@Directory.GetCurrentDirectory() + "\\downloads");

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
            }
        }
    }
}
