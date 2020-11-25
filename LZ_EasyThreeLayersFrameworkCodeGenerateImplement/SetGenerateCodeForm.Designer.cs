namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    partial class SetGenerateCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetGenerateCodeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDataBaseList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labServerName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSelectTableList = new System.Windows.Forms.ListBox();
            this.buttAllToNotSelectTable = new System.Windows.Forms.Button();
            this.buttSelectToNotSelectTable = new System.Windows.Forms.Button();
            this.buttSelectToSelectTable = new System.Windows.Forms.Button();
            this.buttAllToSelectTable = new System.Windows.Forms.Button();
            this.lbNotSelectTableList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbIsWeb = new System.Windows.Forms.CheckBox();
            this.buttSetRemoveLinePrefix = new System.Windows.Forms.Button();
            this.cbIgnoreBigOrSmall = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCreateTableHTML = new System.Windows.Forms.CheckBox();
            this.txtDeletePrefix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBllName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDalName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataBaseClassName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lvLineNote = new System.Windows.Forms.ListView();
            this.chLineName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLineNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lvTableNote = new System.Windows.Forms.ListView();
            this.chTableName01 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTableNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbSchedule = new System.Windows.Forms.ProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttSelectSavePath = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttBgeinCreateCode = new System.Windows.Forms.Button();
            this.labSchedule = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDataBaseList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labServerName);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(786, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据库";
            // 
            // cbDataBaseList
            // 
            this.cbDataBaseList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBaseList.FormattingEnabled = true;
            this.cbDataBaseList.Location = new System.Drawing.Point(570, 34);
            this.cbDataBaseList.Name = "cbDataBaseList";
            this.cbDataBaseList.Size = new System.Drawing.Size(177, 26);
            this.cbDataBaseList.TabIndex = 2;
            this.cbDataBaseList.SelectedIndexChanged += new System.EventHandler(this.cbDataBaseList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择数据库：";
            // 
            // labServerName
            // 
            this.labServerName.AutoSize = true;
            this.labServerName.Location = new System.Drawing.Point(20, 37);
            this.labServerName.Name = "labServerName";
            this.labServerName.Size = new System.Drawing.Size(123, 19);
            this.labServerName.TabIndex = 0;
            this.labServerName.Text = "当前服务器：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSelectTableList);
            this.groupBox2.Controls.Add(this.buttAllToNotSelectTable);
            this.groupBox2.Controls.Add(this.buttSelectToNotSelectTable);
            this.groupBox2.Controls.Add(this.buttSelectToSelectTable);
            this.groupBox2.Controls.Add(this.buttAllToSelectTable);
            this.groupBox2.Controls.Add(this.lbNotSelectTableList);
            this.groupBox2.Location = new System.Drawing.Point(15, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择表";
            // 
            // lbSelectTableList
            // 
            this.lbSelectTableList.FormattingEnabled = true;
            this.lbSelectTableList.ItemHeight = 18;
            this.lbSelectTableList.Location = new System.Drawing.Point(476, 26);
            this.lbSelectTableList.Name = "lbSelectTableList";
            this.lbSelectTableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSelectTableList.Size = new System.Drawing.Size(291, 166);
            this.lbSelectTableList.TabIndex = 5;
            // 
            // buttAllToNotSelectTable
            // 
            this.buttAllToNotSelectTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttAllToNotSelectTable.Location = new System.Drawing.Point(354, 156);
            this.buttAllToNotSelectTable.Name = "buttAllToNotSelectTable";
            this.buttAllToNotSelectTable.Size = new System.Drawing.Size(78, 38);
            this.buttAllToNotSelectTable.TabIndex = 4;
            this.buttAllToNotSelectTable.Text = "<<";
            this.buttAllToNotSelectTable.UseVisualStyleBackColor = true;
            this.buttAllToNotSelectTable.Click += new System.EventHandler(this.buttAllToNotSelectTable_Click);
            // 
            // buttSelectToNotSelectTable
            // 
            this.buttSelectToNotSelectTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttSelectToNotSelectTable.Location = new System.Drawing.Point(354, 112);
            this.buttSelectToNotSelectTable.Name = "buttSelectToNotSelectTable";
            this.buttSelectToNotSelectTable.Size = new System.Drawing.Size(78, 38);
            this.buttSelectToNotSelectTable.TabIndex = 3;
            this.buttSelectToNotSelectTable.Text = "<";
            this.buttSelectToNotSelectTable.UseVisualStyleBackColor = true;
            this.buttSelectToNotSelectTable.Click += new System.EventHandler(this.buttSelectToNotSelectTable_Click);
            // 
            // buttSelectToSelectTable
            // 
            this.buttSelectToSelectTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttSelectToSelectTable.Location = new System.Drawing.Point(354, 68);
            this.buttSelectToSelectTable.Name = "buttSelectToSelectTable";
            this.buttSelectToSelectTable.Size = new System.Drawing.Size(78, 38);
            this.buttSelectToSelectTable.TabIndex = 2;
            this.buttSelectToSelectTable.Text = ">";
            this.buttSelectToSelectTable.UseVisualStyleBackColor = true;
            this.buttSelectToSelectTable.Click += new System.EventHandler(this.buttSelectToSelectTable_Click);
            // 
            // buttAllToSelectTable
            // 
            this.buttAllToSelectTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttAllToSelectTable.Location = new System.Drawing.Point(354, 24);
            this.buttAllToSelectTable.Name = "buttAllToSelectTable";
            this.buttAllToSelectTable.Size = new System.Drawing.Size(78, 38);
            this.buttAllToSelectTable.TabIndex = 1;
            this.buttAllToSelectTable.Text = ">>";
            this.buttAllToSelectTable.UseVisualStyleBackColor = true;
            this.buttAllToSelectTable.Click += new System.EventHandler(this.buttAllToSelectTable_Click);
            // 
            // lbNotSelectTableList
            // 
            this.lbNotSelectTableList.FormattingEnabled = true;
            this.lbNotSelectTableList.ItemHeight = 18;
            this.lbNotSelectTableList.Location = new System.Drawing.Point(21, 26);
            this.lbNotSelectTableList.Name = "lbNotSelectTableList";
            this.lbNotSelectTableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbNotSelectTableList.Size = new System.Drawing.Size(291, 166);
            this.lbNotSelectTableList.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbIsWeb);
            this.groupBox3.Controls.Add(this.buttSetRemoveLinePrefix);
            this.groupBox3.Controls.Add(this.cbIgnoreBigOrSmall);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cbCreateTableHTML);
            this.groupBox3.Controls.Add(this.txtDeletePrefix);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.txtDataBaseClassName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtNamespace);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(15, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(786, 203);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生成代码名称设定";
            // 
            // cbIsWeb
            // 
            this.cbIsWeb.AutoSize = true;
            this.cbIsWeb.Checked = true;
            this.cbIsWeb.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbIsWeb.Location = new System.Drawing.Point(25, 137);
            this.cbIsWeb.Name = "cbIsWeb";
            this.cbIsWeb.Size = new System.Drawing.Size(529, 23);
            this.cbIsWeb.TabIndex = 12;
            this.cbIsWeb.Text = "生成的项目是否为Web项目？(如果是就会生成Web配置文件)";
            this.cbIsWeb.UseVisualStyleBackColor = true;
            // 
            // buttSetRemoveLinePrefix
            // 
            this.buttSetRemoveLinePrefix.Location = new System.Drawing.Point(253, 161);
            this.buttSetRemoveLinePrefix.Name = "buttSetRemoveLinePrefix";
            this.buttSetRemoveLinePrefix.Size = new System.Drawing.Size(287, 32);
            this.buttSetRemoveLinePrefix.TabIndex = 11;
            this.buttSetRemoveLinePrefix.Text = "设置去掉列前缀";
            this.buttSetRemoveLinePrefix.UseVisualStyleBackColor = true;
            this.buttSetRemoveLinePrefix.Click += new System.EventHandler(this.buttSetRemoveLinePrefix_Click);
            // 
            // cbIgnoreBigOrSmall
            // 
            this.cbIgnoreBigOrSmall.AutoSize = true;
            this.cbIgnoreBigOrSmall.Checked = true;
            this.cbIgnoreBigOrSmall.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbIgnoreBigOrSmall.Location = new System.Drawing.Point(25, 109);
            this.cbIgnoreBigOrSmall.Name = "cbIgnoreBigOrSmall";
            this.cbIgnoreBigOrSmall.Size = new System.Drawing.Size(525, 23);
            this.cbIgnoreBigOrSmall.TabIndex = 10;
            this.cbIgnoreBigOrSmall.Text = "表名直接变为类名后，去掉表名前缀是否需要忽略大小写？";
            this.cbIgnoreBigOrSmall.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "(空不变)";
            // 
            // cbCreateTableHTML
            // 
            this.cbCreateTableHTML.AutoSize = true;
            this.cbCreateTableHTML.Location = new System.Drawing.Point(25, 167);
            this.cbCreateTableHTML.Name = "cbCreateTableHTML";
            this.cbCreateTableHTML.Size = new System.Drawing.Size(222, 23);
            this.cbCreateTableHTML.TabIndex = 3;
            this.cbCreateTableHTML.Text = "生成表结构图(网页版)";
            this.cbCreateTableHTML.UseVisualStyleBackColor = true;
            // 
            // txtDeletePrefix
            // 
            this.txtDeletePrefix.Location = new System.Drawing.Point(340, 70);
            this.txtDeletePrefix.Name = "txtDeletePrefix";
            this.txtDeletePrefix.Size = new System.Drawing.Size(123, 28);
            this.txtDeletePrefix.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(332, 19);
            this.label9.TabIndex = 7;
            this.label9.Text = "表名直接变为类名后，去掉表名前缀：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtModelName);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtBllName);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtDalName);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(550, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 181);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "表名后缀（空不加）";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(117, 132);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(103, 28);
            this.txtModelName.TabIndex = 9;
            this.txtModelName.Text = "Mod";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "  数据模型：";
            // 
            // txtBllName
            // 
            this.txtBllName.Location = new System.Drawing.Point(117, 86);
            this.txtBllName.Name = "txtBllName";
            this.txtBllName.Size = new System.Drawing.Size(103, 28);
            this.txtBllName.TabIndex = 7;
            this.txtBllName.Text = "Bll";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "业务逻辑层：";
            // 
            // txtDalName
            // 
            this.txtDalName.Location = new System.Drawing.Point(117, 40);
            this.txtDalName.Name = "txtDalName";
            this.txtDalName.Size = new System.Drawing.Size(103, 28);
            this.txtDalName.TabIndex = 5;
            this.txtDalName.Text = "Dal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据访问层：";
            // 
            // txtDataBaseClassName
            // 
            this.txtDataBaseClassName.Location = new System.Drawing.Point(416, 32);
            this.txtDataBaseClassName.Name = "txtDataBaseClassName";
            this.txtDataBaseClassName.Size = new System.Drawing.Size(124, 28);
            this.txtDataBaseClassName.TabIndex = 3;
            this.txtDataBaseClassName.Text = "SqlDataBase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据访问类名称：";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(116, 31);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(144, 28);
            this.txtNamespace.TabIndex = 1;
            this.txtNamespace.Text = "Maticsoft";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "命名空间：";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Location = new System.Drawing.Point(15, 519);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(786, 125);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "生成代码功能设定";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.lvLineNote);
            this.groupBox8.Location = new System.Drawing.Point(392, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(388, 100);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "设置表的列注释（双击修改注释）";
            // 
            // lvLineNote
            // 
            this.lvLineNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLineNote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLineName,
            this.chLineNote});
            this.lvLineNote.FullRowSelect = true;
            this.lvLineNote.HideSelection = false;
            this.lvLineNote.Location = new System.Drawing.Point(3, 24);
            this.lvLineNote.Name = "lvLineNote";
            this.lvLineNote.Size = new System.Drawing.Size(382, 73);
            this.lvLineNote.TabIndex = 0;
            this.lvLineNote.UseCompatibleStateImageBehavior = false;
            this.lvLineNote.View = System.Windows.Forms.View.Details;
            this.lvLineNote.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDoubleClick);
            // 
            // chLineName
            // 
            this.chLineName.Text = "列名称";
            this.chLineName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chLineName.Width = 156;
            // 
            // chLineNote
            // 
            this.chLineNote.Text = "列注释";
            this.chLineNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chLineNote.Width = 220;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.lvTableNote);
            this.groupBox7.Location = new System.Drawing.Point(8, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(378, 100);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "设置表注释（双击修改注释）";
            // 
            // lvTableNote
            // 
            this.lvTableNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTableNote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTableName01,
            this.chTableNote});
            this.lvTableNote.FullRowSelect = true;
            this.lvTableNote.HideSelection = false;
            this.lvTableNote.Location = new System.Drawing.Point(3, 24);
            this.lvTableNote.Name = "lvTableNote";
            this.lvTableNote.Size = new System.Drawing.Size(372, 73);
            this.lvTableNote.TabIndex = 1;
            this.lvTableNote.UseCompatibleStateImageBehavior = false;
            this.lvTableNote.View = System.Windows.Forms.View.Details;
            this.lvTableNote.SelectedIndexChanged += new System.EventHandler(this.lvTableNote_SelectedIndexChanged);
            this.lvTableNote.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDoubleClick);
            // 
            // chTableName01
            // 
            this.chTableName01.Text = "表名称";
            this.chTableName01.Width = 128;
            // 
            // chTableNote
            // 
            this.chTableNote.Text = "表注释";
            this.chTableNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTableNote.Width = 240;
            // 
            // pbSchedule
            // 
            this.pbSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSchedule.Location = new System.Drawing.Point(13, 718);
            this.pbSchedule.Name = "pbSchedule";
            this.pbSchedule.Size = new System.Drawing.Size(614, 23);
            this.pbSchedule.TabIndex = 4;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.buttSelectSavePath);
            this.groupBox6.Controls.Add(this.txtSavePath);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(15, 650);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(786, 60);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "保存位置";
            // 
            // buttSelectSavePath
            // 
            this.buttSelectSavePath.Location = new System.Drawing.Point(684, 21);
            this.buttSelectSavePath.Name = "buttSelectSavePath";
            this.buttSelectSavePath.Size = new System.Drawing.Size(97, 31);
            this.buttSelectSavePath.TabIndex = 2;
            this.buttSelectSavePath.Text = "选择...";
            this.buttSelectSavePath.UseVisualStyleBackColor = true;
            this.buttSelectSavePath.Click += new System.EventHandler(this.buttSelectSavePath_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(127, 23);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(540, 28);
            this.txtSavePath.TabIndex = 1;
            this.txtSavePath.Text = "C:\\Users\\Administrator\\Desktop\\LZ简单三层架构代码生成器生成代码";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "输出目录：";
            // 
            // buttBgeinCreateCode
            // 
            this.buttBgeinCreateCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttBgeinCreateCode.Location = new System.Drawing.Point(699, 715);
            this.buttBgeinCreateCode.Name = "buttBgeinCreateCode";
            this.buttBgeinCreateCode.Size = new System.Drawing.Size(97, 31);
            this.buttBgeinCreateCode.TabIndex = 6;
            this.buttBgeinCreateCode.Text = "生成";
            this.buttBgeinCreateCode.UseVisualStyleBackColor = true;
            this.buttBgeinCreateCode.Click += new System.EventHandler(this.buttBgeinCreateCode_Click);
            // 
            // labSchedule
            // 
            this.labSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labSchedule.AutoSize = true;
            this.labSchedule.Location = new System.Drawing.Point(629, 721);
            this.labSchedule.Name = "labSchedule";
            this.labSchedule.Size = new System.Drawing.Size(69, 19);
            this.labSchedule.TabIndex = 7;
            this.labSchedule.Text = "100.0%";
            // 
            // SetGenerateCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(814, 753);
            this.Controls.Add(this.buttBgeinCreateCode);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.pbSchedule);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labSchedule);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SetGenerateCodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LZ - 代码生成设置界面";
            this.Load += new System.EventHandler(this.SetGenerateCodeForm_Load);
            this.SizeChanged += new System.EventHandler(this.SetGenerateCodeForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbDataBaseList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labServerName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbSelectTableList;
        private System.Windows.Forms.Button buttAllToNotSelectTable;
        private System.Windows.Forms.Button buttSelectToNotSelectTable;
        private System.Windows.Forms.Button buttSelectToSelectTable;
        private System.Windows.Forms.Button buttAllToSelectTable;
        private System.Windows.Forms.ListBox lbNotSelectTableList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbIgnoreBigOrSmall;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDeletePrefix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBllName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDalName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataBaseClassName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cbCreateTableHTML;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView lvLineNote;
        private System.Windows.Forms.ColumnHeader chLineName;
        private System.Windows.Forms.ColumnHeader chLineNote;
        private System.Windows.Forms.ProgressBar pbSchedule;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttSelectSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttBgeinCreateCode;
        private System.Windows.Forms.Label labSchedule;
        private System.Windows.Forms.ListView lvTableNote;
        private System.Windows.Forms.ColumnHeader chTableName01;
        private System.Windows.Forms.ColumnHeader chTableNote;
        private System.Windows.Forms.Button buttSetRemoveLinePrefix;
        private System.Windows.Forms.CheckBox cbIsWeb;
    }
}