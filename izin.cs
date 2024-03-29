using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace personeltakipform
{
    class izin:Personeller
    { 
        public izin()
        {
            izin.sql = "select *from izinTurleri";
            izin.value = "izinTurID";
            izin.text = "izinTuru";
        }
        private int _izinHareketID;
        private int _izinTurID;
        private int _kullaniciID;
        private string _izinTuru;
        private DateTime _izinBaslangic;
        private DateTime _izinBitis;
        private DateTime _saat;

        public int IzinHareketID { get => _izinHareketID; set => _izinHareketID = value; }
        public int IzinTurID { get => _izinTurID; set => _izinTurID = value; }
        public int KullaniciID { get => _kullaniciID; set => _kullaniciID = value; }
        public string IzinTuru { get => _izinTuru; set => _izinTuru = value; }
        public DateTime IzinBaslangic { get => _izinBaslangic; set => _izinBaslangic = value; }
        public DateTime IzinBitis { get => _izinBitis; set => _izinBitis = value; }
        public DateTime Saat { get => _saat; set => _saat = value; }

        public static SqlDataReader ListvieweKayitGetir(ListView lst) 
        {
            lst.Items.Clear();
            VeriTabani.baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from izinTurleri",VeriTabani.baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text =dr[0].ToString();
                ekle.SubItems.Add(dr[1].ToString());
                lst.Items.Add(ekle);
            }
            VeriTabani.baglanti.Close();
            return dr;
        }
    }
}
