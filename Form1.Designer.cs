using System;

namespace CsharpInterface
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btCheck = new System.Windows.Forms.Button();
            this.progressBarMeasure = new System.Windows.Forms.ProgressBar();
            this.txt_SVol = new System.Windows.Forms.TextBox();
            this.txt_EVol = new System.Windows.Forms.TextBox();
            this.txt_Repeat = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.txt_Step = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(499, 2);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1550, 1030);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 5);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(195, 5);
            this.btConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(120, 46);
            this.btConnect.TabIndex = 2;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(371, 5);
            this.btExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(120, 46);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(195, 105);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(120, 46);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(371, 105);
            this.btPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(120, 46);
            this.btPause.TabIndex = 7;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(371, 55);
            this.btClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(120, 46);
            this.btClear.TabIndex = 8;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 4800;
            this.serialPort1.DtrEnable = true;
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 217);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(479, 815);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Potential (mV)";
            this.columnHeader1.Width = 163;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current (mA)";
            this.columnHeader2.Width = 163;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(321, 5);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(44, 45);
            this.progressBar1.TabIndex = 10;
            // 
            // btCheck
            // 
            this.btCheck.Location = new System.Drawing.Point(195, 55);
            this.btCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(120, 47);
            this.btCheck.TabIndex = 11;
            this.btCheck.Text = "Start";
            this.btCheck.UseVisualStyleBackColor = true;
            this.btCheck.Click += new System.EventHandler(this.btRun_Click);
            // 
            // progressBarMeasure
            // 
            this.progressBarMeasure.Location = new System.Drawing.Point(12, 190);
            this.progressBarMeasure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarMeasure.Name = "progressBarMeasure";
            this.progressBarMeasure.Size = new System.Drawing.Size(479, 23);
            this.progressBarMeasure.Step = 1;
            this.progressBarMeasure.TabIndex = 12;
            // 
            // txt_SVol
            // 
            this.txt_SVol.Location = new System.Drawing.Point(68, 75);
            this.txt_SVol.Name = "txt_SVol";
            this.txt_SVol.Size = new System.Drawing.Size(120, 22);
            this.txt_SVol.TabIndex = 13;
            this.txt_SVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_SVol.Click += new System.EventHandler(this.txt_SVol_TextChanged);
            this.txt_SVol.TextChanged += new System.EventHandler(this.txt_SVol_TextChanged);
            // 
            // txt_EVol
            // 
            this.txt_EVol.Location = new System.Drawing.Point(68, 100);
            this.txt_EVol.Name = "txt_EVol";
            this.txt_EVol.Size = new System.Drawing.Size(120, 22);
            this.txt_EVol.TabIndex = 14;
            this.txt_EVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_EVol.Click += new System.EventHandler(this.txt_EVol_TextChanged);
            this.txt_EVol.TextChanged += new System.EventHandler(this.txt_EVol_TextChanged);
            // 
            // txt_Repeat
            // 
            this.txt_Repeat.Location = new System.Drawing.Point(68, 150);
            this.txt_Repeat.Name = "txt_Repeat";
            this.txt_Repeat.Size = new System.Drawing.Size(120, 22);
            this.txt_Repeat.TabIndex = 14;
            this.txt_Repeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Repeat.Click += new System.EventHandler(this.txt_Repeat_TextChanged);
            this.txt_Repeat.TextChanged += new System.EventHandler(this.txt_Repeat_TextChanged);
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(12, 33);
            this.btRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(120, 25);
            this.btRun.TabIndex = 6;
            this.btRun.Text = "Check";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // txt_Step
            // 
            this.txt_Step.Location = new System.Drawing.Point(68, 125);
            this.txt_Step.Name = "txt_Step";
            this.txt_Step.Size = new System.Drawing.Size(120, 22);
            this.txt_Step.TabIndex = 15;
            this.txt_Step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Step.Click += new System.EventHandler(this.txt_Step_TextChanged);
            this.txt_Step.TextChanged += new System.EventHandler(this.txt_Step_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 22);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "SVol";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 150);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(50, 22);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Times";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 125);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(50, 22);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "Step";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 22);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = "EVol";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_Step);
            this.Controls.Add(this.txt_Repeat);
            this.Controls.Add(this.txt_EVol);
            this.Controls.Add(this.txt_SVol);
            this.Controls.Add(this.progressBarMeasure);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Research and development of cyclic voltammetry measuring system for biomedical te" +
    "sting";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btClear;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.ProgressBar progressBarMeasure;
        private System.Windows.Forms.TextBox txt_SVol;
        private System.Windows.Forms.TextBox txt_EVol;
        private System.Windows.Forms.TextBox txt_Repeat;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.TextBox txt_Step;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
    }
}
