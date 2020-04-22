using aspnet_mvc_razor_app.Models;
using PassportPDF.Api;
using PassportPDF.Model;
using System;
using System.Collections.Generic;

namespace aspnet_mvc_razor_app
{
    internal static class BarcodeRecognitionDemo
    {
        public static List<BarcodeResult> BarcodeRecognition(BarcodeRecognitionActionParameters parameters)
        {
            List<BarcodeResult> results = new List<BarcodeResult>();
            DocuViewareApi dvApi = PassportPDFUtils.GetDocuViewareInstance();
            DocuViewareSaveResponse docuViewareSaveResponse = dvApi.DocuViewareSave(new DocuViewareSaveParameters(parameters.SessionID, parameters.ControlId, "page.tif", "tiff") { PageRange = parameters.CurrentPage.ToString() });
            if (docuViewareSaveResponse.Error == null)
            {
                byte[] imageData = docuViewareSaveResponse.Content;
                ImageApi imageAPI = PassportPDFUtils.GetImageInstance();
                ImageLoadResponse loadImageResponse = imageAPI.ImageLoad(new LoadImageFromByteArrayParameters(imageData) { FileName = "file.tif" });
                if (loadImageResponse.Error == null)
                {
                    ReadBarcodesResponse imageReadBarcodeResponse = imageAPI.ImageReadBarcodes(new ImageReadBarcodesParameters(fileId: loadImageResponse.FileId,
                        pageRange: "1")
                    {
                        ScanBarcode1D = parameters.ReadLinear,
                        ScanBarcodeQR = parameters.ReadQrcode,
                        ScanBarcodeMicroQR = parameters.ReadMicroQrcode,
                        ScanBarcodePDF417 = parameters.ReadPdf417,
                        ScanBarcodeDataMatrix = parameters.ReadDatamatrix,
                        ScanBarcodeAztec = parameters.ReadAztec
                    }
                    );
                    if (imageReadBarcodeResponse.Error == null)
                    {
                        foreach (BarcodeInfo barcode in imageReadBarcodeResponse.Barcodes)
                        {
                            string symbology;
                            if (barcode.Type == BarcodeType.Linear)
                            {
                                symbology = Enum.GetName(typeof(Barcode1DSymbology), barcode.Barcode1DSymbology);
                            }
                            else
                            {
                                symbology = Enum.GetName(typeof(BarcodeType), barcode.Type);
                            }

                            results.Add(new BarcodeResult(symbology, barcode.Data, new BarcodeBBoxInches(barcode.BboxLeftInches, barcode.BboxTopInches, barcode.BboxWidthInches, barcode.BboxHeightInches)));
                        }
                    }
                    else
                    {
                        results.Add(new BarcodeResult(error: imageReadBarcodeResponse.Error));
                    }
                }
                else
                {
                    results.Add(new BarcodeResult(error: loadImageResponse.Error));
                }
            }
            else
            {
                results.Add(new BarcodeResult(error: docuViewareSaveResponse.Error));
            }

            return results;
        }
    }
}