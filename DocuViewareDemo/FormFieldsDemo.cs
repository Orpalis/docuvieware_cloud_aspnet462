using aspnet_mvc_razor_app.Models;
using PassportPDF.Api;
using PassportPDF.Model;

namespace aspnet_mvc_razor_app.DocuViewareDemo
{
    public class FormFieldsDemo
    {
        public static byte[] FormFieldsGeneratePdf(FormFieldsGeneratePdfParameters parameters)
        {
            DocuViewareApi dvApi = PassportPDFUtils.GetDocuViewareInstance();
            DocuViewareSaveResponse saveResponse = dvApi.DocuViewareSave(new DocuViewareSaveParameters(parameters.SessionId, parameters.ControlId, "invoice.pdf", "pdf") { PageRange = "*" });
            if (saveResponse.Error == null)
            {
                PDFApi pdfApi = PassportPDFUtils.GetPDFInstance();
                PdfLoadDocumentResponse loadResponse = pdfApi.LoadDocumentAsPDF(new PdfLoadDocumentFromByteArrayParameters(saveResponse.Content) { FileName = "invoice.pdf" });
                if (loadResponse.Error == null)
                {
                    PdfFlattenResponse flattenResponse = pdfApi.Flatten(new PdfFlattenParameters(loadResponse.FileId) { FlattenAnnotations = true, FlattenFormFields = true });
                    if (flattenResponse.Error == null)
                    {
                        PdfSaveDocumentResponse finalSaveResponse = pdfApi.SaveDocument(new PdfSaveDocumentParameters(loadResponse.FileId));
                        return finalSaveResponse.Error == null ? finalSaveResponse.Data : null;
                    }
                }
            }
            return null;
        }
    }
}