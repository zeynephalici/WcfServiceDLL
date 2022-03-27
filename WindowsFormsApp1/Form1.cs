using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WcfServiceDLL.WcfService _service = new WcfServiceDLL.WcfService();
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            _service.adi=txt_adi.Text;
           
            _service.Ekle();
            lbl_bilgi.Text = _service.hataMesaji;

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            _service.id = int.Parse(lbl_id.Text);
            _service.adi= txt_adi.Text;
            _service.Guncelle();
            lbl_bilgi.Text= _service.hataMesaji;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            _service.id = int.Parse(lbl_id.Text);
            _service.Sil();
            lbl_bilgi.Text = _service.hataMesaji;
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= _service.Listele();

            lbl_bilgi.Text = _service.hataMesaji;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_id.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txt_adi.Text = dataGridView1.Rows[e.RowIndex].Cells["adi"].Value.ToString();

        }
    }
}
