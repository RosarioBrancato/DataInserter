using DataInserter.Db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataInserter.View {
	public partial class ConnectionSettings : Form {

		private string host = string.Empty;
		private string port = string.Empty;
		private string database = string.Empty;
		private string username = string.Empty;
		private string password = string.Empty;

		public ConnectionSettings() {
			InitializeComponent();

			this.txtPassword.PasswordChar = '*';

			if (string.IsNullOrEmpty(ConnectionString.Instance.Host)) {
				this.load();
			} else {
				this.host = ConnectionString.Instance.Host;
				this.port = ConnectionString.Instance.Port;
				this.database = ConnectionString.Instance.Database;
				this.username = ConnectionString.Instance.Username;
				this.password = ConnectionString.Instance.Password;

				this.txtHost.Text = ConnectionString.Instance.Host;
				this.txtPort.Text = ConnectionString.Instance.Port;
				this.txtDatabase.Text = ConnectionString.Instance.Database;
				this.txtUsername.Text = ConnectionString.Instance.Username;
				this.txtPassword.Text = ConnectionString.Instance.Password;
			}
		}


		protected override void OnClosing(CancelEventArgs e) {
			base.OnClosing(e);

			if (this.DialogResult != DialogResult.Yes) {
				this.loadFromCache();
			}
		}


		private void loadFromCache() {
			ConnectionString.Instance.Host = this.host;
			ConnectionString.Instance.Port = this.port;
			ConnectionString.Instance.Database = this.database;
			ConnectionString.Instance.Username = this.username;
			ConnectionString.Instance.Password = this.password;
		}

		private void load() {
			try {
				string path = Path.Combine(Application.StartupPath, "ConnectionSettingsConf.xml");
				if (File.Exists(path)) {
					XElement ele = XElement.Load(path);
					foreach (XElement e in ele.Elements()) {
						switch (e.Name.LocalName) {
							case "Host":
								this.txtHost.Text = e.Value;
								break;
							case "Port":
								this.txtPort.Text = e.Value;
								break;
							case "Database":
								this.txtDatabase.Text = e.Value;
								break;
							case "Username":
								this.txtUsername.Text = e.Value;
								break;
						}
					}
				}

			} catch(Exception ex) {
				Console.WriteLine("Error in ConnectionSettings.load(): " + ex.Message + Environment.NewLine + ex.StackTrace);
			}
		}

		private void save() {
			try {
				XElement connectionSetting = new XElement("ConnectionSettings");
				connectionSetting.Add(new XElement("Host", ConnectionString.Instance.Host));
				connectionSetting.Add(new XElement("Port", ConnectionString.Instance.Port));
				connectionSetting.Add(new XElement("Database", ConnectionString.Instance.Database));
				connectionSetting.Add(new XElement("Username", ConnectionString.Instance.Username));

				connectionSetting.Save(Path.Combine(Application.StartupPath, "ConnectionSettingsConf.xml"));

			} catch(Exception ex) {
				Console.WriteLine("Error in ConnectionSettings.save(): " + ex.Message + Environment.NewLine + ex.StackTrace);
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			ConnectionString.Instance.Host = this.txtHost.Text;
			ConnectionString.Instance.Port = this.txtPort.Text;
			ConnectionString.Instance.Database = this.txtDatabase.Text;
			ConnectionString.Instance.Username = this.txtUsername.Text;
			ConnectionString.Instance.Password = this.txtPassword.Text;

			try {
				using (MySqlTransaction transaction = Connection.Instance.BeginTransaction()) {
					transaction.Rollback();
				}

				this.save();
				this.DialogResult = DialogResult.Yes;

			} catch(MySqlException ex) {
				MessageBox.Show(this, "Connection settings are not correct. Please check your entries.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.loadFromCache();
			this.DialogResult = DialogResult.Cancel;
		}

	}
}
