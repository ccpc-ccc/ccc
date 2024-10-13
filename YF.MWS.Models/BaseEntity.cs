using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    [Serializable]
    public class BaseEntity
    {
        private string? createrId;
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get;set; }

        public string? CreaterId { get; set; }
        /*private DateTime? createTime;

        public DateTime? CreateTime
        {
            get {
                if(createTime==DateTime.MinValue)
                    createTime = DateTime.Now;
                return createTime;
            }
            set { createTime = value; }
        }*/
        public DateTime? CreateTime { get; set; }
        private  DateTime? updateTime;

        public DateTime? UpdateTime
        {
            get { 
                    updateTime = DateTime.Now;
                return updateTime; 
            }
            set { updateTime = value; }
        }

        public string? UpdaterId { get; set; }

        public int? RowState { get; set; }
    }
}
