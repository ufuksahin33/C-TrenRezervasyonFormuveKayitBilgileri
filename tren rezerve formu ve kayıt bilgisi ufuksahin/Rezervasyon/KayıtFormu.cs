using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rezervasyon
{
    public partial class KayıtFormu : Form
    {
        public KayıtFormu()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-CT2FF5V\\SQLEXPRESS;Initial Catalog = KayıtFormu; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        private void KayıtFormu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayıt = "insert into bilgi (isim,soyisim,telefon) values(@isim,@soyisim,@telefon)";
                SqlCommand komut = new SqlCommand(kayıt, connect);

                komut.Parameters.AddWithValue("@isim", txtIsım);

                komut.Parameters.AddWithValue("@soyisim", txtSoyısım);

                komut.Parameters.AddWithValue("@telefon", txtTelefon);

                komut.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Kaydedildi");
            }
            catch(Exception kayıttamamlandı)
            {
                MessageBox.Show("Kayıt Tamamlandı");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
