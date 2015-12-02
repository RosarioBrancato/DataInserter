using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.DTO {
	public class ColumnStructure {

		public string ColumnName { get; set; }
		public string DataType { get; set; }
		public string KeyType { get; set; }
		public string IsNullable { get; set; }
		public string Extra { get; set; }

	}
}
