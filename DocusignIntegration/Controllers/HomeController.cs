using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocuSign.eSign.Api;
using DocuSign.eSign.Model;
using DocuSign.eSign.Client;
using Newtonsoft.Json;
using DocusignIntegration.Properties;
using System.IO;

namespace DocusignIntegration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult CreateEnvelope()
        {                        
            // Enter your credentials
            string username = "[Your Docusign Demo Account email]";
            string password = "[Your Docusign Demo Account password]";
            string integratorKey = "[Your Docusign Demo Account generated integrator key]"; //can be generated in the Admin
            string accountId = "[Your Docusign Demo Account account ID"; // can be found in the Admin
            string basePath = "https://demo.docusign.net/restapi";            
            string returnUrl = "[Will be redirected to this url after signing]";

            string signerName = "[Signer Name]";
            string signerEmail = "[Signer Email]";
            string emailSubject = "Please, sign this sample document"; 

            // instantiate a new api client and set desired environment
            ApiClient apiClient = new ApiClient(basePath);

            // set client in global config so we don't have to pass it to each API object.
            Configuration.Default.ApiClient = apiClient;

            // create JSON formatted auth header containing Username, Password, and Integrator Key
            string authHeader = "{\"Username\":\"" + username + "\", \"Password\":\"" + password + "\", \"IntegratorKey\":\"" + integratorKey + "\"}";
            Configuration.Default.DefaultHeader.Clear();
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", authHeader);

            // the authentication api uses the apiClient (and X-DocuSign-Authentication header) that are set in Configuration object
            AuthenticationApi authApi = new AuthenticationApi();
            LoginInformation loginInfo = authApi.Login();
            
            byte[] fileBytes = Resources.SampleDoc;

            EnvelopeDefinition envDef = new EnvelopeDefinition() { EmailSubject = emailSubject};            

            // Add a document to the envelope
            Document doc = new Document() { Name = "SampleDoc", DocumentId = "1", DocumentBase64 = System.Convert.ToBase64String(fileBytes)};
            envDef.Documents = new List<Document>();
            envDef.Documents.Add(doc);

            Signer signer = new Signer() { Name = signerName, Email = signerEmail, RecipientId = "1", ClientUserId = "1234"};

            // Create a |SignHere| tab somewhere on the document for the recipient to sign
            signer.Tabs = new Tabs();
            signer.Tabs.SignHereTabs = new List<SignHere>();
            SignHere signHere = new SignHere() { DocumentId = "1", PageNumber = "1", RecipientId = "1", XPosition = "100", YPosition = "150"};
            signer.Tabs.SignHereTabs.Add(signHere);

            envDef.Recipients = new Recipients();
            envDef.Recipients.Signers = new List<Signer>();
            envDef.Recipients.Signers.Add(signer);

            // set envelope status to "sent" to immediately send the signature request
            envDef.Status = "sent";

            // Use the EnvelopesApi to send the signature request!
            EnvelopesApi envelopesApi = new EnvelopesApi();
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountId, envDef);

            RecipientViewRequest viewOptions = new RecipientViewRequest(){ ReturnUrl = returnUrl, ClientUserId = "1234",AuthenticationMethod = "email",
                                               UserName = signerName, Email = signerEmail};

            // create the recipient view (aka signing URL)
            ViewUrl recipientView = envelopesApi.CreateRecipientView(accountId, envelopeSummary.EnvelopeId, viewOptions);

            // Start the embedded signing session
            return Redirect(recipientView.Url);

        }
        
    }
}