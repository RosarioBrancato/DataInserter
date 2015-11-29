using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.DTO {
	public class Table {

		private List<DataRow> dataRows = new List<DataRow>();

		public string TableName { get; private set; }
		public List<ColumnStructure> ColumnStructure { get; private set; }

		public List<DataRow> DataRows {
			get {
				return this.dataRows;
			}
		}

		public Table(string tablename, List<ColumnStructure> columnStructure) {
			this.TableName = tablename;
			this.ColumnStructure = columnStructure;
		}

	}
}
