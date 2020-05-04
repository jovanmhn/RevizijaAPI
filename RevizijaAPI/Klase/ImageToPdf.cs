using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using RevizijaAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RevizijaAPI.Klase
{
    
    public static class ImageToPdf
    {

        public static bool ConvertImageToPdf(Image image, string naziv, RevizijaAPI.Models.Database.dms_file folderOstalo)
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

                    var result = Upload2DMS(folderOstalo, naziv, image);
                    if (result.result)
                    {
                        using (FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath($"~\\Uploads\\{result.guid}"), FileMode.OpenOrCreate))
                        {
                            server.ExportToPdf(fs);
                        }
                        return true;
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private static UploadReturn Upload2DMS(dms_file folderOstalo, string naziv, Image image)
        {
            dms_file fajl;
            try
            {
                RevizijaAPI.Models.Database.Database DB = new Models.Database.Database();

                var klijent = DB.klijent.First(qq => qq.id_klijent == folderOstalo.id_klijent);

                fajl = new dms_file  //napravi objekat
                {
                    id_klijent = klijent.id_klijent,
                    id_tip = 1, //1 fajl, 2 folder..
                    naziv = naziv,
                    extension = ".pdf",
                    guid = Guid.NewGuid().ToString(),
                    guid_parent = folderOstalo.guid,
                    created = DateTime.Now,
                    //id_operater = Pomocnik.logovani_operater.id_operater,
                    id_knjiga = folderOstalo.id_knjiga,
                    id_revizija_scheme = folderOstalo.id_revizija_scheme,
                };

                DB.dms_file.Add(fajl);
                DB.SaveChanges();
                return new UploadReturn { guid = fajl.guid, result = true };
            }
            catch (Exception)
            {
                return new UploadReturn { result = false };
            }

            
        }
        private class UploadReturn
        {
            public string guid { get; set; }
            public bool result { get; set; }
        }


    }
}