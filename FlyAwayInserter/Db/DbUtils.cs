using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.Db {
	public static class DbUtils {

		public static string GetString(object value) {
			string v = string.Empty;

			if(value != null && value != DBNull.Value) {
				v = (string)value;
			}

			return v;
		}

	}
}
