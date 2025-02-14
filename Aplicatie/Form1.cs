using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;
using System.Linq;
using System.ComponentModel;


namespace LoginForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );


        /// <summary>
        ///  Aici se face conexiunea la baza de date
        /// </summary>
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True");


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height);
            panel1.Anchor = AnchorStyles.None;
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 30, 30));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                ///
                /// Aici am facut un query pentru a extrage datele pe care le doresc din tabela Utilizator
                /// 
                String querry = "SELECT * FROM Utilizator WHERE username = '" + txt_username.Text + "' AND password = '" + txt_password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    Form2 form2 = new Form2();

                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_password.Clear();
                    txt_username.Clear();

                    txt_username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");

            }
            finally
            {
                conn.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
