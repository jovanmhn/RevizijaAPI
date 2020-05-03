using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace RevizijaAPI.Klase
{
    public static class ImageToPdf
    {
        public static bool ConvertImageToPdf(Image image, string naziv)
        {
            using (RichEditDocumentServer server = new RichEditDocumentServer())
            {
                try
                {
                    //Insert an image
                    DocumentImage docImage = server.Document.Images.Append(DocumentImageSource.FromImage(image));

                    //Adjust the page width and height to the image's size
                    server.Document.Sections[0].Page.Width = docImage.Size.Width + server.Document.Sections[0].Margins.Right + server.Document.Sections[0].Margins.Left;
                    server.Document.Sections[0].Page.Height = docImage.Size.Height + server.Document.Sections[0].Margins.Top + server.Document.Sections[0].Margins.Bottom;

                    //Export the result to PDF
                    using (FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath($"~\\Uploads\\{naziv}.pdf"), FileMode.OpenOrCreate))
                    {
                        server.ExportToPdf(fs);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}