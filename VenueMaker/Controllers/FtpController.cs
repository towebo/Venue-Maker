using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VenueMaker.Utils;

namespace VenueMaker.Controllers
{
    public class FtpController
    {
        private static FtpController me;
        private List<string> uploadqueue;
        private List<string> filesonserver;

        private string FtpHost = "ftp://ftp.towebo.se/";
        private string FtpUser = "160040_master";
        private string FtpPw = "ftpATtowebo.se";
        private string FtpRootFolder = "mawingu.se/public_html/radar/";
        private string FilesXmlFileName = "files.xml";



        public FtpController()
        {
            uploadqueue = new List<string>();
            filesonserver = new List<string>();

        }

        public string[] DownloadFileList()
        {
            try
            {
                List<string> result = new List<string>();

                string filesfilename = Path.GetTempPath();
                filesfilename = Path.Combine(filesfilename, FilesXmlFileName);
                if (File.Exists(filesfilename))
                {
                    File.Delete(filesfilename);

                } // Did exist

                FtpClient ftp = new FtpClient(
                    FtpHost,
                    FtpUser,
                    FtpPw
                    );

                ftp.DownloadFile(
                    FilesXmlFileName,
                    FtpRootFolder,
                    Path.GetDirectoryName(filesfilename)
                    );

                XDocument xdoc = XDocument.Load(filesfilename);
                XElement root = xdoc.Root;

                foreach (XElement xfile in root.Elements("file"))
                {
                    result.Add(xfile.Value);

                } // foreach

                filesonserver.Clear();
                filesonserver.AddRange(result);

                return result.ToArray();

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("DownloadFileList(): {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);

            }

        }

        public void AddToUploadQueue(string fileName)
        {
            uploadqueue.Add(fileName);
            string fn = Path.GetFileName(fileName);
            if (filesonserver.IndexOf(fn) == -1)
            {
                filesonserver.Add(fn);

            } // Not present

        }

        public void CreateFileList(string fileName, string[] files)
        {
            try
            {
                XDocument xdoc = new XDocument();

                XElement root = new XElement(
                    "files",
                    new XAttribute("lastmodified", DateTime.Now.ToUniversalTime().ToString("o"))
                    );
                xdoc.Add(root);

                foreach (string fn in files)
                {
                    XElement xfile = new XElement("file");
                    xfile.Value = Path.GetFileName(fn);
                    root.Add(xfile);
                    
                } // foreach file

                xdoc.Save(fileName);

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("CreateFileList({0}): {1}",
                    fileName,
                    ex.Message
                    );

            }

        }


        public void UploadFiles()
        {
            try
            {
                string filesfile = Path.GetTempPath();
                filesfile = Path.Combine(filesfile, FilesXmlFileName);
                CreateFileList(filesfile, filesonserver.ToArray());
                AddToUploadQueue(filesfile);
                
                string remotefolder = FtpRootFolder;

                FtpClient ftp = new FtpClient(
                    FtpHost,
                    FtpUser,
                    FtpPw
                    );

                foreach (string ulfile in uploadqueue)
                {
                    ftp.UploadFile(
                    ulfile,
                    remotefolder,
                    false
                    );

                } // foreach

                uploadqueue.Clear();

            }
            catch (Exception ex)
            {
                string errmsg = string.Format("UploadFiles(): {0}",
                    ex.Message
                    );
                throw new Exception(errmsg);
            }
        }




        public static FtpController Me
        {
            get
            {
                if (me == null)
                {
                    me = new FtpController();
                }
                return me;
            } // get

        } // Me


    }
}
