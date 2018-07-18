using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebConfig
{
    public partial class MyMessagebox : Form
    {
        public MyMessagebox()
        {
            InitializeComponent();
        }

        static MyMessagebox newMessageBox;
        static string Button_id;


        public static void  ShowBox(string txtMessage)
        {
            newMessageBox = new MyMessagebox();
            newMessageBox.label1.Text = txtMessage;
            newMessageBox.ShowDialog();
            
            //return Button_id;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdasd");
            
            //    Button_id = "1";
            //    newMessageBox.Dispose();
            //

            //      MyMessagebox.ShowBox("Do you want to exit?");
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
