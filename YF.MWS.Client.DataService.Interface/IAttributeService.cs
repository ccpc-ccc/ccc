using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IAttributeService
    {
        SAttribute GetAttribute(string attributeId);
        List<SAttribute> GetAttributeList(string subjectId);
        SAttributeSubject GetSubject(string subjectId);
        List<SAttributeSubject> GetSubjectList();
        bool DeleteAttribute(string attributeId);
        bool DeleteSubject(string subjectId);
        bool SaveAttribute(SAttribute attribute);
        bool SaveSubject(SAttributeSubject subject);
    }
}
