namespace VizsgaForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            lblDebugs = new Label();
            label5 = new Label();
            lblSorokSzama = new Label();
            lblErrors = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            btnExport = new Button();
            btnReset = new Button();
            btnSearch = new Button();
            txtSearchValue = new TextBox();
            label7 = new Label();
            label6 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(855, 308);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataSourceChanged += dataGridView1_DataSourceChanged;
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 326);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(732, 124);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 466);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(732, 124);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 341);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 2;
            label1.Text = "Message:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 459);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Exception:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDebugs);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblSorokSzama);
            groupBox1.Controls.Add(lblErrors);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(887, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 242);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Statisztika";
            // 
            // lblDebugs
            // 
            lblDebugs.AutoSize = true;
            lblDebugs.Location = new Point(74, 109);
            lblDebugs.Name = "lblDebugs";
            lblDebugs.Size = new Size(38, 15);
            lblDebugs.TabIndex = 0;
            lblDebugs.Text = "label3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 109);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 0;
            label5.Text = "Debugok:";
            // 
            // lblSorokSzama
            // 
            lblSorokSzama.AutoSize = true;
            lblSorokSzama.Location = new Point(74, 37);
            lblSorokSzama.Name = "lblSorokSzama";
            lblSorokSzama.Size = new Size(38, 15);
            lblSorokSzama.TabIndex = 0;
            lblSorokSzama.Text = "label3";
            // 
            // lblErrors
            // 
            lblErrors.AutoSize = true;
            lblErrors.Location = new Point(74, 71);
            lblErrors.Name = "lblErrors";
            lblErrors.Size = new Size(38, 15);
            lblErrors.TabIndex = 0;
            lblErrors.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 71);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 0;
            label4.Text = "Errorok:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 37);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 0;
            label3.Text = "Összes:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnExport);
            groupBox2.Controls.Add(btnReset);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Controls.Add(txtSearchValue);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Location = new Point(887, 276);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 174);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Keresés";
            // 
            // btnExport
            // 
            btnExport.Enabled = false;
            btnExport.Location = new Point(13, 133);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(181, 23);
            btnExport.TabIndex = 2;
            btnExport.Text = "Mentés másként";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(119, 104);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 2;
            btnReset.Text = "Visszaállít";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(13, 104);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Keres";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchValue
            // 
            txtSearchValue.Location = new Point(74, 62);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.Size = new Size(120, 23);
            txtSearchValue.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 65);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 0;
            label7.Text = "Érték:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 36);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 0;
            label6.Text = "Mező:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(73, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 602);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label lblDebugs;
        private Label label5;
        private Label lblSorokSzama;
        private Label lblErrors;
        private Label label4;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox txtSearchValue;
        private Label label7;
        private Label label6;
        private ComboBox comboBox1;
        private Button btnExport;
        private Button btnReset;
        private Button btnSearch;
    }
}
