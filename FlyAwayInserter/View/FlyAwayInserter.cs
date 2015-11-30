using FlyAwayInserter.Db;
using FlyAwayInserter.DTO;
using FlyAwayInserter.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyAwayInserter {
	public partial class FlyAwayInserter : Form {

		private Table table = null;
		private DbInformation dbInformation = null;
		private DbFlyAway dbFlyAway = null;

		private TextBox ctrlToIncrement = null;

		public FlyAwayInserter() {
			InitializeComponent();

			this.dbInformation = new DbInformation();
			this.dbFlyAway = new DbFlyAway();

			//Set up
			this.configureConnection();
		}

		private void fillTablenames() {
			List<string> tablenames = this.dbInformation.GetTablenames();
			foreach(string name in tablenames) {
				this.cmbTables.Items.Add(name);
			}

			if(this.cmbTables.Items.Count > 0) {
				this.cmbTables.SelectedIndex = 0;
			}
		}

		private void loadTable(string tablename) {
			if (tablename.Trim().Length > 0) {
				List<ColumnStructure> cs = this.dbInformation.GetColumnInformation(tablename);

				this.table = new Table(tablename, cs);

				this.configureView();
			}
		}



		private void configureView() {
			this.pnlColumnnames.Controls.Clear();
			this.pnlValues.Controls.Clear();
			this.pnlColumnInfos.Controls.Clear();

			int heightFrm = 430;
			int heightPnl = 10;

			int location_y = 10;
			int gab_y = 3;

			int count = 0;

			foreach(ColumnStructure cs in this.table.ColumnStructure) {

				//Label ColumnName
				Label lblColumnName = this.GetColumnNameLabel();
				lblColumnName.Location = new Point(0, location_y);
				lblColumnName.Tag = cs.ColumnName;
				lblColumnName.Text = cs.ColumnName + ":";
				this.pnlColumnnames.Controls.Add(lblColumnName);

				//TextBox Value
				TextBox textbox = this.GetValueTextBox();
				textbox.Location = new Point(0, location_y);
				textbox.Tag = cs;
				if (cs.ColumnName.ToLower() == "id") {
					textbox.Text = "1";
					textbox.TabStop = false;
					this.ctrlToIncrement = textbox;
				}
				this.pnlValues.Controls.Add(textbox);

				//Label ColumnInfo
				Label lblColumnInfo = this.GetColumnInfoLabel();
				lblColumnInfo.Location = new Point(0, location_y);
				if (!string.IsNullOrEmpty(cs.DataType)) {
					lblColumnInfo.Text += "DataType: " + cs.DataType + "; ";
				}
				if(!string.IsNullOrEmpty(cs.IsNullable)) {
					lblColumnInfo.Text += "Is nullable: " + cs.IsNullable + "; ";
				}
				if(!string.IsNullOrEmpty(cs.Extra)) {
					lblColumnInfo.Text += "Extra: " + cs.Extra + "; ";
				}
				this.pnlColumnInfos.Controls.Add(lblColumnInfo);

				location_y += lblColumnName.Height + gab_y;
				heightPnl += lblColumnName.Height + gab_y;
				heightFrm += lblColumnName.Height + gab_y;

				count++;
			}

			this.Height = heightFrm;
			this.pnlFields.Height = heightPnl;
		}

		private Label GetColumnNameLabel() {
			Label label = new Label();

			label.AutoSize = false;
			label.TextAlign = ContentAlignment.MiddleRight;
			label.Width = this.pnlColumnnames.Width - 3;
			label.Font = new Font("Microsoft Sans Serif", 10);

			return label;
		}

		private TextBox GetValueTextBox() {
			TextBox textbox = new TextBox();

			textbox.Width = this.pnlValues.Width - 3;
			textbox.Font = new Font("Microsoft Sans Serif", 10);

			return textbox;
		}

		private Label GetColumnInfoLabel() {
			Label label = new Label();

			label.AutoSize = false;
			label.TextAlign = ContentAlignment.MiddleLeft;
			label.Width = this.pnlColumnInfos.Width - 3;
			label.Font = new Font("Microsoft Sans Serif", 10);
			label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

			return label;
		}

		private void clearFields() {
			foreach(Control ctrl in this.pnlValues.Controls) {
				if(ctrl is TextBox) {
					((TextBox)ctrl).Clear();
				}
			}
		}


		private void add() {
			//Add row
			DTO.DataRow row = new DTO.DataRow();
			row.ColumnStructure = this.table.ColumnStructure;
			foreach (Control ctrl in this.pnlValues.Controls) {
				if (ctrl is TextBox) {
					ColumnStructure cs = (ColumnStructure)ctrl.Tag;
					row.Attributes.Add(new Flag(cs.ColumnName, ctrl.Text, cs.DataType));
				}
			}
			this.table.DataRows.Add(row);

			//Clear fields
			if (this.ctrlToIncrement != null) {
				int id = 1;
				Int32.TryParse(this.ctrlToIncrement.Text, out id);

				this.clearFields();
				this.ctrlToIncrement.Text = (id + 1).ToString();

			} else {
				this.clearFields();
			}

			//Generate query
			this.txtQuery.Text = InsertStatement.GetQuery(table);
        }

		private void executeQuery() {
			if (this.txtQuery.Text.Trim().Length > 0) {
				ReportMessage message = this.dbFlyAway.ExecuteQuery(this.txtQuery.Text);
                MessageBox.Show(this, message.Message, "Execute query", MessageBoxButtons.OK, message.GetIconOfStatus());
			}
		}

		private void configureConnection() {
			using (ConnectionSettings dlg = new ConnectionSettings()) {
				DialogResult res = dlg.ShowDialog(this);

				if (res == DialogResult.Yes) {
					this.fillTablenames();
				}
			}
		}

		private void cmbTables_SelectedIndexChanged(object sender, EventArgs e) {
			if (this.cmbTables.SelectedItem != null) {
				this.loadTable((string)this.cmbTables.SelectedItem);
			}
		}

		private void btnExcecute_Click(object sender, EventArgs e) {
			this.executeQuery();
		}

		private void chkAllowEdit_CheckedChanged(object sender, EventArgs e) {
			this.txtQuery.ReadOnly = !this.chkAllowEdit.Checked;
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			this.add();
			this.SelectNextControl(this.btnAdd, true, true, true, true);
		}

		private void btnConnectionSettings_Click(object sender, EventArgs e) {
			this.configureConnection();
		}
	}
}
