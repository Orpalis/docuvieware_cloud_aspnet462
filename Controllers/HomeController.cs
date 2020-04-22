using aspnet_mvc_razor_app.DocuViewareDemo;
using aspnet_mvc_razor_app.Models;
using aspnet_mvc_razor_app.Models.HomeViewModels;
using PassportPDF.Api;
using PassportPDF.Model;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc_razor_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DocuViewareApi dvApi = PassportPDFUtils.GetDocuViewareInstance();
            StringResponse version = dvApi.DocuViewareGetVersion();
            IndexViewModel model = new IndexViewModel { Version = version.Value };
            return View(model);
        }


        public ActionResult Annotations()
        {
            AnnotationsViewModel model = new AnnotationsViewModel { DocuViewareID = "DocuVieware4" };
            return View(model);
        }


        public ActionResult BarcodeRecognition()
        {
            BarcodeRecognitionViewModel model = new BarcodeRecognitionViewModel { DocuViewareID = "DocuVieware1" };
            model.SnapInHtmlContent = this.RenderRazorViewToString("_BarcodeRecognitionSnapIn", model);
            return View(model);
        }

        [HttpPost]
        public JsonResult ReadBarcodes(BarcodeRecognitionActionParameters parameters)
        {
            return Json(BarcodeRecognitionDemo.BarcodeRecognition(parameters));
        }


        public ActionResult BlogIntegration()
        {
            DocuViewareApi dvApi = PassportPDFUtils.GetDocuViewareInstance();
            StringResponse version = dvApi.DocuViewareGetVersion();
            BlogIntegrationViewModel model = new BlogIntegrationViewModel
            {
                DocuViewareID = "DocuVieware3",
                Version = version.Value
            };
            return View(model);
        }


        public ActionResult CustomToolbar()
        {
            DocuViewareApi dvApi = PassportPDFUtils.GetDocuViewareInstance();
            StringResponse version = dvApi.DocuViewareGetVersion();
            CustomToolbarViewModel model = new CustomToolbarViewModel
            {
                DocuViewareID = "DocuVieware9",
                Version = version.Value
            };
            return View(model);
        }


        public ActionResult FormFields()
        {
            FormFieldsViewModel model = new FormFieldsViewModel { DocuViewareID = "DocuVieware1" };
            return View(model);
        }


        public ActionResult FormFieldsGeneratePdf(FormFieldsGeneratePdfParameters parameters)
        {
            byte[] content = FormFieldsDemo.FormFieldsGeneratePdf(parameters);
            ContentDisposition contentDisposition = new ContentDisposition
            {
                FileName = "invoice.pdf",
                Inline = false
            };
            Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
            return content != null ? File(content, MimeMapping.GetMimeMapping(contentDisposition.FileName)) : null;
        }


        public ActionResult Gallery()
        {
            GalleryViewModel model = new GalleryViewModel { DocuViewareID = "DocuVieware6" };
            return View(model);
        }


        public ActionResult ImageCleanup()
        {
            ImageCleanupViewModel model = new ImageCleanupViewModel { DocuViewareID = "DocuVieware7" };
            model.SnapInHtmlContent = this.RenderRazorViewToString("_ImageCleanupSnapIn", model);
            return View(model);
        }


        public ActionResult StandaloneViewer()
        {
            StandaloneViewerViewModel model = new StandaloneViewerViewModel { DocuViewareID = "DocuVieware1" };
            return View(model);
        }


        public ActionResult Twain()
        {
            TwainViewModel model = new TwainViewModel { DocuViewareID = "DocuVieware5" };
            return View(model);
        }

        public ActionResult TwainGeneratePdfA(TwainGeneratePdfAParameters parameters)
        {
            byte[] content = TwainAcquisitionDemo.TwainGeneratePdfA(parameters);
            ContentDisposition contentDisposition = new ContentDisposition
            {
                FileName = "document.pdf",
                Inline = false
            };
            Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
            return content != null ? File(content, MimeMapping.GetMimeMapping(contentDisposition.FileName)) : null;
        }
    }
}