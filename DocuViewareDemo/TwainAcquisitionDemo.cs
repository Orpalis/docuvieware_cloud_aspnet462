using aspnet_mvc_razor_app.Models;
using PassportPDF.Api;
using PassportPDF.Model;

namespace aspnet_mvc_razor_app
{
    public class TwainAcquisitionDemo
    {
        public static byte[] TwainGeneratePdfA(TwainGeneratePdfAParameters parameters)
        {
            DocuViewareApi dvApi = PassportPDFUtils.GetDocuViewareInstance();
            DocuViewareSaveParameters saveParameters = new DocuViewareSaveParameters(parameters.SessionId, parameters.ControlId, "document.pdf", "pdf/a") { PageRange = "*" };
            DocuViewareSaveResponse saveResponse = dvApi.DocuViewareSave(saveParameters);
            return saveResponse.Error == null ? saveResponse.Content : null;
        }
    }
}