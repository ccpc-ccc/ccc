using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.Win.View.Weight {
    public class GateUnit {
        private ModbusUtil modbusLeft;
        private SysCfg Cfg { get; set; }
        public GateUnit(ModbusUtil modbusLeft,SysCfg cfg) {
            this.Cfg = cfg;
            this.modbusLeft = modbusLeft;
    }
        public async void OpenServerGate(int no) {
            if (this.modbusLeft != null && Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                no = no * 2 - 1;
                await this.modbusLeft.SendData(no, 3);
            }
        }
        public async void CloseServerGate(int no) {
            if (this.modbusLeft != null && Cfg.Weight.ModBusCommMode == DeviceCommMode.Network) {
                no = no * 2;
                await this.modbusLeft.SendData(no, 3);
            }
        }
    }
}
