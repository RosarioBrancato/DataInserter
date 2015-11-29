namespace FlyAwayInserter {
	partial class FlyAwayInserter {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.cmbTables = new System.Windows.Forms.ComboBox();
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.lblQuery = new System.Windows.Forms.Label();
			this.lblTablename = new System.Windows.Forms.Label();
			this.pnlTablename = new System.Windows.Forms.Panel();
			this.btnConnectionSettings = new System.Windows.Forms.Button();
			this.pnlQuery = new System.Windows.Forms.Panel();
			this.chkAllowEdit = new System.Windows.Forms.CheckBox();
			this.btnExcecute = new System.Windows.Forms.Button();
			this.pnlFields = new System.Windows.Forms.Panel();
			this.pnlColumnInfos = new System.Windows.Forms.Panel();
			this.lblTestInfo = new System.Windows.Forms.Label();
			this.pnlValues = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.pnlColumnnames = new System.Windows.Forms.Panel();
			this.lblTestId = new System.Windows.Forms.Label();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.pnlTablename.SuspendLayout();
			this.pnlQuery.SuspendLayout();
			this.pnlFields.SuspendLayout();
			this.pnlColumnInfos.SuspendLayout();
			this.pnlValues.SuspendLayout();
			this.pnlColumnnames.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbTables
			// 
			this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbTables.FormattingEnabled = true;
			this.cmbTables.Location = new System.Drawing.Point(118, 9);
			this.cmbTables.Name = "cmbTables";
			this.cmbTables.Size = new System.Drawing.Size(332, 24);
			this.cmbTables.TabIndex = 0;
			this.cmbTables.TabStop = false;
			this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
			// 
			// txtQuery
			// 
			this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQuery.Location = new System.Drawing.Point(15, 29);
			this.txtQuery.Multiline = true;
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.ReadOnly = true;
			this.txtQuery.Size = new System.Drawing.Size(1002, 230);
			this.txtQuery.TabIndex = 1;
			this.txtQuery.TabStop = false;
			// 
			// lblQuery
			// 
			this.lblQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuery.Location = new System.Drawing.Point(12, 3);
			this.lblQuery.Name = "lblQuery";
			this.lblQuery.Size = new System.Drawing.Size(71, 23);
			this.lblQuery.TabIndex = 2;
			this.lblQuery.Text = "Query";
			this.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTablename
			// 
			this.lblTablename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTablename.Location = new System.Drawing.Point(12, 9);
			this.lblTablename.Name = "lblTablename";
			this.lblTablename.Size = new System.Drawing.Size(100, 23);
			this.lblTablename.TabIndex = 3;
			this.lblTablename.Text = "Tablename:";
			this.lblTablename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlTablename
			// 
			this.pnlTablename.Controls.Add(this.btnConnectionSettings);
			this.pnlTablename.Controls.Add(this.lblTablename);
			this.pnlTablename.Controls.Add(this.cmbTables);
			this.pnlTablename.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTablename.Location = new System.Drawing.Point(0, 0);
			this.pnlTablename.Name = "pnlTablename";
			this.pnlTablename.Size = new System.Drawing.Size(1029, 45);
			this.pnlTablename.TabIndex = 4;
			// 
			// btnConnectionSettings
			// 
			this.btnConnectionSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConnectionSettings.Location = new System.Drawing.Point(456, 9);
			this.btnConnectionSettings.Name = "btnConnectionSettings";
			this.btnConnectionSettings.Size = new System.Drawing.Size(203, 23);
			this.btnConnectionSettings.TabIndex = 4;
			this.btnConnectionSettings.TabStop = false;
			this.btnConnectionSettings.Text = "Connection Settings...";
			this.btnConnectionSettings.UseVisualStyleBackColor = true;
			this.btnConnectionSettings.Click += new System.EventHandler(this.btnConnectionSettings_Click);
			// 
			// pnlQuery
			// 
			this.pnlQuery.Controls.Add(this.chkAllowEdit);
			this.pnlQuery.Controls.Add(this.btnExcecute);
			this.pnlQuery.Controls.Add(this.txtQuery);
			this.pnlQuery.Controls.Add(this.lblQuery);
			this.pnlQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlQuery.Location = new System.Drawing.Point(0, 45);
			this.pnlQuery.Name = "pnlQuery";
			this.pnlQuery.Size = new System.Drawing.Size(1029, 294);
			this.pnlQuery.TabIndex = 5;
			// 
			// chkAllowEdit
			// 
			this.chkAllowEdit.AutoSize = true;
			this.chkAllowEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAllowEdit.Location = new System.Drawing.Point(118, 5);
			this.chkAllowEdit.Name = "chkAllowEdit";
			this.chkAllowEdit.Size = new System.Drawing.Size(84, 20);
			this.chkAllowEdit.TabIndex = 4;
			this.chkAllowEdit.TabStop = false;
			this.chkAllowEdit.Text = "Allow edit";
			this.chkAllowEdit.UseVisualStyleBackColor = true;
			this.chkAllowEdit.CheckedChanged += new System.EventHandler(this.chkAllowEdit_CheckedChanged);
			// 
			// btnExcecute
			// 
			this.btnExcecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExcecute.Location = new System.Drawing.Point(15, 265);
			this.btnExcecute.Name = "btnExcecute";
			this.btnExcecute.Size = new System.Drawing.Size(139, 23);
			this.btnExcecute.TabIndex = 3;
			this.btnExcecute.TabStop = false;
			this.btnExcecute.Text = "Excecute Query";
			this.btnExcecute.UseVisualStyleBackColor = true;
			this.btnExcecute.Click += new System.EventHandler(this.btnExcecute_Click);
			// 
			// pnlFields
			// 
			this.pnlFields.Controls.Add(this.pnlColumnInfos);
			this.pnlFields.Controls.Add(this.pnlValues);
			this.pnlFields.Controls.Add(this.pnlColumnnames);
			this.pnlFields.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFields.Location = new System.Drawing.Point(0, 339);
			this.pnlFields.Name = "pnlFields";
			this.pnlFields.Size = new System.Drawing.Size(1029, 33);
			this.pnlFields.TabIndex = 6;
			// 
			// pnlColumnInfos
			// 
			this.pnlColumnInfos.Controls.Add(this.lblTestInfo);
			this.pnlColumnInfos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlColumnInfos.Location = new System.Drawing.Point(590, 0);
			this.pnlColumnInfos.Name = "pnlColumnInfos";
			this.pnlColumnInfos.Size = new System.Drawing.Size(439, 33);
			this.pnlColumnInfos.TabIndex = 2;
			// 
			// lblTestInfo
			// 
			this.lblTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestInfo.Location = new System.Drawing.Point(6, 3);
			this.lblTestInfo.Name = "lblTestInfo";
			this.lblTestInfo.Size = new System.Drawing.Size(434, 23);
			this.lblTestInfo.TabIndex = 5;
			this.lblTestInfo.Text = "datatype: varchar: maxlen: 20; not null;";
			this.lblTestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlValues
			// 
			this.pnlValues.Controls.Add(this.textBox1);
			this.pnlValues.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlValues.Location = new System.Drawing.Point(290, 0);
			this.pnlValues.Name = "pnlValues";
			this.pnlValues.Size = new System.Drawing.Size(300, 33);
			this.pnlValues.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(6, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(288, 22);
			this.textBox1.TabIndex = 0;
			// 
			// pnlColumnnames
			// 
			this.pnlColumnnames.Controls.Add(this.lblTestId);
			this.pnlColumnnames.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlColumnnames.Location = new System.Drawing.Point(0, 0);
			this.pnlColumnnames.Name = "pnlColumnnames";
			this.pnlColumnnames.Size = new System.Drawing.Size(290, 33);
			this.pnlColumnnames.TabIndex = 0;
			// 
			// lblTestId
			// 
			this.lblTestId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestId.Location = new System.Drawing.Point(3, 3);
			this.lblTestId.Name = "lblTestId";
			this.lblTestId.Size = new System.Drawing.Size(284, 23);
			this.lblTestId.TabIndex = 4;
			this.lblTestId.Text = "ID:";
			this.lblTestId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.btnAdd);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlBottom.Location = new System.Drawing.Point(0, 372);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(1029, 39);
			this.pnlBottom.TabIndex = 7;
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(290, 6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 99;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// FlyAwayInserter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1029, 411);
			this.Controls.Add(this.pnlBottom);
			this.Controls.Add(this.pnlFields);
			this.Controls.Add(this.pnlQuery);
			this.Controls.Add(this.pnlTablename);
			this.Name = "FlyAwayInserter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FlyAwayInserter";
			this.pnlTablename.ResumeLayout(false);
			this.pnlQuery.ResumeLayout(false);
			this.pnlQuery.PerformLayout();
			this.pnlFields.ResumeLayout(false);
			this.pnlColumnInfos.ResumeLayout(false);
			this.pnlValues.ResumeLayout(false);
			this.pnlValues.PerformLayout();
			this.pnlColumnnames.ResumeLayout(false);
			this.pnlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbTables;
		private System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.Label lblQuery;
		private System.Windows.Forms.Label lblTablename;
		private System.Windows.Forms.Panel pnlTablename;
		private System.Windows.Forms.Panel pnlQuery;
		private System.Windows.Forms.Panel pnlFields;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnExcecute;
		private System.Windows.Forms.Panel pnlColumnInfos;
		private System.Windows.Forms.Panel pnlValues;
		private System.Windows.Forms.Panel pnlColumnnames;
		private System.Windows.Forms.Label lblTestInfo;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label lblTestId;
		private System.Windows.Forms.CheckBox chkAllowEdit;
		private System.Windows.Forms.Button btnConnectionSettings;
	}
}

