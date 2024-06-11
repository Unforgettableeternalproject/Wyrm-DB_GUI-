using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_GUI
{
    public partial class GUI_Main : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private bool isConnected = false;
        private bool canRecognize = false;
        public GUI_Main()
        {
            InitializeComponent();
        }

        private void GUI_Main_Load(object sender, EventArgs e)
        {
            Reset_All();
            ResponseConsole.Clear();
        }

        private void Reset_All()
        {
            isConnected = false;
            canRecognize = false;
            IPTbox.Enabled = true;
            PortTbox.Enabled = true;
            DBTbox.Enabled = true;
            UserTbox.Enabled = true;
            PassDisplay.Enabled = true;
            IPTbox.Clear();
            PortTbox.Clear();
            DBTbox.Clear();
            UserTbox.Clear();
            PassTbox.Clear();
            CommandEntry.Clear();
            CommandEntry.Enabled = false;
            Disconnect.Enabled = false;
            Clear.Enabled = false;
            ExampleRegion.Enabled = false;
            Terminal.Enabled = false;
            Submit.Enabled = false;
            NotConnected.Visible = true;
            ExampleCbox.SelectedIndex = 0;
            Status.Text = "連線狀態: 未連線";
            Status.ForeColor = Color.Maroon;
        }

        #region Components
        private void Connect_Click(object sender, EventArgs e)
        {
            string serverIP = IPTbox.Text;
            string port = PortTbox.Text;
            string database = DBTbox.Text;
            string username = UserTbox.Text;
            string password = PassTbox.Text;

            // Step 1: Validate server IP format
            if (!IsValidServerIP(serverIP))
            {
                MessageBox.Show("錯誤：無效的伺服器位址格式。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed to initialize database connection
            ValidateAndConnect(serverIP, port, database, username, password);
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {

        }

        private void Charlie_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/calculusfkyou"; // 替换为你的GitHub URL
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"試圖導覽至網頁時發生以下錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bernie_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Unforgettableeternalproject"; // 替换为你的GitHub URL
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"試圖導覽至網頁時發生以下錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Helper Functions
        private bool IsValidServerIP(string serverIP)
        {
            // Validate server IP format (this is a basic validation, can be improved)
            string pattern = @"^[a-zA-Z0-9.-]+$";
            return Regex.IsMatch(serverIP, pattern);
        }

        private void ValidateAndConnect(string serverIP, string port, string database, string username, string password)
        {
            string connectionString = $"Server={serverIP};Port={port};Database={database};User={username};Password={password};";
            using (MySqlConnection tempConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    tempConnection.Open();
                    MessageBox.Show("成功連線到資料庫!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeDatabaseConnection(connectionString);
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1042: // Unable to connect to any of the specified MySQL hosts
                            MessageBox.Show("錯誤：無法連接到伺服器。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 1049: // Unknown database
                            MessageBox.Show("錯誤：該資料庫不存在或為空。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 1045: // Access denied for user (using password: YES)
                            MessageBox.Show("錯誤：使用者名稱或密碼有誤，請再試一遍。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            MessageBox.Show($"錯誤：未捕捉到的錯誤如下： {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }

        private void UpdateLog()
        {

        }
        private void Connection()
        {
            Disconnect.Enabled = true;
            Connect.Enabled = false;
            IPTbox.Enabled = false;
            PortTbox.Enabled = false;
            DBTbox.Enabled = false;
            UserTbox.Enabled = false;
            PassTbox.Enabled = false;
            CommandEntry.Enabled = true;
            Terminal.Enabled = true;
            Submit.Enabled = true;
            NotConnected.Visible = false;

            if(canRecognize) ExampleRegion.Enabled = true;

            Status.Text = "連線狀態: 已連線";
            Status.ForeColor = Color.YellowGreen;
            InitializeDatagrid();
        }

        #endregion
        #region Database Handling
        private void InitializeDatabaseConnection(string _connectionString)
        {
            string connectionString = _connectionString;
            connection = new MySqlConnection(connectionString);
            isConnected = true;
            if(connectionString == "Server=0.tcp.jp.ngrok.io;Port=11051;Database=411177034;User=411177034;Password=411177034;") canRecognize = true;

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Connection();
            }
        }

        private void InitializeDatagrid()
        {
            try
            {
                string query = "SHOW TABLES;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Assuming your DataGridView is named `mainDataGridView`
                MainGrid.DataSource = dt;
                MainGrid.AutoResizeColumns();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"試圖初始化資料表時遇見以下錯誤: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateDatagrid(string query)
        {

        }

        private void RetrieveInformation()
        {
            string someName = "Georgi";
            string query = "SELECT first_name, last_name FROM employees WHERE first_name = @firstName";

            using (command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", someName);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString("first_name");
                            string lastName = reader.GetString("last_name");
                            MessageBox.Show($"First name: {firstName}, Last name: {lastName}");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void InsertInformation()
        {
            string query = "INSERT INTO employees (first_name, last_name) VALUES (@firstName, @lastName)";

            using (command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", "Maria");
                command.Parameters.AddWithValue("@lastName", "DB");

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Data inserted successfully!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        #endregion
    }

    #region Other Infos
    //user_setting = {
    //    "user": "411177034",
    //    "password": "411177034",
    //    "host": "0.tcp.jp.ngrok.io",
    //    "port": 11051,
    //    "database": "411177034"
    //}
    #endregion
}
