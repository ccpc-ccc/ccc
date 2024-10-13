using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public delegate void CheckBoxChangedEventHandler(object sender,CheckBoxChangedEventArgs e);

    public delegate void ManualCarRecognizeTriggerHandler(object sender,ManualCarRecognizeTriggerEventArgs e);

    public delegate void DeviceReconnectedEventHandler(object sender, DeviceReconnectedEventArgs e);
    
    public delegate void WeightFocusedRowChangedEventHandler(object sender,WeightFocusedRowChangedEventArgs e);

    public delegate void WeightDoubleClickEventHandler(object sender, WeightDoubleClickEventArgs e);

    public delegate void WeightItemClickEventHandler(object sender, WeightItemClickEventArgs e);

    public delegate void WeightVauleChangedEventHandler(object sender, WeightVauleChangedEventArgs e);

    /// <summary>
    /// 视图选项点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ViewItemClickEventHandler(object sender, ViewItemClickEventArgs e);

    /// <summary>
    /// 翻页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PageChangedEventHandler(object sender, PageChangedEventArgs e);

}
