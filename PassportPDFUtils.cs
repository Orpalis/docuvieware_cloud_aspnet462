using PassportPDF.Api;


namespace aspnet_mvc_razor_app
{
    public static class PassportPDFUtils
    {
        public static DocuViewareApi GetDocuViewareInstance()
        {
            DocuViewareApi instance = new DocuViewareApi();
            return instance;
        }


        public static PDFApi GetPDFInstance()
        {
            PDFApi instance = new PDFApi();
            return instance;
        }


        public static DocumentApi GetDocumentInstance()
        {
            DocumentApi instance = new DocumentApi();
            return instance;
        }


        public static ImageApi GetImageInstance()
        {
            ImageApi instance = new ImageApi();
            return instance;
        }
    }
}