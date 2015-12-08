using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInserter.DTO {
	public class Table {
		
		public string TableName { get; private set; }
		public List<ColumnStructure> ColumnStructure { get; private set; }
		public List<DataRow> DataRows { get; set; }

		public Table(string tablename, List<ColumnStructure> columnStructure) {
			this.TableName = tablename;
			this.ColumnStructure = columnStructure;
			this.DataRows = new List<DataRow>();
		}

	}
}
