using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbVagonNumarasıSecınız_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbVagonNumarasıSecınız.Text)
            {
                case "Vagon 1":
                    KoltukDoldur(8, false);
                    break;
                case "Vagon 2":
                    KoltukDoldur(12, true);
                    break;
                case "Vagon 3":
                    KoltukDoldur(10, false);
                    break;
                default:
                    break;
            }
            switch (cmbFrıma.Text)
            {
                case "TCDD Taşımacılık":
                    KoltukDoldur(8, false);
                    break;
                case "Başkent Express":
                    KoltukDoldur(10, true);
                    break;
            }
        }

        void KoltukDoldur(int sira, bool arkaKoltuk)
        {
            yavaslat:

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = ctrl as Button;
                    if (btn.Text=="Kaydet")
                    {
                        continue;
                    }
                    else
                    {
                        this.Controls.Remove(ctrl);
                        goto yavaslat;
                    }
                }
            }

            int koltukNo = 1;
            for (int i = 0; i < sira; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arkaKoltuk == true)
                    {
                        if (i != sira - 1 && j == 2)
                        {
                            continue;
                        }
                    }
                      else
                        if (j == 2)
                          continue;
                        if (j == 3)
                          continue;
                    Button koltuk = new Button();
                    koltuk.Height = koltuk.Width = 40;
                    koltuk.Top = 30 + (i * 45);
                    koltuk.Left = 5 + (j * 45);
                    koltuk.Text = koltukNo.ToString();
                    koltukNo++;
                    koltuk.ContextMenuStrip = 
                        contextMenuStrip1;
                    koltuk.MouseDown += Koltuk_MouseDown;
                    this.Controls.Add(koltuk);
                }
            }
        }

        Button tiklanan;

        private void Koltuk_MouseDown(object sender, MouseEventArgs e)
        {
            tiklanan = sender as Button;
        }




        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void rezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbVagonNumarasıSecınız.SelectedIndex == -1 ||
                cmbNereden.SelectedIndex == -1 ||
                cmbNereye.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz");
                return;
            }
                KayıtFormu kf = new KayıtFormu();
               DialogResult sonuc= kf.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Format("{0} {1}", kf.txtIsım.Text,kf.txtSoyısım.Text);
                lvi.SubItems.Add(kf.txtTelefon.Text);
                if (kf.rdbBay.Checked)
                {
                    lvi.SubItems.Add("BAY");
                    tiklanan.BackColor = Color.Blue;
                }
                if(kf.rdbBayan.Checked)
                {
                        lvi.SubItems.Add("BAYAN");
                    tiklanan.BackColor = Color.Pink;
                }
                lvi.SubItems.Add(cmbNereden.Text);
                lvi.SubItems.Add(cmbNereye.Text);
                lvi.SubItems.Add(tiklanan.Text);
                lvi.SubItems.Add(dtpTarıhSecınız.Text);
                lvi.SubItems.Add(nudFıyat.Value.ToString());
                listView1.Items.Add(lvi);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
