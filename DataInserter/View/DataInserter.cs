using DataInserter.Db;
using DataInserter.DTO;
using DataInserter.View;
using FlyAwayInserter.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataInserter {
	public partial class DataInserter : Form {

		private Table table = null;
		private DbInformation dbInformation = null;
		private DbExecute dbFlyAway = null;

		private int height_start = 600;

		private TextBox ctrlToIncrement = null;
		private int nextId = 1;


		public DataInserter() {
			InitializeComponent();

			this.height_start = this.Height;

			this.dbInformation = new DbInformation();
			this.dbFlyAway = new DbExecute();

			//Set up
			this.ConfigureConnection();
		}


		private void FillTablenames() {
			this.cmbTables.Items.Clear();
			List<string> tablenames = this.dbInformation.GetTablenames();
			foreach(string name in tablenames) {
				this.cmbTables.Items.Add(name);
			}

			if(this.cmbTables.Items.Count > 0) {
				this.cmbTables.SelectedIndex = 0;
			}
		}

		private void LoadTable(string tablename) {
			if (tablename.Trim().Length > 0) {
				this.table = this.dbInformation.GetTable(tablename);
				this.FillListview();
				this.ConfigureView();

				//clear existing data to create new inserts
				this.table.DataRows.Clear();
			}
		}

		private void FillListview() {
			this.lsvTableData.BeginUpdate();

			this.lsvTableData.Items.Clear();
			this.lsvTableData.Columns.Clear();

			foreach(ColumnStructure cs in this.table.ColumnStructure) {
				this.lsvTableData.Columns.Add(cs.ColumnName, 150);
			}

			this.nextId = 1;

			foreach(DTO.DataRow row in this.table.DataRows) {
				List<string> entry = new List<string>();

				foreach (ColumnStructure cs in this.table.ColumnStructure) {
					foreach (Flag flag in row.Attributes) {
						if (flag.ColumnName == cs.ColumnName) {
							entry.Add(flag.Value);

							if(cs.KeyType.ToLower() == MySqlConstants.PRIMARY_KEY) {
								this.nextId = Int32.Parse(flag.Value) + 1;
							}
						}
					}
				}

				this.lsvTableData.Items.Add(new ListViewItem(entry.ToArray())); 
			}

			this.lsvTableData.EndUpdate();
		}

		private void ConfigureView() {
			this.pnlColumnnames.Controls.Clear();
			this.pnlValues.Controls.Clear();
			this.pnlColumnInfos.Controls.Clear();

			int heightFrm = this.height_start;
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

				//Value
				if (cs.KeyType.ToLower() == "mul") {
					ComboBox combobox = this.GetValueComboBox(cs);
					combobox.Location = new Point(0, location_y);
					combobox.Tag = cs;
					this.pnlValues.Controls.Add(combobox);

				} else {
					//TextBox
					TextBox textbox = this.GetValueTextBox();
					textbox.Location = new Point(0, location_y);
					textbox.Tag = cs;
					if (!string.IsNullOrEmpty(cs.Extra) && cs.Extra.ToLower().Contains(MySqlConstants.AUTO_INCREMENT)) {
						textbox.Text = this.nextId.ToString();
						textbox.TabStop = false;
						this.ctrlToIncrement = textbox;
					}
					this.pnlValues.Controls.Add(textbox);
				}

				//Label ColumnInfo
				Label lblColumnInfo = this.GetColumnInfoLabel();
				lblColumnInfo.Location = new Point(0, location_y);
				if (!string.IsNullOrEmpty(cs.DataType)) {
					lblColumnInfo.Text += cs.DataType + "; ";
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

		private ComboBox GetValueComboBox(ColumnStructure cs) {
			ComboBox combobox = new ComboBox();
			combobox.BeginUpdate();

			combobox.DropDownStyle = ComboBoxStyle.DropDownList;
			combobox.Width = this.pnlValues.Width - 3;
			combobox.Font = new Font("Microsoft Sans Serif", 10);

			Table table = this.dbInformation.GetTableOfForeignKey(this.table.TableName, cs.ColumnName);

			if (table != null) {
				if(cs.IsNullable.ToLower() == "yes") {
					combobox.Items.Add("");
				}

				foreach (DTO.DataRow row in table.DataRows) {
					string item = string.Empty;
					foreach (Flag flag in row.Attributes) {
						item += flag.Value + "; ";
					}
					combobox.Items.Add(item);
				}
			}

			if(combobox.Items.Count > 0) {
				combobox.SelectedIndex = 0;
			}

			combobox.EndUpdate();

			return combobox;
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

		private void ClearFields() {
			foreach(Control ctrl in this.pnlValues.Controls) {
				if(ctrl is TextBox) {
					((TextBox)ctrl).Clear();
				}
			}
		}


		private void Add() {
			//Add row
			DTO.DataRow row = new DTO.DataRow();
			row.ColumnStructure = this.table.ColumnStructure;
			foreach (Control ctrl in this.pnlValues.Controls) {
				ColumnStructure cs = (ColumnStructure)ctrl.Tag;
				if (ctrl is TextBox) {
					row.Attributes.Add(new Flag(cs.ColumnName, ctrl.Text, cs.DataType));

				} else if(ctrl is ComboBox) {
					string value = string.Empty;
					if(!string.IsNullOrEmpty(ctrl.Text)) {
						value = ctrl.Text.Split(';')[0];
                    }
					row.Attributes.Add(new Flag(cs.ColumnName, value, cs.DataType));
				}
			}
			this.table.DataRows.Add(row);

			//Clear fields
			if (this.ctrlToIncrement != null) {
				Int32.TryParse(this.ctrlToIncrement.Text, out int id);

				this.ClearFields();
				this.ctrlToIncrement.Text = (id + 1).ToString();

			} else {
				this.ClearFields();
			}

			//Generate query
			this.txtQuery.Text = InsertStatement.GetQuery(table);
        }

		private void ExecuteQuery() {
			if (this.txtQuery.Text.Trim().Length > 0) {
				//Cache values
				string query = this.txtQuery.Text;
				List<DTO.DataRow> rows = this.table.DataRows;
				string id = string.Empty;
				if (this.ctrlToIncrement != null) {
					id = this.ctrlToIncrement.Text;
				}

				ReportMessage message = this.dbFlyAway.ExecuteQuery(this.txtQuery.Text);
				this.LoadTable((string)this.cmbTables.SelectedItem);

				this.txtQuery.Text = query;
				this.table.DataRows = rows;
				if(this.ctrlToIncrement != null) {
					this.ctrlToIncrement.Text = id;
				}

                MessageBox.Show(this, message.Message, "Execute query", MessageBoxButtons.OK, message.GetIconOfStatus());
			}
		}

		private void ConfigureConnection() {
			using (ConnectionSettings dlg = new ConnectionSettings()) {
				DialogResult res = dlg.ShowDialog(this);

				if (res == DialogResult.Yes) {
					this.FillTablenames();
				}
			}
		}


		private void CmbTables_SelectedIndexChanged(object sender, EventArgs e) {
			if (this.cmbTables.SelectedItem != null) {
				this.LoadTable((string)this.cmbTables.SelectedItem);
			}
		}

		private void BtnExcecute_Click(object sender, EventArgs e) {
			this.ExecuteQuery();
		}

		private void ChkAllowEdit_CheckedChanged(object sender, EventArgs e) {
			this.txtQuery.ReadOnly = !this.chkAllowEdit.Checked;
		}

		private void BtnAdd_Click(object sender, EventArgs e) {
			this.Add();
			this.SelectNextControl(this.btnAdd, true, true, true, true);
		}

		private void BtnConnectionSettings_Click(object sender, EventArgs e) {
			this.ConfigureConnection();
		}

		private void TxtQuery_KeyDown(object sender, KeyEventArgs e) {
			if(e.Control && e.KeyCode == Keys.A) {
				this.txtQuery.SelectAll();
			}
		}
	}
}
