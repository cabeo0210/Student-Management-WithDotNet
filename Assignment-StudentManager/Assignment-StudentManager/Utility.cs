using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Assignment_StudentManager
{
    class Utility
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;

        #region Truy vấn có xác thực
        public SqlConnection OpenDB()
        {
            conn = new SqlConnection(@"Server=SE140952\SQLEXPRESS;database=QLSV;user id = sa; password=123456");
            return conn;

        }

        #endregion

        #region Hàm này dùng để mở kết nối tới cơ sở dữ liệu
        public static void OpenConnection()
        {
            // Đây là chuỗi kết nối xác thực
            string sql = @"Server=SE140952\SQLEXPRESS;database=QLSV;user id = sa; password=123456";
            try
            {
                // Mở kết nối tới cơ sở dữ liệu
                conn = new SqlConnection(sql);
                conn.Open();
            }
            catch (SqlException Ex)
            {

                throw;
            }


        }
        #endregion

        #region  Hàm này đóng và ngắt kết nối tới cơ sở dữ liệu
        public static void DisConnection()
        {
            // Đóng kết nối
            conn.Close();
            // Ngắt kết nối
            conn.Dispose();
            conn = null;

        }
        #endregion

        #region Bảng này để lưu cơ sở dữ liệu
        public static DataTable getDataTable(string sql)
        {
            // Khởi tạo 1 SqlCommand để trỏ tới dữ liệu trong database
            cmd = new SqlCommand(sql, conn);
            // Khởi tạo 1 SqlAdapter để lưu dữ liệu trên database
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            // Tạo 1 DataTable để hiển thị dữ liệu
            DataTable table = new DataTable();
            // Đổ dũ liệu vào bảng
            da.Fill(table);
            da.Dispose();
            cmd.Dispose();

            return table;


        }
        #endregion

        
    }
}

