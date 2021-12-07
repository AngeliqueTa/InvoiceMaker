using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [System.Web.Http.RoutePrefix("api/invoiceitems")]
    public class ItemsController : BaseController
    {
        // GET: Company
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getItems/invoiceID")]
        public IHttpActionResult getCompany(int invoiceID)
        {
            try
            {
                using (SettingsContext)
                {
                    //get invoiceID from lookup table?
                    var result = (from sg in SettingsContext.InvoiceItem
                                  where sg.ItemID == invoiceID
                                  select new
                                  {
                                      sg.ItemID,
                                      sg.ItemDescription,
                                      sg.Price,
                                      sg.Taxable
                                  }).ToList();

                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("updateInvoiceItems")]
        public IHttpActionResult UpdateCompany(InvoiceitemsModel invoiceItems)
        {
            try
            {
                if (ModelState.IsValid) Console.WriteLine("Valid");
                var validSqlDate = new DateTime(1900, 01, 01, 00, 00, 00);

                using (SettingsContext)
                {
                    var originalInvoiceitems = SettingsContext.InvoiceItem.SingleOrDefault(s => s.ItemID == invoiceItems.ItemID);

                    if (originalInvoiceitems == null)
                    {
                        var invoiceItemsExist = SettingsContext.InvoiceItem.Any(s => s.ItemID == invoiceItems.ItemID);
                        if (invoiceItemsExist) return Content(HttpStatusCode.BadRequest, "Invoice Item with this Id already exists.");


                        SettingsContext.InvoiceItem.Add(invoiceItems);

                        SettingsContext.SaveChanges();

                        return Ok();
                    }

                    originalInvoiceitems.ItemDescription = invoiceItems.ItemDescription;
                    originalInvoiceitems.Price = invoiceItems.Price;
                    originalInvoiceitems.Taxable = invoiceItems.Taxable;

                    SettingsContext.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                return InternalServerError();
            }
        }
    }
}