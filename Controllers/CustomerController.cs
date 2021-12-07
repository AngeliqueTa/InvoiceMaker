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
    [System.Web.Http.RoutePrefix("api/customer")]
    public class CustomerController : BaseController
    {
        // GET: Customer
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getCustomer/companyID")]
        public IHttpActionResult getCustomer(int companyID)
        {
            try
            {
                using (SettingsContext)
                {
                    var result = (from sg in SettingsContext.Customer
                                  where sg.CompanyID == companyID
                                  select new
                                  {
                                      sg.CompanyID,
                                      sg.CustomerID,
                                      sg.FirstName,
                                      sg.LastName,
                                      sg.City,
                                      sg.Street,
                                      sg.Zip,
                                      sg.PhoneNumber
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
        [System.Web.Http.Route("updateCustomer")]
        public IHttpActionResult UpdateCustomer(CustomerModel customer)
        {
            try
            {
                if (ModelState.IsValid) Console.WriteLine("Valid");
                var validSqlDate = new DateTime(1900, 01, 01, 00, 00, 00);

                using (SettingsContext)
                {
                    var originalcustomer = SettingsContext.Customer.SingleOrDefault(s => s.CustomerID == customer.CustomerID);

                    if (originalcustomer == null)
                    {
                        var customerExist = SettingsContext.Customer.Any(s => s.CompanyID == customer.CompanyID);
                        if (customerExist) return Content(HttpStatusCode.BadRequest, "Customer with this Id already exists.");


                        SettingsContext.Customer.Add(customer);

                        SettingsContext.SaveChanges();

                        return Ok();
                    }

                    originalcustomer.FirstName = customer.FirstName;
                    originalcustomer.LastName = customer.LastName;
                    originalcustomer.Street = customer.Street;
                    originalcustomer.City = customer.City;
                    originalcustomer.PhoneNumber = customer.PhoneNumber;
                    originalcustomer.Zip = customer.Zip;

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