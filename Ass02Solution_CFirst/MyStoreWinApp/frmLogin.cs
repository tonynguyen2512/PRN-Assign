﻿using DataAccess.Repository;
using Nancy.Json;
using System;
using System.IO;
using System.Windows.Forms;
using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        private MemberRepository memberRepository = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string json = string.Empty;

            // read json string from file
            using (StreamReader reader = new StreamReader("appsettings.json"))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();

            // convert json string to dynamic type
            var obj = jss.Deserialize<dynamic>(json);

            // get contents

            var admin = new MemberObject
            {
                Email = obj["DefaultAccount"]["Email"],
                Password = obj["DefaultAccount"]["password"]
            };



            // add employees to richtextbox



            var members = memberRepository.GetMembers();
            foreach (var i in members)
            {
                if (i.CompanyName.Equals(txtUserName.Text) && i.Password.Equals(txtPassword.Text))
                {
                    frmMemberManagements frm = new frmMemberManagements()
                    {
                        isAdmin = false
                    };
                    frm.ShowDialog();

                    this.Close();
                    break;

                }
                else if (admin.Email.Equals(txtUserName.Text) && admin.Password.Equals(txtPassword.Text))
                {
                    frmMemberManagements frm = new frmMemberManagements()
                    {
                        isAdmin = true
                    };
                    frm.ShowDialog();

                    this.Close();
                    break;

                }
                else
                {
                    MessageBox.Show("Wrong user name or pass word, please try again", "Wrong user");
                    break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    }
}
