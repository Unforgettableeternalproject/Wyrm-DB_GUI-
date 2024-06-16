using DB_GUI.Properties;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

// 範例資料庫的部份為了實施資訊安全因此不提供在Github原始碼內，請自行建立一個dbConfig.json檔案並填入以下內容：
// {
//     "Server": "your_server_ip",
//     "Port": "your_port",
//     "Database": "your_database",
//     "User": "your_username",
//     "Password": "your_password"
// }

namespace DB_GUI
{
    public partial class GUI_Main : Form
    {
        private MySqlConnection connection;
        private bool isConnected = false;
        private bool canRecognize = false;
        private StringBuilder currentQuery = new StringBuilder();
        private Queue<string> queryQueue = new Queue<string>();
        private Stack<string> history = new Stack<string>();

        public GUI_Main()
        {
            InitializeComponent();
            #region Extra Events
            ResponseConsole.Enter += ResponseConsole_Enter;
            FormClosing += ClosingConfirmation;
            CommandEntry.KeyDown += CommandEntry_KeyDown;
            #endregion
        }

        private void GUI_Main_Load(object sender, EventArgs e)
        {
            Reset_All();
            ResponseConsole.Clear();
            UpdateLog("查詢程式啟動...");
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
                UpdateLog("錯誤：無效的伺服器位址格式。");
                MessageBox.Show("錯誤：無效的伺服器位址格式。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed to initialize database connection
            ValidateAndConnect(serverIP, port, database, username, password);
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要中斷與資料庫的連線嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (connection.State == ConnectionState.Open) connection.Close();
                Reset_All();
                UpdateLog("已斷開與資料庫的連線!");
                MessageBox.Show("連線已中斷!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else DoNothing();
        }

        private void Charlie_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/calculusfkyou";
            try
            {
                DialogResult redirect = MessageBox.Show("將導引至外部網頁 (Github.com)，確認要繼續嗎?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (redirect == DialogResult.OK)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                else DoNothing();
            }
            catch (Exception ex)
            {
                UpdateLog($"試圖導覽至網頁時發生以下錯誤: {ex.Message}");
                MessageBox.Show($"試圖導覽至網頁時發生以下錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bernie_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Unforgettableeternalproject";
            try
            {
                DialogResult redirect = MessageBox.Show("將導引至外部網頁 (Github.com)，確認要繼續嗎?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (redirect == DialogResult.OK)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                else DoNothing();
            }
            catch (Exception ex)
            {
                UpdateLog($"試圖導覽至網頁時發生以下錯誤: {ex.Message}");
                MessageBox.Show($"試圖導覽至網頁時發生以下錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Append_Click(object sender, EventArgs e)
        {
            string input = CommandEntry.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                currentQuery.AppendLine(input); // 使用 AppendLine 確保每行輸入都在新行
                CommandEntry.Clear();

                if (input.EndsWith(";"))
                {
                    queryQueue.Enqueue(currentQuery.ToString());
                    currentQuery.Clear();
                    MessageBox.Show("查詢已加入佇列。");
                }

                Clear.Enabled = true;
            }
            UpdateLog("", "QueryLog");
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string input = CommandEntry.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                currentQuery.AppendLine(input);
                CommandEntry.Clear();
                Console.WriteLine(currentQuery);
                if (currentQuery.Length > 0 && !currentQuery.ToString().Trim().EndsWith(";"))
                {
                    UpdateLog("查詢尚未完成。請使用分號結束查詢。");
                    MessageBox.Show("查詢尚未完成。請使用分號結束查詢。");
                    return;
                }

                if (queryQueue.Count > 0)
                {
                    string queryToExecute = queryQueue.Dequeue();
                    ExecuteQuery(queryToExecute);
                }
                else
                {
                    ExecuteQuery(currentQuery.ToString().Trim());
                    currentQuery.Clear();
                }

                UpdateLog("", "QueryLog");
                if (!string.IsNullOrEmpty(currentQuery.ToString()) || queryQueue.Count > 0) Clear.Enabled = true;
            }
            else if (queryQueue.Count > 0)
            {
                string queryToExecute = queryQueue.Dequeue();
                ExecuteQuery(queryToExecute);
                if (queryQueue.Count > 0) Clear.Enabled = true;
                UpdateLog("", "QueryLog");
            }
            else
            {
                UpdateLog("查詢尚未完成。請使用分號結束查詢。");
                MessageBox.Show("查詢尚未完成。請使用分號結束查詢。");
                return;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (currentQuery.Length > 0)
            {
                var result = MessageBox.Show("尚有未完成的查詢。確定要清除嗎？", "確認", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    currentQuery.Clear();
                    UpdateLog("已清除查詢。");
                    MessageBox.Show("未完成的查詢已清除。");
                    Clear.Enabled = false;
                }
            }
            else if (queryQueue.Count > 0)
            {
                var result = MessageBox.Show("佇列中有已完成的查詢。確定要清除嗎？", "確認", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    queryQueue.Clear();
                    UpdateLog("已清除佇列中的查詢。");
                    MessageBox.Show("所有佇列中的查詢已清除。");
                    Clear.Enabled = false;
                }
            }
            UpdateLog("", "QueryLog");
        }

        private void ExConfirm_Click(object sender, EventArgs e)
        {
            int exampleID = ExampleCbox.SelectedIndex;
            switch (exampleID) 
            {
                case 0:
                    queryQueue.Enqueue(
                        "SELECT VIN, c.customerName\n" +
                        "FROM `customer's car`\n" +
                        "NATURAL JOIN vehicles as v\n" +
                        "NATURAL JOIN customers as c\n" +
                        "WHERE modelName IN(\n" +
                        "SELECT s.modelName\n" +
                        "FROM suppliers as s\n" +
                        "WHERE manufacturingDate BETWEEN '2014-01-01' AND '2017-12-31'\n" +
                        "AND manufacturingPart = 'transmission'\n" +
                        "AND supplierName = 'Getrag'\n" +
                        ")");
                    UpdateLog("執行範例查詢一：持有來自Getrag供應商製造的缺陷零件組成的車的顧客。");
                    Submit.PerformClick();
                    break;
                case 1:
                    queryQueue.Enqueue(
                        "SELECT dealerName\n" +
                        "FROM(\n" +
                        "SELECT dealerID, dealerName, SUM(saleFigure) AS sumSale\n" +
                        "FROM salerecord AS s\n" +
                        "NATURAL JOIN dealers\n" +
                        "WHERE DATEDIFF(CURRENT_DATE, saleDate) < 365\n" +
                        "GROUP BY dealerID, dealerName\n" +
                        ") AS dIdNs\n" +
                        "ORDER BY sumSale DESC\n" +
                        "LIMIT 1; ");
                    UpdateLog("執行範例查詢二：過去一年裡擁有最高銷售額的經銷商。");
                    Submit.PerformClick();
                    break;
                case 2:
                    queryQueue.Enqueue(
                        "SELECT brandName\n" +
                        "FROM salerecord\n" +
                        "NATURAL JOIN vehicles\n" +
                        "NATURAL JOIN models\n" +
                        "NATURAL JOIN brands\n" +
                        "WHERE DATEDIFF(CURRENT_DATE, saleDate) < 365\n" +
                        "GROUP BY brandName\n" +
                        "ORDER BY COUNT(*) DESC\n" +
                        "LIMIT 2; ");
                    UpdateLog("執行範例查詢三：過去一年裡具有最高銷售額的前兩個品牌。");
                    Submit.PerformClick();
                    break;
                case 3:
                    queryQueue.Enqueue(
                        "SELECT MONTH(saleDate) as saleMonth\n" +
                        "FROM salerecord\n" +
                        "NATURAL JOIN vehicles\n" +
                        "WHERE bodyStyle LIKE '%SUV%'\n" +
                        "GROUP BY saleMonth\n" +
                        "ORDER BY COUNT(*) DESC\n" +
                        " LIMIT 1; "
                        );
                    UpdateLog("執行範例查詢四：銷售最多SUV的月份。");
                    Submit.PerformClick();
                    break;
                case 4:
                    queryQueue.Enqueue(
                        "SELECT dealerName\n" +
                        "FROM inventory\n" +
                        "NATURAL JOIN dealers\n" +
                        "GROUP BY dealerName\n" +
                        "ORDER BY AVG(DATEDIFF(CURRENT_DATE, inventoryTime)) DESC\n" +
                        "LIMIT 1; "
                        );
                    UpdateLog("執行範例查詢五：持有最久庫存的經銷商。");
                    Submit.PerformClick();
                    break;
            }
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            bool isHidden = PassTbox.PasswordChar != '\0';
            if (isHidden)
            {
                PassTbox.PasswordChar = '\0';
                Toggle.BackgroundImage = Resources.Show;
            }
            else
            {
                PassTbox.PasswordChar = '*';
                Toggle.BackgroundImage = Resources.Hide;
            }
        }

        private void ResponseConsole_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void CommandEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                Append.PerformClick();
                e.SuppressKeyPress = true; // 防止輸入換行
            }
            else if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Alt)
            {
                Clear.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Submit.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region Helper Functions

        private string ReadConnectionStringFromFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath).Trim();
            }
            catch (Exception ex)
            {
                UpdateLog($"範例不存在，無法讀取資料庫配置文件: {ex.Message}");
                MessageBox.Show($"範例不存在，無法讀取資料庫配置文件: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
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
                    UpdateLog("成功連線到資料庫: " + database.ToString() + "!");
                    MessageBox.Show("成功連線到資料庫!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeDatabaseConnection(connectionString);
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1042: // Unable to connect to any of the specified MySQL hosts
                            UpdateLog("錯誤：無法連接到伺服器。");
                            MessageBox.Show("錯誤：無法連接到伺服器。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 1049: // Unknown database
                            UpdateLog("錯誤：該資料庫不存在或為空。");
                            MessageBox.Show("錯誤：該資料庫不存在或為空。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 1045: // Access denied for user (using password: YES)
                            UpdateLog("錯誤：使用者名稱或密碼有誤，請再試一遍。");
                            MessageBox.Show("錯誤：使用者名稱或密碼有誤，請再試一遍。", "資訊有誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            UpdateLog($"錯誤：未捕捉到的錯誤如下： {ex.Message}");
                            MessageBox.Show($"錯誤：未捕捉到的錯誤如下： {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }

        private void ExecuteQuery(string query)
        {
            UpdateLog($"已送出查詢:\n{query}\n-----------------分隔線-----------------");
            MessageBox.Show("查詢已送出。");
            // 此處為與資料庫連線並執行查詢的程式碼
            UpdateDatagrid(query); // 假設 UpdateGrid 是用來更新 DataGridView 的方法
        }

        private void DoNothing()
        {
            ;
        }
        private void UpdateLog(string message, string key = "Default")
        {
            string timestamp = "<" + DateTime.Now.ToString("HH:mm:ss") + "> ";
            if (ResponseConsole.InvokeRequired)
            {
                ResponseConsole.Invoke(new Action(() => UpdateLogInternal(timestamp, message, key)));
            }
            else
            {
                UpdateLogInternal(timestamp, message, key);
            }
        }

        private void UpdateLogInternal(string timestamp, string message, string key)
        {
            ResponseConsole.ReadOnly = false;

            switch (key)
            {
                case "Default":
                    ResponseConsole.AppendText(timestamp + "系統訊息: " + message + Environment.NewLine);
                    break;
                case "QueryLog":
                    string queryMsg = $"目前佇列中有{queryQueue.Count}筆查詢。";
                    string curQuery = currentQuery.Length != 0 ? $"\n尚未完成的查詢語句如下:\n{currentQuery.ToString().Trim()}" : "";
                    ResponseConsole.AppendText(timestamp + queryMsg + curQuery + "\n-----------------分隔線-----------------" + Environment.NewLine);
                    break;
                default:
                    ResponseConsole.AppendText(timestamp + "未知訊息: " + message + Environment.NewLine);
                    break;
            }

            ResponseConsole.ReadOnly = true;
            ResponseConsole.ScrollToCaret();
        }

        private void ExportToCsv(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            try
            {
                // Add the headers
                for (int col = 0; col < MainGrid.Columns.Count; col++)
                {
                    csvContent.Append(MainGrid.Columns[col].HeaderText);
                    if (col < MainGrid.Columns.Count - 1)
                    {
                        csvContent.Append(",");
                    }
                }
                csvContent.AppendLine();

                // Add the rows
                for (int row = 0; row < MainGrid.Rows.Count; row++)
                {
                    for (int col = 0; col < MainGrid.Columns.Count; col++)
                    {
                        csvContent.Append(MainGrid.Rows[row].Cells[col].Value?.ToString());
                        if (col < MainGrid.Columns.Count - 1)
                        {
                            csvContent.Append(",");
                        }
                    }
                    csvContent.AppendLine();
                }

                // Write to file
                File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
                UpdateLog("匯出程序 - 檔案匯出成功!");
                MessageBox.Show("檔案匯出成功!", "匯出程序", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                UpdateLog("匯出程序 - 檔案匯出失敗!");
                MessageBox.Show($"檔案匯出失敗，錯誤訊息:{e}", "匯出程序", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Connection()
        {
            HistoryControl.Enabled = true;
            Disconnect.Enabled = true;
            Connect.Enabled = false;
            IPTbox.Enabled = false;
            PortTbox.Enabled = false;
            DBTbox.Enabled = false;
            UserTbox.Enabled = false;
            PassTbox.Enabled = false;
            Terminal.Enabled = true;
            NotConnected.Visible = false;

            if(canRecognize) ExampleRegion.Enabled = true;

            Status.Text = "連線狀態: 已連線";
            Status.ForeColor = Color.YellowGreen;
            UpdateDatagrid("SHOW TABLES;");
            Undo.Enabled = false;
        }

        private void Reset_All()
        {
            history.Clear();
            currentQuery.Clear();
            queryQueue.Clear();
            connection = null;
            isConnected = false;
            canRecognize = false;
            IPTbox.Enabled = true;
            PortTbox.Enabled = true;
            DBTbox.Enabled = true;
            UserTbox.Enabled = true;
            PassTbox.Enabled = true;
            Connect.Enabled = true;
            IPTbox.Clear();
            PortTbox.Clear();
            DBTbox.Clear();
            UserTbox.Clear();
            PassTbox.Clear();
            CommandEntry.Clear();
            HistoryControl.Enabled = false;
            Disconnect.Enabled = false;
            Clear.Enabled = false;
            ExampleRegion.Enabled = false;
            Terminal.Enabled = false;
            NotConnected.Visible = true;
            MainGrid.DataSource = null;
            MainGrid.Rows.Clear();
            MainGrid.Columns.Clear();
            MainGrid.Refresh();
            ExampleCbox.SelectedIndex = 0;
            Status.Text = "連線狀態: 未連線";
            Status.ForeColor = Color.Maroon;
        }

        private void ClosingConfirmation(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定要離開應用程式嗎？", "確認關閉", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private bool IsAllowedQuery(string query)
        {
            string trimmedQuery = query.Trim().ToUpper();
            return trimmedQuery.StartsWith("SELECT") || trimmedQuery.StartsWith("SHOW");
        }
        #endregion

        #region Database Handling
        private void InitializeDatabaseConnection(string _connectionString)
        {
            string connectionString = _connectionString;
            connection = new MySqlConnection(connectionString);
            isConnected = true;
            if(connectionString == ReadConnectionStringFromFile(@"..\..\Secrets\dbConfig.txt")) canRecognize = true;

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                UpdateLog($"資料庫連線錯誤: {ex.Message}");
                MessageBox.Show($"資料庫連線錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                Connection();
            }
        }

        private void UpdateDatagrid(string query)
        {
            try
            {
                // 檢查是否為 SELECT 查詢
                if (!IsAllowedQuery(query))
                {
                    throw new InvalidOperationException("僅允許查詢操作 (SELECT)");
                }

                if (connection.State != ConnectionState.Open) connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                MainGrid.DataSource = dt;
                MainGrid.AutoResizeColumns();
                history.Push(query);
                Undo.Enabled = true;
            }
            catch (InvalidOperationException ex)
            {
                UpdateLog($"試圖執行非查詢操作時遇見以下錯誤: {ex.Message}");
                MessageBox.Show($"試圖執行非查詢操作時遇見以下錯誤: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                string message = "SQL錯誤：";
                switch (ex.Number)
                {
                    case 1064: // SQL語法錯誤
                        message += "語法錯誤";
                        break;
                    case 1049: // 未知資料庫
                        message += "資料庫不存在";
                        break;
                    case 1045: // 存取被拒
                        message += "使用者或密碼錯誤";
                        break;
                    default:
                        message += ex.Message;
                        break;
                }
                UpdateLog($"試圖獲得資料表時遇見以下錯誤: {message}");
                MessageBox.Show($"試圖獲得資料表時遇見以下錯誤: {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Extra Menu Methods
        private void ExampleDatabase_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                string filePath = @"..\..\Secrets\dbConfig.json";
                try
                {
                    string json = File.ReadAllText(filePath);
                    DBConfig config = JsonConvert.DeserializeObject<DBConfig>(json);

                    IPTbox.Text = config.Server;
                    PortTbox.Text = config.Port;
                    DBTbox.Text = config.Database;
                    UserTbox.Text = config.User;
                    PassTbox.Text = config.Password;
                    Connect.PerformClick();
                }
                catch (Exception ex)
                {
                    UpdateLog($"無法讀取資料庫配置: {ex.Message}");
                    MessageBox.Show($"無法讀取資料庫配置: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("你已連接到資料庫，無法使用範例資料庫。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SystemReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("這麼做將會重置整個系統，包含正在進行的資料查詢，確認要繼續嗎?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) 
            {
                Reset_All();
                ResponseConsole.Clear();
                UpdateLog("查詢程式啟動...");
                MessageBox.Show("已重置系統!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                UpdateLog("匯出程序 - 未連線至資料庫。");
                MessageBox.Show("你尚未連接到資料庫!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files|*.csv";
                saveFileDialog.Title = "匯出為CSV檔案";
                saveFileDialog.ShowDialog();

                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    ExportToCsv(saveFileDialog.FileName);
                }
            }
        }

        private void UserManual_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
        }

        private void ShowTable_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("將會進行SHOW TABLES;查詢並清空目前佇列中的查詢，確定嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                currentQuery.Clear();
                queryQueue.Enqueue("SHOW TABLES;");
                history.Clear();
                history.Push("SHOW TABLES;");
                Submit.PerformClick();
                Undo.Enabled = false;
            }
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("將回到上一筆查詢，確定嗎?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                history.Pop();
                currentQuery.Clear();
                queryQueue.Enqueue(history.Pop());
                Submit.PerformClick();

                if (history.Count == 1) Undo.Enabled = false;
            }
        }
        #endregion
        class DBConfig
        {
            public string Server { get; set; }
            public string Port { get; set; }
            public string Database { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }
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
