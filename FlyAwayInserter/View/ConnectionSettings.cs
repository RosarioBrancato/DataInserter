using FlyAwayInserter.Db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyAwayInserter.View {
	public partial class ConnectionSettings : Form {

		private bool allowClose = true;

		public ConnectionSettings() {
			InitializeComponent();

			this.txtPassword.PasswordChar = '*';

			this.txtHost.Text = ConnectionString.Instance.Host;
			this.txtPort.Text = ConnectionString.Instance.Port;
			this.txtDatabase.Text = ConnectionString.Instance.Database;
			this.txtUsername.Text = ConnectionString.Instance.Username;
			this.txtPassword.Text = ConnectionString.Instance.Password;
		}

		private void btnSave_Click(object sender, EventArgs e) {
			ConnectionString.Instance.Host = this.txtHost.Text;
			ConnectionString.Instance.Port = this.txtPort.Text;
			ConnectionString.Instance.Database = this.txtDatabase.Text;
			ConnectionString.Instance.Username = this.txtUsername.Text;
			ConnectionString.Instance.Password = this.txtPassword.Text;

			try {
				using (MySqlTransaction transaction = Connection.Instance.StartTransaction()) {
					transaction.Rollback();
				}

				this.allowClose = true;
				this.DialogResult = DialogResult.Yes;

			} catch(MySqlException ex) {
				this.allowClose = false;
				MessageBox.Show(this, "ConnectionString is not correct. Please check your entries.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnCancel_Click(object sender, EventArgs e) {
			if (this.allowClose) {
				this.DialogResult = DialogResult.Cancel;
			} else {
				MessageBox.Show(this, "ConnectionString is not correct. Please check your entries.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
