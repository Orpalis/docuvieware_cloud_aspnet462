using System;

namespace aspnet_mvc_razor_app.Models
{
    [Serializable]
    public class BarcodeRecognitionActionParameters
    {
        public string ControlId { get; set; }
        public string SessionID { get; set; }
        public int CurrentPage { get; set; }
        public bool ReadLinear { get; set; }
        public bool ReadQrcode { get; set; }
        public bool ReadMicroQrcode { get; set; }
        public bool ReadDatamatrix { get; set; }
        public bool ReadPdf417 { get; set; }
        public bool ReadAztec { get; set; }
    }
}