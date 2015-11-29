using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.DTO {

	public class Flag {

		public string ColumnName { get; set; }
		public string Value { get; set; }
		public string DataType { get; set; }

		public Flag(string columnName, string value, string dataType) {
			this.ColumnName = columnName;
			this.Value = value;
			this.DataType = dataType;
		}

	}
}