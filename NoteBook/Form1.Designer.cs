namespace NoteBook
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer üretilen kod

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.txtBaslik = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.lstNot = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                      | System.Windows.Forms.AnchorStyles.Left) 
                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 36);
            this.splitContainer1.Name = "splitContainer1";
            // left = editor, right = list
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(876, 612);
            this.splitContainer1.SplitterDistance = 560;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(11, 11);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(44, 15);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Başlık:";
            // 
            // txtBaslik
            // 
            this.txtBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                     | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaslik.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBaslik.Location = new System.Drawing.Point(14, 30);
            this.txtBaslik.Name = "txtBaslik";
            this.txtBaslik.Size = new System.Drawing.Size(524, 25);
            this.txtBaslik.TabIndex = 1;
            this.txtBaslik.TextChanged += new System.EventHandler(this.txtBaslik_TextChanged);
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                     | System.Windows.Forms.AnchorStyles.Left) 
                                     | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNote.Location = new System.Drawing.Point(14, 65);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(524, 472);
            this.txtNote.TabIndex = 2;
            this.txtNote.Text = "";
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.Controls.Add(this.btnKaydet);
            this.panelButtons.Controls.Add(this.btnEkle);
            this.panelButtons.Controls.Add(this.btnSil);
            this.panelButtons.Controls.Add(this.btnAra);
            this.panelButtons.Location = new System.Drawing.Point(14, 548);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(524, 48);
            this.panelButtons.TabIndex = 3;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnKaydet.Location = new System.Drawing.Point(0, 6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(96, 36);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEkle.Location = new System.Drawing.Point(110, 6);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(96, 36);
            this.btnEkle.TabIndex = 1;
            this.btnEkle.Text = "Yeni Not";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSil.Location = new System.Drawing.Point(220, 6);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(96, 36);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnAra
            // 
            this.btnAra.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAra.Location = new System.Drawing.Point(330, 6);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(96, 36);
            this.btnAra.TabIndex = 3;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // groupBoxList
            // 
            this.groupBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                         | System.Windows.Forms.AnchorStyles.Left) 
                                         | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxList.Controls.Add(this.lstNot);
            this.groupBoxList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxList.Location = new System.Drawing.Point(8, 8);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(292, 596);
            this.groupBoxList.TabIndex = 0;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Notlar";
            // 
            // lstNot
            // 
            this.lstNot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNot.FormattingEnabled = true;
            this.lstNot.ItemHeight = 16;
            this.lstNot.Location = new System.Drawing.Point(3, 19);
            this.lstNot.Name = "lstNot";
            this.lstNot.Size = new System.Drawing.Size(286, 574);
            this.lstNot.TabIndex = 0;
            this.lstNot.SelectedIndexChanged += new System.EventHandler(this.lstNot_SelectedIndexChanged);
            // 
            // Wire controls into splitContainer panels
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblBaslik);
            this.splitContainer1.Panel1.Controls.Add(this.txtBaslik);
            this.splitContainer1.Panel1.Controls.Add(this.txtNote);
            this.splitContainer1.Panel1.Controls.Add(this.panelButtons);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxList);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(900, 660);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Form1";
            this.Text = "Not Defteri";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.groupBoxList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.TextBox txtBaslik;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.ListBox lstNot;
    }
}
