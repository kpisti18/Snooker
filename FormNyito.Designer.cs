namespace Snooker
{
    partial class FormNyito
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
            this.dataGridViewVersenyzo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownNyeremeny = new System.Windows.Forms.NumericUpDown();
            this.cbOrszag = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHelyezes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNev = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersenyzo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNyeremeny)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVersenyzo
            // 
            this.dataGridViewVersenyzo.AllowUserToAddRows = false;
            this.dataGridViewVersenyzo.AllowUserToDeleteRows = false;
            this.dataGridViewVersenyzo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVersenyzo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewVersenyzo.Location = new System.Drawing.Point(0, 178);
            this.dataGridViewVersenyzo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewVersenyzo.Name = "dataGridViewVersenyzo";
            this.dataGridViewVersenyzo.ReadOnly = true;
            this.dataGridViewVersenyzo.Size = new System.Drawing.Size(1200, 514);
            this.dataGridViewVersenyzo.TabIndex = 0;
            this.dataGridViewVersenyzo.SelectionChanged += new System.EventHandler(this.dataGridViewVersenyzo_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownNyeremeny);
            this.groupBox1.Controls.Add(this.cbOrszag);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbHelyezes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNev);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versenyző adatai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(760, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nyeremény";
            // 
            // numericUpDownNyeremeny
            // 
            this.numericUpDownNyeremeny.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownNyeremeny.Location = new System.Drawing.Point(764, 94);
            this.numericUpDownNyeremeny.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDownNyeremeny.Name = "numericUpDownNyeremeny";
            this.numericUpDownNyeremeny.Size = new System.Drawing.Size(173, 26);
            this.numericUpDownNyeremeny.TabIndex = 7;
            this.numericUpDownNyeremeny.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNyeremeny.ThousandsSeparator = true;
            // 
            // cbOrszag
            // 
            this.cbOrszag.FormattingEnabled = true;
            this.cbOrszag.Items.AddRange(new object[] {
            "Anglia\t",
            "Ausztrália\t",
            "Belgium\t",
            "Ciprus\t",
            "Észak-Írország\t",
            "Hong Kong\t",
            "Irán\t",
            "Írország\t",
            "Kína\t",
            "Lengyelország\t",
            "Malajzia\t",
            "Norvégia\t",
            "Skócia\t",
            "Svájc\t",
            "Thaiföld\t",
            "Wales"});
            this.cbOrszag.Location = new System.Drawing.Point(501, 94);
            this.cbOrszag.Name = "cbOrszag";
            this.cbOrszag.Size = new System.Drawing.Size(173, 28);
            this.cbOrszag.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ország";
            // 
            // tbHelyezes
            // 
            this.tbHelyezes.Location = new System.Drawing.Point(12, 94);
            this.tbHelyezes.Name = "tbHelyezes";
            this.tbHelyezes.ReadOnly = true;
            this.tbHelyezes.Size = new System.Drawing.Size(173, 26);
            this.tbHelyezes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Helyezés";
            // 
            // tbNev
            // 
            this.tbNev.Location = new System.Drawing.Point(261, 94);
            this.tbNev.Name = "tbNev";
            this.tbNev.ReadOnly = true;
            this.tbNev.Size = new System.Drawing.Size(173, 26);
            this.tbNev.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Név";
            // 
            // FormNyito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewVersenyzo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormNyito";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormNyito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersenyzo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNyeremeny)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVersenyzo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbOrszag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHelyezes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownNyeremeny;
    }
}

