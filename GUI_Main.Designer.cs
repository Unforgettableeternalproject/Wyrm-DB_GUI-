using System.Drawing;
using System.Windows.Forms;

namespace DB_GUI
{
    partial class GUI_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Datagrid = new System.Windows.Forms.Panel();
            this.NotConnected = new System.Windows.Forms.Label();
            this.MainGrid = new System.Windows.Forms.DataGridView();
            this.Options = new System.Windows.Forms.Panel();
            this.ExampleRegion = new System.Windows.Forms.Panel();
            this.ExConfirm = new System.Windows.Forms.Button();
            this.ExampleCbox = new System.Windows.Forms.ComboBox();
            this.ExampleDisplay = new System.Windows.Forms.Label();
            this.Disconnect = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.PromptRegion = new System.Windows.Forms.Panel();
            this.PassTbox = new System.Windows.Forms.TextBox();
            this.UserTbox = new System.Windows.Forms.TextBox();
            this.DBTbox = new System.Windows.Forms.TextBox();
            this.PortTbox = new System.Windows.Forms.TextBox();
            this.IPTbox = new System.Windows.Forms.TextBox();
            this.PassDisplay = new System.Windows.Forms.Label();
            this.UserDisplay = new System.Windows.Forms.Label();
            this.DBDisplay = new System.Windows.Forms.Label();
            this.PortDisplay = new System.Windows.Forms.Label();
            this.IPDisplay = new System.Windows.Forms.Label();
            this.Terminal = new System.Windows.Forms.Panel();
            this.ResponseConsole = new System.Windows.Forms.RichTextBox();
            this.Append = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.CommandEntry = new System.Windows.Forms.TextBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.Credits = new System.Windows.Forms.Panel();
            this.Introduction = new System.Windows.Forms.Label();
            this.BernieName = new System.Windows.Forms.Label();
            this.CharlieName = new System.Windows.Forms.Label();
            this.Bernie = new System.Windows.Forms.Button();
            this.Charlie = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.GeneralDescription = new System.Windows.Forms.ToolTip(this.components);
            this.Debug = new System.Windows.Forms.Button();
            this.Datagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.Options.SuspendLayout();
            this.ExampleRegion.SuspendLayout();
            this.PromptRegion.SuspendLayout();
            this.Terminal.SuspendLayout();
            this.Credits.SuspendLayout();
            this.Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // Datagrid
            // 
            this.Datagrid.Controls.Add(this.NotConnected);
            this.Datagrid.Controls.Add(this.MainGrid);
            this.Datagrid.Location = new System.Drawing.Point(3, 92);
            this.Datagrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Datagrid.Name = "Datagrid";
            this.Datagrid.Size = new System.Drawing.Size(623, 323);
            this.Datagrid.TabIndex = 0;
            // 
            // NotConnected
            // 
            this.NotConnected.AutoSize = true;
            this.NotConnected.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.NotConnected.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NotConnected.Location = new System.Drawing.Point(125, 131);
            this.NotConnected.Name = "NotConnected";
            this.NotConnected.Size = new System.Drawing.Size(370, 45);
            this.NotConnected.TabIndex = 1;
            this.NotConnected.Text = "目前沒有連線到資料庫";
            // 
            // MainGrid
            // 
            this.MainGrid.AllowUserToAddRows = false;
            this.MainGrid.AllowUserToDeleteRows = false;
            this.MainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.Location = new System.Drawing.Point(0, 0);
            this.MainGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.ReadOnly = true;
            this.MainGrid.Size = new System.Drawing.Size(623, 323);
            this.MainGrid.TabIndex = 0;
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Options.Controls.Add(this.ExampleRegion);
            this.Options.Controls.Add(this.Disconnect);
            this.Options.Controls.Add(this.Connect);
            this.Options.Controls.Add(this.PromptRegion);
            this.Options.Location = new System.Drawing.Point(630, 92);
            this.Options.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(214, 323);
            this.Options.TabIndex = 1;
            // 
            // ExampleRegion
            // 
            this.ExampleRegion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ExampleRegion.Controls.Add(this.ExConfirm);
            this.ExampleRegion.Controls.Add(this.ExampleCbox);
            this.ExampleRegion.Controls.Add(this.ExampleDisplay);
            this.ExampleRegion.Location = new System.Drawing.Point(5, 236);
            this.ExampleRegion.Name = "ExampleRegion";
            this.ExampleRegion.Size = new System.Drawing.Size(204, 82);
            this.ExampleRegion.TabIndex = 3;
            // 
            // ExConfirm
            // 
            this.ExConfirm.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExConfirm.Location = new System.Drawing.Point(61, 43);
            this.ExConfirm.Name = "ExConfirm";
            this.ExConfirm.Size = new System.Drawing.Size(82, 32);
            this.ExConfirm.TabIndex = 12;
            this.ExConfirm.Text = "確認查詢";
            this.ExConfirm.UseVisualStyleBackColor = true;
            // 
            // ExampleCbox
            // 
            this.ExampleCbox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExampleCbox.FormattingEnabled = true;
            this.ExampleCbox.Items.AddRange(new object[] {
            "查詢一: 缺陷零件",
            "查詢二: 經銷商",
            "查詢三: 品牌",
            "查詢四: SUV月份",
            "查詢五: 庫存最久"});
            this.ExampleCbox.Location = new System.Drawing.Point(92, 11);
            this.ExampleCbox.Name = "ExampleCbox";
            this.ExampleCbox.Size = new System.Drawing.Size(109, 24);
            this.ExampleCbox.TabIndex = 11;
            // 
            // ExampleDisplay
            // 
            this.ExampleDisplay.AutoSize = true;
            this.ExampleDisplay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExampleDisplay.Location = new System.Drawing.Point(2, 14);
            this.ExampleDisplay.Name = "ExampleDisplay";
            this.ExampleDisplay.Size = new System.Drawing.Size(89, 17);
            this.ExampleDisplay.TabIndex = 10;
            this.ExampleDisplay.Text = "執行範例查詢:";
            // 
            // Disconnect
            // 
            this.Disconnect.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Disconnect.Location = new System.Drawing.Point(133, 189);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(69, 32);
            this.Disconnect.TabIndex = 2;
            this.Disconnect.Text = "斷線";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // Connect
            // 
            this.Connect.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Connect.Location = new System.Drawing.Point(14, 189);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(69, 32);
            this.Connect.TabIndex = 1;
            this.Connect.Text = "連線";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // PromptRegion
            // 
            this.PromptRegion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PromptRegion.Controls.Add(this.PassTbox);
            this.PromptRegion.Controls.Add(this.UserTbox);
            this.PromptRegion.Controls.Add(this.DBTbox);
            this.PromptRegion.Controls.Add(this.PortTbox);
            this.PromptRegion.Controls.Add(this.IPTbox);
            this.PromptRegion.Controls.Add(this.PassDisplay);
            this.PromptRegion.Controls.Add(this.UserDisplay);
            this.PromptRegion.Controls.Add(this.DBDisplay);
            this.PromptRegion.Controls.Add(this.PortDisplay);
            this.PromptRegion.Controls.Add(this.IPDisplay);
            this.PromptRegion.Location = new System.Drawing.Point(4, 5);
            this.PromptRegion.Name = "PromptRegion";
            this.PromptRegion.Size = new System.Drawing.Size(206, 225);
            this.PromptRegion.TabIndex = 0;
            // 
            // PassTbox
            // 
            this.PassTbox.Location = new System.Drawing.Point(82, 137);
            this.PassTbox.Name = "PassTbox";
            this.PassTbox.PasswordChar = '*';
            this.PassTbox.Size = new System.Drawing.Size(100, 22);
            this.PassTbox.TabIndex = 9;
            // 
            // UserTbox
            // 
            this.UserTbox.Location = new System.Drawing.Point(82, 112);
            this.UserTbox.Name = "UserTbox";
            this.UserTbox.Size = new System.Drawing.Size(100, 22);
            this.UserTbox.TabIndex = 8;
            // 
            // DBTbox
            // 
            this.DBTbox.Location = new System.Drawing.Point(82, 68);
            this.DBTbox.Name = "DBTbox";
            this.DBTbox.Size = new System.Drawing.Size(100, 22);
            this.DBTbox.TabIndex = 7;
            // 
            // PortTbox
            // 
            this.PortTbox.Location = new System.Drawing.Point(82, 38);
            this.PortTbox.Name = "PortTbox";
            this.PortTbox.Size = new System.Drawing.Size(100, 22);
            this.PortTbox.TabIndex = 6;
            // 
            // IPTbox
            // 
            this.IPTbox.Location = new System.Drawing.Point(82, 10);
            this.IPTbox.Name = "IPTbox";
            this.IPTbox.Size = new System.Drawing.Size(100, 22);
            this.IPTbox.TabIndex = 5;
            // 
            // PassDisplay
            // 
            this.PassDisplay.AutoSize = true;
            this.PassDisplay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PassDisplay.Location = new System.Drawing.Point(42, 137);
            this.PassDisplay.Name = "PassDisplay";
            this.PassDisplay.Size = new System.Drawing.Size(37, 17);
            this.PassDisplay.TabIndex = 4;
            this.PassDisplay.Text = "密碼:";
            // 
            // UserDisplay
            // 
            this.UserDisplay.AutoSize = true;
            this.UserDisplay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UserDisplay.Location = new System.Drawing.Point(3, 112);
            this.UserDisplay.Name = "UserDisplay";
            this.UserDisplay.Size = new System.Drawing.Size(76, 17);
            this.UserDisplay.TabIndex = 3;
            this.UserDisplay.Text = "使用者名稱:";
            // 
            // DBDisplay
            // 
            this.DBDisplay.AutoSize = true;
            this.DBDisplay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DBDisplay.Location = new System.Drawing.Point(3, 68);
            this.DBDisplay.Name = "DBDisplay";
            this.DBDisplay.Size = new System.Drawing.Size(76, 17);
            this.DBDisplay.TabIndex = 2;
            this.DBDisplay.Text = "資料庫名稱:";
            // 
            // PortDisplay
            // 
            this.PortDisplay.AutoSize = true;
            this.PortDisplay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PortDisplay.Location = new System.Drawing.Point(42, 38);
            this.PortDisplay.Name = "PortDisplay";
            this.PortDisplay.Size = new System.Drawing.Size(37, 17);
            this.PortDisplay.TabIndex = 1;
            this.PortDisplay.Text = "埠號:";
            // 
            // IPDisplay
            // 
            this.IPDisplay.AutoSize = true;
            this.IPDisplay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IPDisplay.Location = new System.Drawing.Point(3, 10);
            this.IPDisplay.Name = "IPDisplay";
            this.IPDisplay.Size = new System.Drawing.Size(76, 17);
            this.IPDisplay.TabIndex = 0;
            this.IPDisplay.Text = "伺服器位址:";
            // 
            // Terminal
            // 
            this.Terminal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Terminal.Controls.Add(this.ResponseConsole);
            this.Terminal.Controls.Add(this.Append);
            this.Terminal.Controls.Add(this.Clear);
            this.Terminal.Controls.Add(this.Submit);
            this.Terminal.Controls.Add(this.CommandEntry);
            this.Terminal.Controls.Add(this.MenuBar);
            this.Terminal.Location = new System.Drawing.Point(3, 421);
            this.Terminal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Terminal.Name = "Terminal";
            this.Terminal.Size = new System.Drawing.Size(623, 141);
            this.Terminal.TabIndex = 2;
            // 
            // ResponseConsole
            // 
            this.ResponseConsole.BackColor = System.Drawing.SystemColors.Control;
            this.ResponseConsole.Cursor = System.Windows.Forms.Cursors.No;
            this.ResponseConsole.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ResponseConsole.Location = new System.Drawing.Point(1, 47);
            this.ResponseConsole.Name = "ResponseConsole";
            this.ResponseConsole.ReadOnly = true;
            this.ResponseConsole.Size = new System.Drawing.Size(621, 91);
            this.ResponseConsole.TabIndex = 4;
            this.ResponseConsole.Text = "";
            // 
            // Append
            // 
            this.Append.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Append.Location = new System.Drawing.Point(366, 4);
            this.Append.Name = "Append";
            this.Append.Size = new System.Drawing.Size(80, 33);
            this.Append.TabIndex = 3;
            this.Append.Text = "加入程式列";
            this.Append.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Clear.Location = new System.Drawing.Point(538, 4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(80, 33);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "清除程式列";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Submit.Location = new System.Drawing.Point(452, 4);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(80, 33);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "加入並發送";
            this.Submit.UseVisualStyleBackColor = true;
            // 
            // CommandEntry
            // 
            this.CommandEntry.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CommandEntry.Location = new System.Drawing.Point(6, 4);
            this.CommandEntry.Name = "CommandEntry";
            this.CommandEntry.Size = new System.Drawing.Size(354, 35);
            this.CommandEntry.TabIndex = 0;
            // 
            // MenuBar
            // 
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(623, 24);
            this.MenuBar.TabIndex = 5;
            this.MenuBar.Text = "menuStrip1";
            // 
            // Credits
            // 
            this.Credits.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Credits.Controls.Add(this.Introduction);
            this.Credits.Controls.Add(this.BernieName);
            this.Credits.Controls.Add(this.CharlieName);
            this.Credits.Controls.Add(this.Bernie);
            this.Credits.Controls.Add(this.Charlie);
            this.Credits.Location = new System.Drawing.Point(630, 421);
            this.Credits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(214, 140);
            this.Credits.TabIndex = 3;
            // 
            // Introduction
            // 
            this.Introduction.AutoSize = true;
            this.Introduction.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Introduction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Introduction.Location = new System.Drawing.Point(39, 12);
            this.Introduction.Name = "Introduction";
            this.Introduction.Size = new System.Drawing.Size(142, 21);
            this.Introduction.TabIndex = 4;
            this.Introduction.Text = "此專案的協作者們:";
            // 
            // BernieName
            // 
            this.BernieName.AutoSize = true;
            this.BernieName.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BernieName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BernieName.Location = new System.Drawing.Point(120, 117);
            this.BernieName.Name = "BernieName";
            this.BernieName.Size = new System.Drawing.Size(89, 16);
            this.BernieName.TabIndex = 3;
            this.BernieName.Text = "顏榕嶙 (Bernie)";
            // 
            // CharlieName
            // 
            this.CharlieName.AutoSize = true;
            this.CharlieName.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CharlieName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CharlieName.Location = new System.Drawing.Point(31, 117);
            this.CharlieName.Name = "CharlieName";
            this.CharlieName.Size = new System.Drawing.Size(43, 16);
            this.CharlieName.TabIndex = 2;
            this.CharlieName.Text = "吳傢澂";
            // 
            // Bernie
            // 
            this.Bernie.BackColor = System.Drawing.Color.Transparent;
            this.Bernie.BackgroundImage = global::DB_GUI.Properties.Resources.Avatar_Be;
            this.Bernie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bernie.FlatAppearance.BorderSize = 0;
            this.Bernie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bernie.Location = new System.Drawing.Point(127, 36);
            this.Bernie.Name = "Bernie";
            this.Bernie.Size = new System.Drawing.Size(75, 75);
            this.Bernie.TabIndex = 1;
            this.Bernie.UseVisualStyleBackColor = false;
            this.Bernie.Click += new System.EventHandler(this.Bernie_Click);
            // 
            // Charlie
            // 
            this.Charlie.BackColor = System.Drawing.Color.Transparent;
            this.Charlie.BackgroundImage = global::DB_GUI.Properties.Resources.Avatar_wu;
            this.Charlie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Charlie.FlatAppearance.BorderSize = 0;
            this.Charlie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Charlie.Location = new System.Drawing.Point(14, 36);
            this.Charlie.Name = "Charlie";
            this.Charlie.Size = new System.Drawing.Size(75, 75);
            this.Charlie.TabIndex = 0;
            this.Charlie.UseVisualStyleBackColor = false;
            this.Charlie.Click += new System.EventHandler(this.Charlie_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Title.Controls.Add(this.Debug);
            this.Title.Controls.Add(this.label1);
            this.Title.Controls.Add(this.button1);
            this.Title.Controls.Add(this.Status);
            this.Title.Location = new System.Drawing.Point(-1, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(845, 87);
            this.Title.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(285, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wyrm 資料庫檢索系統";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::DB_GUI.Properties.Resources.Logo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(200, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 67);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Status.ForeColor = System.Drawing.Color.Maroon;
            this.Status.Location = new System.Drawing.Point(719, 65);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(122, 19);
            this.Status.TabIndex = 0;
            this.Status.Text = "連線狀態: 未連線";
            // 
            // Debug
            // 
            this.Debug.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Debug.Location = new System.Drawing.Point(778, 8);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(62, 38);
            this.Debug.TabIndex = 3;
            this.Debug.Text = "測試";
            this.Debug.UseVisualStyleBackColor = true;
            this.Debug.Click += new System.EventHandler(this.Debug_Click);
            // 
            // GUI_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DB_GUI.Properties.Resources.DB_Frontend_Concept;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.Terminal);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.Datagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.MenuBar;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GUI_Main";
            this.Text = "Volkswagen Database Query Application";
            this.Load += new System.EventHandler(this.GUI_Main_Load);
            this.Datagrid.ResumeLayout(false);
            this.Datagrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            this.Options.ResumeLayout(false);
            this.ExampleRegion.ResumeLayout(false);
            this.ExampleRegion.PerformLayout();
            this.PromptRegion.ResumeLayout(false);
            this.PromptRegion.PerformLayout();
            this.Terminal.ResumeLayout(false);
            this.Terminal.PerformLayout();
            this.Credits.ResumeLayout(false);
            this.Credits.PerformLayout();
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel Datagrid;
        private DataGridView MainGrid;
        private Panel Options;
        private Panel Terminal;
        private Panel Credits;
        private TextBox CommandEntry;
        private Button Clear;
        private Button Submit;
        private RichTextBox ResponseConsole;
        private Button Append;
        private Panel PromptRegion;
        private Label PortDisplay;
        private Label IPDisplay;
        private Button Disconnect;
        private Button Connect;
        private TextBox PassTbox;
        private TextBox UserTbox;
        private TextBox DBTbox;
        private TextBox PortTbox;
        private TextBox IPTbox;
        private Label PassDisplay;
        private Label UserDisplay;
        private Label DBDisplay;
        private Panel ExampleRegion;
        private ComboBox ExampleCbox;
        private Label ExampleDisplay;
        private Label NotConnected;
        private Button ExConfirm;
        private Panel Title;
        private Label Status;
        private Button Bernie;
        private Button Charlie;
        private Label Introduction;
        private Label BernieName;
        private Label CharlieName;
        private ToolTip GeneralDescription;
        private MenuStrip MenuBar;
        private Button button1;
        private Label label1;
        private Button Debug;
    }
}

