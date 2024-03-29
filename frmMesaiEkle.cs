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
    public partial class frmMesaiEkle : Form
    {
        public frmMesaiEkle()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmMesaiEkle_Load(object sender, EventArgs e)
        {
            int yil = int.Parse(DateTime.Now.Year.ToString());
            for (int i = yil; i >= (yil - 5); i--)
            {
                comboYil.Items.Add(i);
            }
            YapilanZamlar.ComboyaPersonelGetir(comboPersonelAdSsoyad);
        }
        Label lbl;
        private void comboPersonelAdSsoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl = new Label();
            YapilanZamlar.ComboSecilirsePersonelIDGetir(comboPersonelAdSsoyad,lbl);
            MessageBox.Show(lbl.Text);
        }

        private void btnMesaiEkle_Click(object sender, EventArgs e)
        {
            Kullanicilar k = new Kullanicilar();
            Personeller p = new Personeller();
            Mesailer m = new Mesailer();
            k.KullaniciID = Kullanicilar.kid;
            p.PERSONELID = int.Parse(lbl.Text);
            m.BaslangicSaati = dateTimeBaslangic.Text + " " + maskedtxtBaslangic.Text;
            m.BitisSaati = dateTimeBitis.Text + " " + maskedtxtBitis.Text;
            m.MesaiSaatUcreti =decimal.Parse(txtMesaiSaatUcreti.Text);
            m.Tutar = decimal.Parse(txtTutar.Text);
            m.Donem =comboAy.Text + "/" + comboYil.Text;
            m.Aciklama = txtAciklama.Text;
            m.Tarih = DateTime.Now;

            string sql = "insert into Mesailer(KullaniciID,PersonelID,BaslangicSaati,BitisSaati,MesaiSaatUcreti,Tutar,Donem,Aciklama,Tarih) " +
                "values('" + k.KullaniciID + "','" + p.PERSONELID + "','" +m.BaslangicSaati+ "','" + m.BitisSaati + "',@MSaatUcreti,@Tutar ,'" + m.Donem + "','" + m.Aciklama + "', @Tarih)";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.Add("@MSaatUcreti", SqlDbType.Decimal).Value = m.MesaiSaatUcreti;
            komut.Parameters.Add("@Tutar", SqlDbType.Decimal).Value = m.Tutar;
            komut.Parameters.Add("@Tarih", SqlDbType.Date).Value = m.Tarih;

            VeriTabani.ESG(komut,sql);
            MessageBox.Show("Mesai bilgileri eklendi.", "Mesailer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtMesaiSaatUcreti_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string baslangic = dateTimeBaslangic.Text +" "+ maskedtxtBaslangic.Text; 
                string bitis = dateTimeBitis.Text + " "+maskedtxtBitis.Text;
                TimeSpan saatfarki = DateTime.Parse(bitis) - DateTime.Parse(baslangic);
                double MSaatUcreti = double.Parse(txtMesaiSaatUcreti.Text); 
                double tutar =saatfarki.TotalHours * MSaatUcreti;
                txtTutar.Text = tutar.ToString("0.00");
            }
            catch 
            {

                
            }
        }
    }
}
