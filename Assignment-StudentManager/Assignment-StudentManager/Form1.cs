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

namespace Assignment_StudentManager
{
    public partial class Form1 : Form
    {
        Utility ut = new Utility();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        public void ShowCombobox() {
            conn = ut.OpenDB();
            conn.Open();
            cmd = new SqlCommand("select MaSV from SinhVien ",conn);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            cbbMaSV.DataSource = table;
            cbbMaSV.DisplayMember = "TenSV";
            cbbMaSV.ValueMember = "MaSV";
        
        }

        public void ShowData(string sql) {
            Utility.OpenConnection();
            dataGridView1.DataSource = Utility.getDataTable(sql);
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utility.OpenConnection();
            /*dataGridView1.DataSource = Utility.getDataTable("select MaMH,TenMH,DiemThi from Monhoc ");*/
            this.ShowCombobox();
        }

        private void cbbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Đoạn này load dữ liệu từ combobox qua Data Gridview
            // Lấy ra text hiển thị ở Combobox
            string a = cbbMaSV.Text;
            // Tạo 1 câu truy vấn tới database
            string sql = "select * from MonHoc where MaSV=N'" + a + "'";
            this.ShowData(sql);
            #endregion


            conn = ut.OpenDB();
            conn.Open();
            cmd = new SqlCommand("select * from SinhVien where MaSV = '" + cbbMaSV.SelectedValue.ToString() + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                txtHoSV.Text = reader.GetString(1).ToString();
                txtTenSV.Text = reader.GetString(2).ToString();
                txtNgaySinh.Text = reader.GetDateTime(3).ToString();
                txtGioiTinh.Text = reader.GetString(4).ToString();
                txtMaKH.Text = reader.GetString(5).ToString();


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không? ", "Thông báo!",MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Close();

            }
        }
    }
}
