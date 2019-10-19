using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using _018ventilation.se.Classes;
using _018ventilation.se.Models;

namespace _018ventilation.se.Controllers
{
    public class ContactController : Umbraco.Web.Mvc.SurfaceController
    {
        [ChildActionOnly]
        public ActionResult ContactForm()
        {

            //var currentNode = Umbraco.TypedContent(UmbracoContext.PageId.GetValueOrDefault());
            ////In case you need to access the home node
            //var home = currentNode.AncestorsOrSelf(0).First();
            return PartialView("_contact");
        }



        [HttpPost]
        public ActionResult SendMessage(ContactModel model)
        {

            if (!ModelState.IsValid)
            {

                return Content("error");
            }
            var sender = NollartonHelpers.GetAppSetting<string>("cfsender");
            try
            {
                var msgBody = model.Comment.Replace(Environment.NewLine, "<br>");
                var cfwebresponse = NollartonHelpers.GetAppSetting<string>("cfwebresponse");
                EmailGateway.SendMail(model.Email, sender, "From web form",msgBody, true);
                TempData.Add("CustomMessage", cfwebresponse);
            }
            catch (Exception ex)
            {
#if DEBUG
                TempData["ERROR"] = ex.ToString();

#else
				TempData["ERROR"] = "Något gick fel, vi har skickat ett mail med information om vad som skett. försök igen senare/Something went wrong, the error is emailed to us. Please try later ";
				EmailGateway.SendMail(model.Email, sender, "error",ex.ToString(), true);

#endif
                return Content(TempData["ERROR"].ToString());
            }
            return Content(TempData["CustomMessage"].ToString());
        }
    }
}