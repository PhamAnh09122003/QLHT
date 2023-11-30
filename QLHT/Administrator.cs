using QLHT.AdministratorUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHT
{
    public partial class Administrator : Form
    {
        string user = "";
        public Administrator()
        {
            InitializeComponent();
        }
        public string ID
        {
            get { return user.ToString(); }
        }
        private void Administrator_Load(object sender, EventArgs e)
        {

        }

        public Administrator(string username)
        {
            InitializeComponent();
            userNameLabel.Text = username;
            //Username is setting in user so current user willn't be able to remove there own self;
            user = username;
            //this GET will fetch the values and give that to ViewUser (ID) and SET those Values;
           
            //it will link username label to 
           
        }
    }
}
