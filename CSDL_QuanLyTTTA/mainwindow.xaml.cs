using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSDL_QuanLyTTTA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //main form2 = new main();
            //form2.Show();
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập UserName!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.None);
                txtUserName.Focus();
            }
            else if (txtPassWord.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập UserName!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.None);
                txtPassWord.Focus();
            }
            if(txtUserName.Text.Trim()!=""&& txtPassWord.Text.Trim()!="")
            {
                kiemTraDangNhap(); //helloGiang
            }
        }
        public void kiemTraDangNhap()
        {
            // Cách sử dụng các Parameters & Stored Procedure trong SQL 

            // Bước 1. Gán giá trị cho các Parameters 
            //--> Mã hóa trực tuyến tại http://www.sha1-online.com/


            //Tạo các Parameters ngắn gọn
            SqlParameter[] sqlParams = {
                new SqlParameter("@Username",txtUserName.Text.Trim()),
                new SqlParameter("@Password", txtPassWord.Text.Trim())
            };

            // Bước 3: Tạo ra một DataTable rỗng để chứa dữ liệu khi kết quả trả về
            DataTable table = new DataTable();

            // Sử dụng Try Catch để bắt lỗi và hiện thị thông báo
            try
            {
                // Thi hành Stored Procedure có tên là "Chổ này trống hehe" và để dữ liệu về table 
                table = Libs.Database.Data.ExcuteToDataTable("tblUsername", CommandType.StoredProcedure, sqlParams);
                if(table.Rows.Count>0)
                {
                    MessageBox.Show("Login success!");
                }
                // Nếu có dữ liệu trả về thì
                if (table.Rows.Count > 0)
                {
                    //Dữ liệu đó được lấy ra và lưu vào đối tượng Username trong Libs để tái sử dụng các form khác
                    /*Libs.Username.username = table.Rows[0]["username"].ToString();
                    Libs.Username.permission = int.Parse(table.Rows[0]["permission"].ToString());
                    Libs.Username.iddepartment = int.Parse(table.Rows[0]["iddepartment"].ToString());
                    Libs.Username.namedepartment = table.Rows[0]["namedepartment"].ToString();*/

                    //Ẩn form này đi
                    this.Hide();

                    //Hiển thị Form Dashboard chính, 
                    /*frmDashboard frm_Dashboard = new frmDashboard();
                    frm_Dashboard.Show(); // Hiển thị Dashboard lên*/

                    //Kiểm tra để Lưu Remember UserName và Password
                    /*if (chRemember.Checked == true)
                    {
                        //Mã hóa thông tin Username và Password rồi lưu và Property Settings của phần mềm
                        Properties.Settings.Default.UserName = Libs.Database.Data.EncodeStringToBase64(tbUsername.Text.Trim());
                        Properties.Settings.Default.Password = Libs.Database.Data.EncodeStringToBase64(tbPassword.Text.Trim());
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        tbUsername.Text = "";
                        tbPassword.Text = "";
                        //Xóa vùng nhớ trong Property Settings
                        Properties.Settings.Default.UserName = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }*/

                }
                else
                {
                    MessageBox.Show("MSSV hoặc EMAIL không đúng!");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Phần mềm mất kết nối với cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

        }
    }
}
