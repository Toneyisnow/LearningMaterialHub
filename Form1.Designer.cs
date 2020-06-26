namespace LearningMaterialHub
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRequestDigest = new System.Windows.Forms.TextBox();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExcelFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenExcel = new System.Windows.Forms.Button();
            this.txtTraceLog = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "requestDigest:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "cookie:";
            // 
            // txtRequestDigest
            // 
            this.txtRequestDigest.Location = new System.Drawing.Point(107, 44);
            this.txtRequestDigest.Name = "txtRequestDigest";
            this.txtRequestDigest.Size = new System.Drawing.Size(663, 21);
            this.txtRequestDigest.TabIndex = 2;
            // 
            // txtCookie
            // 
            this.txtCookie.Location = new System.Drawing.Point(107, 79);
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(663, 21);
            this.txtCookie.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Excel:";
            // 
            // txtExcelFilePath
            // 
            this.txtExcelFilePath.Location = new System.Drawing.Point(107, 116);
            this.txtExcelFilePath.Name = "txtExcelFilePath";
            this.txtExcelFilePath.Size = new System.Drawing.Size(597, 21);
            this.txtExcelFilePath.TabIndex = 5;
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.Location = new System.Drawing.Point(722, 114);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(48, 23);
            this.btnOpenExcel.TabIndex = 6;
            this.btnOpenExcel.Text = "...";
            this.btnOpenExcel.UseVisualStyleBackColor = true;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // txtTraceLog
            // 
            this.txtTraceLog.Location = new System.Drawing.Point(31, 195);
            this.txtTraceLog.Multiline = true;
            this.txtTraceLog.Name = "txtTraceLog";
            this.txtTraceLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTraceLog.Size = new System.Drawing.Size(739, 228);
            this.txtTraceLog.TabIndex = 7;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(610, 159);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(160, 23);
            this.btnExecute.TabIndex = 8;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtTraceLog);
            this.Controls.Add(this.btnOpenExcel);
            this.Controls.Add(this.txtExcelFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.txtRequestDigest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Learning Material Sharing Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRequestDigest;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExcelFilePath;
        private System.Windows.Forms.Button btnOpenExcel;
        private System.Windows.Forms.TextBox txtTraceLog;
        private System.Windows.Forms.Button btnExecute;
    }
}

