using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RevizijaAPI.Pages
{
    public partial class TestHome : System.Web.UI.Page
    {
        Models.Database.Database Model { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model = new Models.Database.Database();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(Model.operater.Any(qq=> qq.username == textBoxUsername.Text && qq.password == textBoxPassword.Text))
            {
                labelResult.Text = "Uspjesan login";
            }
            else
            {
                labelResult.Text = "Neuspjesan login";
            }
        }
    }
}