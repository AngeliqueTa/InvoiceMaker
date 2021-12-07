using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [System.Web.Http.RoutePrefix("api/company")]
    public class CompanyController : BaseController
    {
        // GET: Company
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getCompany/companyID")]
        public IHttpActionResult getCompany(int companyID)
        {
            try
            {
                using (SettingsContext)
                {
                    var result = (from sg in SettingsContext.Company
                                  where sg.CompanyID == companyID
                                  select new { 
                                  sg.CompanyID,
                                  sg.CompanyName,
                                  sg.City,
                                  sg.Street,
                                  sg.Zip,
                                  sg.PhoneNumber,
                                  sg.Fax,
                                  sg.Website
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
        [System.Web.Http.Route("updateCompany")]
        public IHttpActionResult UpdateCompany(CompanyModel company)
        {
            try
            {
                if (ModelState.IsValid) Console.WriteLine("Valid");
                var validSqlDate = new DateTime(1900, 01, 01, 00, 00, 00);

                using (SettingsContext)
                {
                    var originalCompany = SettingsContext.Company.SingleOrDefault(s => s.CompanyID == company.CompanyID);

                    if (originalCompany == null)
                    {
                        var companyExist = SettingsContext.Company.Any(s => s.CompanyID == company.CompanyID);
                        if (companyExist) return Content(HttpStatusCode.BadRequest, "Company with this Id already exists.");

                       
                        SettingsContext.Company.Add(company);

                        SettingsContext.SaveChanges();

                        return Ok();
                    }

                    originalCompany.CompanyName = company.CompanyName;
                    originalCompany.Street = company.Street;
                    originalCompany.City = company.City;
                    originalCompany.Fax = company.Fax;
                    originalCompany.PhoneNumber = company.PhoneNumber;
                    originalCompany.Website = company.Website;
                    originalCompany.Zip = company.Zip;

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