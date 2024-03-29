using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace personeltakipform
{
    public partial class frmYeniKullanici : Form
    {
        public frmYeniKullanici()
        {
            InitializeComponent();
        }

        private void frmYeniKullanici_Load(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Temizle()
        {
            comboSoru.Text = "";
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kullanicilar k = new Kullanicilar();
            k.KullaniciAdi = txtKullaniciAdi.Text;
            k.Sifre = txtSifre.Text;
            k.AdiSoyadi =txtAdisoyadi.Text; 
            k.Soru =comboSoru.Text; 
            k.Cevap =txtCevap.Text; 
            k.Aciklama =txtAciklama.Text;
            k.Tarih= DateTime.Now;

            if (txtSifre.Text==txtSifreTekrar.Text)
            {
                string sql = "insert into Kullanicilar values('"+k.KullaniciAdi+"','"+k.Sifre+"','"+k.AdiSoyadi+"','"+k.Soru+"','"+k.Cevap+"'," +
                "@Tarih,'"+k.Aciklama+"')";
                SqlCommand komut = new SqlCommand();
                komut.Parameters.Add("@Tarih",SqlDbType.Date).Value=k.Tarih;
                VeriTabani.ESG(komut,sql);
                MessageBox.Show("Yeni kullanici eklendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                this.Close();

            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
