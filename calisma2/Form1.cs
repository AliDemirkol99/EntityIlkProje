using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace calisma2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            StudentsEntities ogr = new StudentsEntities();
            dataGridView1.DataSource = ogr.student.ToList();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            student stu = new student();
            stu.Name = txtAd.Text;
            stu.Surname = txtSoyad.Text;
            stu.Email = txtEmail.Text;

            StudentsEntities ogr = new StudentsEntities();
            ogr.student.Add(stu);
            ogr.SaveChanges();

            listele();
        }
        
        private void btnSil_Click(object sender, EventArgs e)
        {
            StudentsEntities stu  = new StudentsEntities();
            var silinecek = stu.student.Find(secilenid);
            stu.SaveChanges();
            listele();
        }
        int secilenid;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            StudentsEntities stu = new StudentsEntities();
            var guncel = stu.student.Find(secilenid);
            guncel.Name = txtAd.Text;
            guncel.Surname = txtSoyad.Text;
            guncel.Email = txtEmail.Text;
            stu.SaveChanges();
            listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            StudentsEntities stu = new StudentsEntities();

            var sonuc = stu.student.Where(x => x.Name.Contains(txtAd.Text)).ToList();

            dataGridView1.DataSource = sonuc;
        }
    }
}
