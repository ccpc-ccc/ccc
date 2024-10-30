using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Db
{
    [Serializable]
    public class BaseEntity
    {
        public virtual string Id { get; set; }
        private string createrId;

        public virtual string CreaterId
        {
            get {
                return createrId;
            }
            set { createrId = value; }
        }
        private DateTime createTime;

        public virtual DateTime CreateTime
        {
            get {
                if(createTime==DateTime.MinValue)
                    createTime = DateTime.Now;
                return createTime;
            }
            set { createTime = value; }
        }
        private  DateTime updateTime;

        public virtual DateTime UpdateTime
        {
            get { 
                    updateTime = DateTime.Now;
                return updateTime; 
            }
            set { updateTime = value; }
        }

        private string updaterId;

        public virtual string UpdaterId
        {
            get {
                return updaterId; }
            set { updaterId = value; }
        }

        public virtual int RowState { get; set; }
    }
}
