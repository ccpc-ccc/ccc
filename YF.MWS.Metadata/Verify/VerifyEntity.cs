using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace YF.MWS.Metadata {
    public class VerifyEntity {
        public BaseEdit Edit { get; set; }
        public string Message { get; set; }
        public VerifyEntity(BaseEdit edit, string message) {
            this.Edit = edit;
            this.Message = message;
        }
    }
    public class VerifyOperater {
        public static bool isEmptyString(BaseEdit contlor, string message) {
            if (contlor.EditValue == null || contlor.EditValue.ToString() == "") {
                MessageDxUtil.ShowError(message);
                return false;
            } else {
                return true;
            }
        }
        public static bool isEmptyString(List<VerifyEntity> list) {
            foreach (VerifyEntity item in list) {
                if (!isEmptyString(item.Edit, item.Message)) {
                    return false;
                }
            }
            return true;
        }
    }
    public class UtilityQuery {
        public static bool Verify<T>(string[] properties, T t) {
            Type type = typeof(T);
            foreach (string propertyInfo in properties) {
                PropertyInfo info = type.GetProperty(propertyInfo);
                if (info != null) {
                    object obj = info.GetValue(t, null);
                    if (obj == null) {
                        errMsg = string.Format("{0}不存在", info.Name);
                        return false;
                    }
                }
            }
            errMsg = "";
            return true;
        }
        public static string errMsg { get; set; }
    }

}
