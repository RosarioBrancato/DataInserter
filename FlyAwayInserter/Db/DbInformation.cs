using FlyAwayInserter.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.Db {
	class DbInformation {

		public List<string> GetTablenames() {
			List<string> tablenames = new List<string>();

			string query = "SHOW TABLES FROM " + ConnectionString.Instance.Database;

			using (MySqlTransaction transaction = Connection.Instance.StartTransaction()) {
				MySqlCommand command = Connection.Instance.GetCommand(query, transaction);

				using(MySqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						tablenames.Add(reader.GetString(0));
					}
				}

				transaction.Commit();
			}

			return tablenames;
		}

		public List<ColumnStructure> GetColumnInformation(string tablename) {
			List<ColumnStructure> information = new List<ColumnStructure>();

			string query = "DESC " + tablename;

			using (MySqlTransaction transaction = Connection.Instance.StartTransaction()) {
				MySqlCommand command = Connection.Instance.GetCommand(query, transaction);

				using (MySqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						ColumnStructure cs = new ColumnStructure();

						cs.ColumnName = DbUtils.GetString(reader["Field"]);
						cs.DataType = DbUtils.GetString(reader["Type"]);
						cs.IsNullable = DbUtils.GetString(reader["Null"]);
						cs.Extra = DbUtils.GetString(reader["Extra"]);

						information.Add(cs);
					}
				}

				transaction.Commit();
			}

			return information;
		}

		public int GetRowCount(string tablename) {
			int count = 0;

			string query = "SELECT COUNT(*) FROM " + tablename;

			using (MySqlTransaction transaction = Connection.Instance.StartTransaction()) {
				MySqlCommand command = Connection.Instance.GetCommand(query, transaction);

				using (MySqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						count = reader.GetInt32(0);
					}
				}

				transaction.Commit();
			}

			return count;
		}

	}
}
