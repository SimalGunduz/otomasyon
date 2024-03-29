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
    public partial class frmDepartmanlar : Form
    {
        public frmDepartmanlar()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Departmanlar d = new Departmanlar();
            d.Departman = txtDepartman.Text;
            d.Aciklama = txtAciklama.Text;


            string sorgu = "Insert into Departmanlar values('"+d.Departman+"','"+d.Aciklama+"')";
            SqlCommand komut = new SqlCommand();
            VeriTabani.ESG(komut, sorgu);
            MessageBox.Show("İşlem Başarılı.");
            Departmanlar.DepartmanGetir(listView1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmDepartmanlar_Load(object sender, EventArgs e)
        {
            Departmanlar.DepartmanGetir(listView1);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Departmanlar d = new Departmanlar();
            d.DepartmanID = int.Parse(txtDepartmanID.Text);
            d.Departman = txtDepartman.Text;
            d.Aciklama = txtAciklama.Text;


            string sorgu = "update departmanlar set departman='" + d.Departman + "',aciklama='"+d.Aciklama+"' where departmanID = '" + d.DepartmanID + "'";
            SqlCommand komut = new SqlCommand();
            VeriTabani.ESG(komut, sorgu);
            MessageBox.Show("İşlem Başarılı.");
            Departmanlar.DepartmanGetir(listView1);
        }

        private void btnSil_Click(object sender, EventArgs e)
        { 
            
            if (listView1.SelectedItems.Count > 0)
            {  
                Departmanlar d = new Departmanlar(); 
                d.DepartmanID = int.Parse(listView1.SelectedItems[0].SubItems[0].Text); 
                string sorgu = "delete from departmanlar where departmanID = '" + d.DepartmanID + "'";
                SqlCommand komut = new SqlCommand();
                VeriTabani.ESG(komut, sorgu);
                MessageBox.Show("İşlem Başarılı.");
                Departmanlar.DepartmanGetir(listView1);
            
            }
            else
            {
                MessageBox.Show("Önce kayıt seçilmelidir.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
     
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            txtDepartmanID.Text = listView1.SelectedItems[0].SubItems[0].Text; 
            txtDepartman.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtAciklama.Text =listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
}
