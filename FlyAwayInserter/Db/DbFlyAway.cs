using FlyAwayInserter.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.Db {
	class DbFlyAway {

		public ReportMessage ExecuteQuery(string query) {
			ReportMessage message = null;

			MySqlTransaction transaction = null;
			try {
				transaction = Connection.Instance.StartTransaction();
				MySqlCommand command = Connection.Instance.GetCommand(query, transaction);
				int rows = command.ExecuteNonQuery();

				if (rows > 0) {
					transaction.Commit();
					message = new ReportMessage(true, "Success!", ReportStatus.Success);
				} else {
					message = new ReportMessage(true, "No errors occured, however, no rows were affected.", ReportStatus.Warning);
				}

			} catch (MySqlException ex) {
				message = new ReportMessage(false, "Error occured: " + ex.Message, ReportStatus.Error);
				if (transaction != null) {
					transaction.Rollback();
				}
				Console.WriteLine("Error in DbFlyAway.ExecuteQuery: " + ex.Message);
			}

			return message;
		}

	}
}
