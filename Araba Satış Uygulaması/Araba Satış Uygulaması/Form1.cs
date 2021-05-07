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

namespace Araba_Satış_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBAraba;Integrated Security=True");
        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        public void listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TblAraba", bgl);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox5.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = textBox5.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = textBox5.Text;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("insert into TblAraba (Model,Marka,Dosya,Fiyat) values (@p1,@p2,@p4,@p5)",bgl);

            k.Parameters.AddWithValue("@p1",textBox2.Text);
            k.Parameters.AddWithValue("@p2",textBox4.Text);
            k.Parameters.AddWithValue("@p4",textBox5.Text);
            k.Parameters.AddWithValue("@p5",textBox3.Text);
            k.ExecuteNonQuery();
            bgl.Close();
            listele();
            MessageBox.Show("Ekleme İşlemi Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("delete from TblAraba where ID=@p1", bgl);
            k.Parameters.AddWithValue("@p1", textBox1.Text);       
            k.ExecuteNonQuery();
            bgl.Close();
            listele();
            MessageBox.Show("Silme İşlemi Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand x = new SqlCommand("update TblAraba set Model=@p1,Marka=@p2,Dosya=@p3,Fiyat=@p4 where ID=@p5",bgl);
            x.Parameters.AddWithValue("@p1", textBox2.Text);
            x.Parameters.AddWithValue("@p2", textBox4.Text);
            x.Parameters.AddWithValue("@p3", textBox5.Text);
            x.Parameters.AddWithValue("@p4", textBox3.Text);
            x.Parameters.AddWithValue("@p5", textBox1.Text);
            x.ExecuteNonQuery();
            bgl.Close();
            listele();
            MessageBox.Show("Güncelleme İşlemi Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
