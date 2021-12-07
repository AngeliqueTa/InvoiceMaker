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
    [System.Web.Http.RoutePrefix("api/invoice")]
    public class InvoiceController : BaseController
    {
        // GET: Invoice
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getInvoice/customerID")]
        public IHttpActionResult getCompany(int customerID)
        {
            try
            {
                using (SettingsContext)
                {
                    var result = (from sg in SettingsContext.Invoice
                                  where sg.CustomerID == customerID
                                  select new
                                  {
                                      sg.CustomerID,
                                      sg.InvoiceID,
                                      sg.DueDate,
                                      sg.DateOfInvoice,
                                      sg.TotalAmount
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
        [System.Web.Http.Route("updateInvoice")]
        public IHttpActionResult UpdateInvoice(InvoiceModel invoice)
        {
            try
            {
                if (ModelState.IsValid) Console.WriteLine("Valid");
                var validSqlDate = new DateTime(1900, 01, 01, 00, 00, 00);

                using (SettingsContext)
                {
                    var originalInvoice = SettingsContext.Invoice.SingleOrDefault(s => s.InvoiceID == invoice.InvoiceID);

                    if (originalInvoice == null)
                    {
                        var companyExist = SettingsContext.Invoice.Any(s => s.InvoiceID == invoice.InvoiceID);
                        if (companyExist) return Content(HttpStatusCode.BadRequest, "Invoice with this Id already exists.");


                        SettingsContext.Invoice.Add(invoice);

                        SettingsContext.SaveChanges();

                        return Ok();
                    }

                    originalInvoice.CustomerID = invoice.CustomerID;
                    originalInvoice.DueDate = invoice.DueDate;
                    originalInvoice.DateOfInvoice = invoice.DateOfInvoice;
                    originalInvoice.TotalAmount = invoice.TotalAmount;

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