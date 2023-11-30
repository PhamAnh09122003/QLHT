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
    public partial class Login : Form
    {
        Function fn = new Function();
        string query;
        DataSet ds;
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {

            //Now Adding Query To connect Login Page With DataBase
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    Administrator admin = new Administrator();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username='" + txtUsername.Text + "'and pass='" + txtPassword.Text + "'";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    string role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator")
                    {
                        Administrator admin = new Administrator(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "Pharmacist")
                    {
                        Pharmacist pharm = new Pharmacist();
                        pharm.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(w, h);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
