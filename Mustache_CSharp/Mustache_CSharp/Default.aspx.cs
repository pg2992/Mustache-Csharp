using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mustache;

namespace Mustache_CSharp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Example1_labelUpdated();
            Example2_labelUpdated();
            Example3_labelUpdated();
            Example4_labelUpdated();
        }

        private void Example4_labelUpdated()
        {
            FormatCompiler compiler = new FormatCompiler();
            Generator generator = compiler.Compile(GetLocalTemplate("SetTagTestingTemplate"));
            generator.ValueRequested += (sender, e) =>
            {
                e.Value = !(bool)(e.Value ?? false);
            };
            string result = generator.Render(new int[] { 0, 1 });
            lblSetTag.Text = result;
        }

        private void Example3_labelUpdated()
        {
            BigCustomer bigCustomer = new BigCustomer();
            bigCustomer.Customer = new Customer()
            {
                FirstName = "pawan",
                LastName = "gangad",
                Address = new Address() { City = "Pune", State = "Maharashtra", ZipCode = 411015, Line1 = "A1/6", Line2 = "Vishrant Housing Soc." },
                Order = new Order() { LineItems = new List<Item>() { new Item() { ProductName = "Apple", Quantity = 6, UnitPrice = 20 }, new Item() { ProductName = "Banana", Quantity = 5, UnitPrice = 120 } } }
            };
            FormatCompiler compiler = new FormatCompiler();
            Generator generator = compiler.Compile(GetLocalTemplate("CustomerOrderTemplate"));
            string result = generator.Render(bigCustomer);
            lblCustomerOrder.Text= result;
        }

        private void Example2_labelUpdated()
        {
            BigCustomer bigCustomer = new BigCustomer();
            bigCustomer.Customer = new Customer()
            {
                FirstName = "pawan",
                LastName = "gangad",
                Address = new Address(){City = "Pune",State = "Maharashtra",ZipCode = 411015,Line1 = "A1/6",Line2 = "Vishrant Housing Soc."}
            };
            FormatCompiler compiler = new FormatCompiler();
            Generator generator = compiler.Compile(GetLocalTemplate("TestTemplate"));
            string result = generator.Render(bigCustomer);
            lblContactInfo.Text = result;
        }
        private void Example1_labelUpdated()
        {
            FormatCompiler compiler = new FormatCompiler();
            Generator generator = compiler.Compile("Hello, {{this}}!!!");
            string result = generator.Render("Bob");
            lblHello.Text = result;
        }
        private string GetLocalTemplate(string templateName)
        {

            var filePath = string.Format("~/Template/{0}.html", templateName.Replace('.', '_'));
            filePath = HttpContext.Current.Server.MapPath(filePath);
            string template = null;
            try
            {
                template = File.ReadAllText(filePath);
            }
            catch
            {
                //Igonore
            }
            return template;
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            lblContactInfo.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //
        }

        
    }
}
