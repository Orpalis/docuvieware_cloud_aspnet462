using PassportPDF.Model;
using System;

namespace aspnet_mvc_razor_app.Models
{
    [Serializable]
    public class BarcodeResult
    {
        public Error Error { get; }
        public string Data { get; }
        public string Symbology { get; }
        public BarcodeBBoxInches Box { get; }

        public BarcodeResult(string symbology = null, string data = null, BarcodeBBoxInches box = null, Error error = null)
        {
            Symbology = symbology;
            Data = data;
            Box = box;
            Error = error;
        }
    }
}