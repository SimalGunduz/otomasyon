using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace personeltakipform
{
    public partial class frmPersonelMesaileri : Form
    {
        public frmPersonelMesaileri()
        {
            InitializeComponent();
        }

        private void frmPersonelMesaileri_Load(object sender, EventArgs e)
        {
            VeriTabani.Listele_Ara(dataGridViewPersoneller,"select PersonelID as ID,Adi as ADI,soyadi as SOYADI from Personeller");
        }

        private void dataGridViewPersoneller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string PersonelID = dataGridViewPersoneller.CurrentRow.Cells["ID"].Value.ToString();
            VeriTabani.Listele_Ara(dataGridViewMesailer,"select* from Mesailer where PersonelID='"+PersonelID+"'");
            txtPersonelID.Text = dataGridViewPersoneller.CurrentRow.Cells["ID"].Value.ToString();
            try
            {
                lblKayitSayisi.Text = "Toplam" + (dataGridViewMesailer.Rows.Count - 1) + " kayıt listelendi.";
                decimal tutar = 0;
                for (int i = 0; i < dataGridViewMesailer.Rows.Count - 1; i++)
                {
                    tutar = tutar + (decimal.Parse(dataGridViewMesailer.Rows[i].Cells["Tutar"].Value.ToString()));
                }
                lblTutar.Text = "Toplam Mesai Ücreti=" + tutar.ToString("0.00") + "TL";
            }
            catch 
            {

            }

        }

        private void txtMesaiIDAra_TextChanged(object sender, EventArgs e)
        {
            VeriTabani.Listele_Ara(dataGridViewMesailer,"select *from Mesailer where MesaiID like '"+txtMesaiIDAra.Text+"'");
            if (txtMesaiIDAra.Text=="")
            {
                string PersonelID = txtPersonelID.Text;
                VeriTabani.Listele_Ara(dataGridViewMesailer, "select* from Mesailer where PersonelID='" + PersonelID + "'");
            }
        }

        private void txtPersonelID_TextChanged(object sender, EventArgs e)
        {
            Primler.PersonelAdSoyadGetir(txtPersonelID, txtAdiSoyadi);
        }
    }
}
