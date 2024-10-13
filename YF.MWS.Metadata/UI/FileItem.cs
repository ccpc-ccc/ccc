using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.UI
{
    public class FileItem
    {
        private string fullPath;

        public string FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private DateTime updateTime;

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        public string OpenReport
        {
            get
            {
                return "打开";
            }
        }
    }
}
