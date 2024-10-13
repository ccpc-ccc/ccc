using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Dto
{
    public class BatchUpdate
    {
        public RowState RowState { get; set; }
        public SyncState State { get; set; }
        public List<string> Ids { get; set; }
        public BatchUpdate()
        {
            Ids = new List<string>();
            State = SyncState.Synced;
            RowState = RowState.Edit;
        }
    }
}
