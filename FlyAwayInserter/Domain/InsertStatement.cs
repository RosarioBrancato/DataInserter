using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.DTO {
	public static class InsertStatement {

		public static string GetQuery(Table table) {
			StringBuilder query = new StringBuilder();
			query.Append("INSERT INTO ");
			query.Append(table.TableName);
			query.Append(" (");

			List<string> columns = table.DataRows.First().Columns;
			for (int i = 0; i < columns.Count; i++) {
				query.Append(columns[i]);
				if (i < columns.Count - 1) {
					query.Append(", ");
				}
			}

			query.AppendLine(") VALUES ");

			for (int i = 0; i < table.DataRows.Count; i++) {
				query.Append("(");

				for (int k = 0; k < table.DataRows[i].Attributes.Count; k++) {
					Flag flag = table.DataRows[i].Attributes[k];

					if (flag.DataType.ToLower().Contains("varchar") || flag.DataType.ToLower().Contains("enum") || flag.DataType.ToLower().Contains("text")) {
						query.Append("\"");
						query.Append(flag.Value);
						query.Append("\"");

					} else {
						query.Append(flag.Value);
					}

					if (k < table.DataRows[i].Attributes.Count - 1) {
						query.Append(", ");
					}
				}

				if (i < table.DataRows.Count - 1) {
					query.AppendLine("), ");
				}
			}

			query.Append(");");

			return query.ToString();
		}

	}
}
