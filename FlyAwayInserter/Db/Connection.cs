using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAwayInserter.Db {
    class Connection {

        private static Connection instance = null;
        //private const string CONNECTION_STRING = "server=localhost;uid=root;database=FlyAway";


        public static Connection Instance {
            get {
                if (instance == null) {
                    instance = new Connection();
                }
                return instance;
            }
        }

        private Connection() {

        }

        public MySqlTransaction StartTransaction() {
            //Connection
            MySqlConnection conn = new MySqlConnection(ConnectionString.Instance.String);
            conn.Open();
            return conn.BeginTransaction();
        }

        public MySqlCommand GetCommand(string sql, MySqlTransaction trans) {
            //Command
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sql;
            command.Connection = trans.Connection;
            command.Transaction = trans;

            return command;
        }

    }
}
