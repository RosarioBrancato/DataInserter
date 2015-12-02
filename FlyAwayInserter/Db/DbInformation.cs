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

		public Table GetTable(string tablename) {
			Table table = null;
			List<ColumnStructure> information = new List<ColumnStructure>();

			using (MySqlTransaction transaction = Connection.Instance.StartTransaction()) {

				//Structure
				string query = "DESC " + tablename;
				MySqlCommand command = Connection.Instance.GetCommand(query, transaction);

				using (MySqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						ColumnStructure cs = new ColumnStructure();

						cs.ColumnName = DbUtils.GetString(reader["Field"]);
						cs.DataType = DbUtils.GetString(reader["Type"]);
						cs.KeyType = DbUtils.GetString(reader["Key"]);
						cs.IsNullable = DbUtils.GetString(reader["Null"]);
						cs.Extra = DbUtils.GetString(reader["Extra"]);

						information.Add(cs);
					}
				}

				//Data
				table = new Table(tablename, information);

				query = "SELECT * from " + tablename;
				MySqlCommand commandData = Connection.Instance.GetCommand(query, transaction);

				using(MySqlDataReader reader = commandData.ExecuteReader()) {
					while(reader.Read()) {
						DataRow row = new DataRow();
						row.ColumnStructure = information;
						for (int i = 0; i < reader.FieldCount; i++) {
							row.Attributes.Add(new Flag(reader.GetName(i), reader[i].ToString(),  reader.GetDataTypeName(i)));
						}
						table.DataRows.Add(row);
					}
				}

				transaction.Commit();
			}

			return table;
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

		public Table GetTableOfForeignKey(string tablename, string columnname) {
			Table table = null;
			string tableRelation = string.Empty;

			using (MySqlTransaction transaction = Connection.Instance.StartTransaction()) {

				//Structure
				string query = "SELECT REFERENCED_TABLE_NAME"
							 + " FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE"
							 + " WHERE TABLE_SCHEMA = \"" + ConnectionString.Instance.Database + "\" AND TABLE_NAME = \"" + tablename + "\" AND COLUMN_NAME = \"" + columnname + "\"";
				MySqlCommand command = Connection.Instance.GetCommand(query, transaction);

				using (MySqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						tableRelation = DbUtils.GetString(reader["REFERENCED_TABLE_NAME"]);
					}
				}

				//Data
				if (!string.IsNullOrEmpty(tableRelation)) {
					table = this.GetTable(tableRelation);
				}

				transaction.Commit();
			}

			return table;
		}

	}
}
