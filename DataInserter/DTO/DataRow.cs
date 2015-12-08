using DataInserter.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInserter.DTO {
	public class DataRow {

		private List<Flag> attributes = new List<Flag>();

		public List<ColumnStructure> ColumnStructure { get; set; }
		public List<Flag> Attributes {
			get {
				return this.attributes;
			}
		}

		public List<string> Columns {
			get {
				List<string> columns = new List<string>();

				foreach(Flag a in this.attributes) {
					columns.Add(a.ColumnName);
				}

				return columns;
			}
		}

	}
}
