namespace QCChangeRevision
{
    partial class FormGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneral));
            this.btnPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.groupMembrete = new System.Windows.Forms.GroupBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.dateTimeFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProjectNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIssuedFor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRevisionOTC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDrawingCAD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditData = new System.Windows.Forms.Button();
            this.txtDetailEnginer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.btnQuitarText = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtQuitar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btn_Purge = new System.Windows.Forms.Button();
            this.groupMembrete.SuspendLayout();
            this.groupFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPath.Location = new System.Drawing.Point(35, 506);
            this.btnPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(259, 52);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "Seleccionar Archivos";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Revision";
            // 
            // txtRevision
            // 
            this.txtRevision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtRevision.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevision.Location = new System.Drawing.Point(176, 59);
            this.txtRevision.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(136, 30);
            this.txtRevision.TabIndex = 5;
            this.txtRevision.Text = "0";
            // 
            // groupMembrete
            // 
            this.groupMembrete.Controls.Add(this.chkDate);
            this.groupMembrete.Controls.Add(this.dateTimeFecha);
            this.groupMembrete.Controls.Add(this.label8);
            this.groupMembrete.Controls.Add(this.txtProjectNumber);
            this.groupMembrete.Controls.Add(this.label7);
            this.groupMembrete.Controls.Add(this.txtIssuedFor);
            this.groupMembrete.Controls.Add(this.label6);
            this.groupMembrete.Controls.Add(this.txtRevisionOTC);
            this.groupMembrete.Controls.Add(this.label5);
            this.groupMembrete.Controls.Add(this.txtDrawingCAD);
            this.groupMembrete.Controls.Add(this.label4);
            this.groupMembrete.Controls.Add(this.btnEditData);
            this.groupMembrete.Controls.Add(this.txtDetailEnginer);
            this.groupMembrete.Controls.Add(this.label3);
            this.groupMembrete.Location = new System.Drawing.Point(35, 31);
            this.groupMembrete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupMembrete.Name = "groupMembrete";
            this.groupMembrete.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupMembrete.Size = new System.Drawing.Size(396, 439);
            this.groupMembrete.TabIndex = 8;
            this.groupMembrete.TabStop = false;
            this.groupMembrete.Text = "Datos Membrete";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(125, 314);
            this.chkDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(22, 21);
            this.chkDate.TabIndex = 24;
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // dateTimeFecha
            // 
            this.dateTimeFecha.CalendarFont = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFecha.Location = new System.Drawing.Point(176, 303);
            this.dateTimeFecha.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimeFecha.Name = "dateTimeFecha";
            this.dateTimeFecha.Size = new System.Drawing.Size(195, 29);
            this.dateTimeFecha.TabIndex = 23;
            this.dateTimeFecha.ValueChanged += new System.EventHandler(this.dateTimeFecha_ValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 308);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Fecha";
            // 
            // txtProjectNumber
            // 
            this.txtProjectNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtProjectNumber.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectNumber.Location = new System.Drawing.Point(176, 251);
            this.txtProjectNumber.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtProjectNumber.Name = "txtProjectNumber";
            this.txtProjectNumber.Size = new System.Drawing.Size(195, 30);
            this.txtProjectNumber.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 257);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Proyecto N°";
            // 
            // txtIssuedFor
            // 
            this.txtIssuedFor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIssuedFor.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssuedFor.Location = new System.Drawing.Point(176, 199);
            this.txtIssuedFor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtIssuedFor.Name = "txtIssuedFor";
            this.txtIssuedFor.Size = new System.Drawing.Size(195, 30);
            this.txtIssuedFor.TabIndex = 18;
            this.txtIssuedFor.Text = "CONSTRUCCION";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Emitido Para";
            // 
            // txtRevisionOTC
            // 
            this.txtRevisionOTC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtRevisionOTC.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevisionOTC.Location = new System.Drawing.Point(176, 148);
            this.txtRevisionOTC.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtRevisionOTC.Name = "txtRevisionOTC";
            this.txtRevisionOTC.Size = new System.Drawing.Size(195, 30);
            this.txtRevisionOTC.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Revision OTC";
            // 
            // txtDrawingCAD
            // 
            this.txtDrawingCAD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDrawingCAD.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrawingCAD.Location = new System.Drawing.Point(176, 96);
            this.txtDrawingCAD.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDrawingCAD.Name = "txtDrawingCAD";
            this.txtDrawingCAD.Size = new System.Drawing.Size(195, 30);
            this.txtDrawingCAD.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dibujo CAD";
            // 
            // btnEditData
            // 
            this.btnEditData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditData.Location = new System.Drawing.Point(35, 366);
            this.btnEditData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(339, 52);
            this.btnEditData.TabIndex = 13;
            this.btnEditData.Text = "Modificar Datos";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // txtDetailEnginer
            // 
            this.txtDetailEnginer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDetailEnginer.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailEnginer.Location = new System.Drawing.Point(176, 44);
            this.txtDetailEnginer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDetailEnginer.Name = "txtDetailEnginer";
            this.txtDetailEnginer.Size = new System.Drawing.Size(195, 30);
            this.txtDetailEnginer.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ing. Detalle";
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.btnQuitarText);
            this.groupFile.Controls.Add(this.btnModify);
            this.groupFile.Controls.Add(this.txtQuitar);
            this.groupFile.Controls.Add(this.label2);
            this.groupFile.Controls.Add(this.txtRevision);
            this.groupFile.Controls.Add(this.label1);
            this.groupFile.Location = new System.Drawing.Point(462, 31);
            this.groupFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupFile.Name = "groupFile";
            this.groupFile.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupFile.Size = new System.Drawing.Size(345, 355);
            this.groupFile.TabIndex = 9;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "Datos Archivo";
            // 
            // btnQuitarText
            // 
            this.btnQuitarText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuitarText.Location = new System.Drawing.Point(31, 263);
            this.btnQuitarText.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnQuitarText.Name = "btnQuitarText";
            this.btnQuitarText.Size = new System.Drawing.Size(284, 52);
            this.btnQuitarText.TabIndex = 13;
            this.btnQuitarText.Text = "Quitar Texto";
            this.btnQuitarText.UseVisualStyleBackColor = true;
            this.btnQuitarText.Click += new System.EventHandler(this.btnQuitarText_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModify.Location = new System.Drawing.Point(31, 189);
            this.btnModify.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(284, 52);
            this.btnModify.TabIndex = 12;
            this.btnModify.Text = "Modificar Revisión";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtQuitar
            // 
            this.txtQuitar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuitar.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuitar.Location = new System.Drawing.Point(176, 122);
            this.txtQuitar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtQuitar.Name = "txtQuitar";
            this.txtQuitar.Size = new System.Drawing.Size(136, 30);
            this.txtQuitar.TabIndex = 11;
            this.txtQuitar.Text = "-Layout1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Texto a Quitar";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(638, 506);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(169, 52);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_Purge
            // 
            this.btn_Purge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Purge.Location = new System.Drawing.Point(490, 398);
            this.btn_Purge.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Purge.Name = "btn_Purge";
            this.btn_Purge.Size = new System.Drawing.Size(284, 52);
            this.btn_Purge.TabIndex = 14;
            this.btn_Purge.Text = "Purgar Archivos";
            this.btn_Purge.UseVisualStyleBackColor = true;
            this.btn_Purge.Click += new System.EventHandler(this.btn_Purge_Click);
            // 
            // FormGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 585);
            this.Controls.Add(this.btn_Purge);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupFile);
            this.Controls.Add(this.groupMembrete);
            this.Controls.Add(this.btnPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FormGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGeneral";
            this.groupMembrete.ResumeLayout(false);
            this.groupMembrete.PerformLayout();
            this.groupFile.ResumeLayout(false);
            this.groupFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.GroupBox groupMembrete;
        private System.Windows.Forms.GroupBox groupFile;
        private System.Windows.Forms.Button btnQuitarText;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtQuitar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDetailEnginer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjectNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRevisionOTC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDrawingCAD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.TextBox txtIssuedFor;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.DateTimePicker dateTimeFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Purge;
    }
}