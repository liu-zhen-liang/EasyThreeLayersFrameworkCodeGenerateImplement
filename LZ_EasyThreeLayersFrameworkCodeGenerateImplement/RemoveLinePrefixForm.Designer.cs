namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    partial class RemoveLinePrefixForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveLinePrefixForm));
            this.lvLineRemovePrefix = new System.Windows.Forms.ListView();
            this.chTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRemoveLinePrefix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvLineRemovePrefix
            // 
            this.lvLineRemovePrefix.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTableName,
            this.chRemoveLinePrefix});
            this.lvLineRemovePrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLineRemovePrefix.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvLineRemovePrefix.FullRowSelect = true;
            this.lvLineRemovePrefix.Location = new System.Drawing.Point(0, 0);
            this.lvLineRemovePrefix.Name = "lvLineRemovePrefix";
            this.lvLineRemovePrefix.Size = new System.Drawing.Size(519, 318);
            this.lvLineRemovePrefix.TabIndex = 1;
            this.lvLineRemovePrefix.UseCompatibleStateImageBehavior = false;
            this.lvLineRemovePrefix.View = System.Windows.Forms.View.Details;
            this.lvLineRemovePrefix.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvLineRemovePrefix_MouseDoubleClick);
            // 
            // chTableName
            // 
            this.chTableName.Text = "表名";
            this.chTableName.Width = 212;
            // 
            // chRemoveLinePrefix
            // 
            this.chRemoveLinePrefix.Text = "去除前缀";
            this.chRemoveLinePrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chRemoveLinePrefix.Width = 300;
            // 
            // RemoveLinePrefixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 318);
            this.Controls.Add(this.lvLineRemovePrefix);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoveLinePrefixForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "去除列前缀设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoveLinePrefixForm_FormClosing);
            this.Load += new System.EventHandler(this.RemoveLinePrefixForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLineRemovePrefix;
        private System.Windows.Forms.ColumnHeader chTableName;
        private System.Windows.Forms.ColumnHeader chRemoveLinePrefix;
    }
}