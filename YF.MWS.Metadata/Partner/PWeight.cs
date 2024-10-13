using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Partner
{
    public class PWeight
    {
        [JsonProperty("ePNo")]
        public string EPNo { get; set; }

        [JsonProperty("weightNo")]
        public string WeightNo { get; set; }

        [JsonProperty("clientName")]
        public string ClientName { get; set; }

        [JsonProperty("carNo")]
        public string CarNo { get; set; }

        [JsonProperty("tareWeight")]
        public decimal TareWeight { get; set; }

        [JsonProperty("grossWeight")]
        public decimal GrossWeight { get; set; }

        [JsonProperty("suttleWeight")]
        public decimal SuttleWeight { get; set; }

        [JsonProperty("netWeight")]
        public decimal NetWeight { get; set; }

        [JsonProperty("finishTime")]
        public string FinishTime { get; set; }

        [JsonProperty("measureUnit")]
        public string MeasureUnit { get; set; }

        [JsonProperty("orderSource")]
        public string OrderSource { get; set; }

        [JsonProperty("weighterName")]
        public string WeighterName { get; set; }

        [JsonProperty("materialName")]
        public string MaterialName { get; set; }

        [JsonProperty("measureType")]
        public string MeasureType { get; set; }

        [JsonProperty("tareWeightTime")]
        public string TareWeightTime { get; set; }

        [JsonProperty("grossWeightTime")]
        public string GrossWeightTime { get; set; }

        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; }

        [JsonProperty("deliveryName")]
        public string DeliveryName { get; set; }

        [JsonProperty("picUrl")]
        public string PicUrl { get; set; }

        [JsonProperty("remark")]
        public string Remark { get; set; }

    }
}
