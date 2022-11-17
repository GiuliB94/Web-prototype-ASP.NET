using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Data
{
    public class AccessData
    {
        private MySqlConnection connection;
        private string connString = "server = 190.61.250.150; userid = effort_admin; password = proyectazo; database = effort_db;";
        private MySqlCommand command;
        private MySqlDataReader reader;

        public MySqlDataReader Reader
        {
            get { return reader; }
        }

        public AccessData()
        {
            this.connection = new MySqlConnection(connString);
            this.command = new MySqlCommand();
        }
        public void setQuery(string query)
        {
            this.command.CommandType = System.Data.CommandType.Text;
            this.command.CommandText = query;
        }
        public void executeQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetParameter(string parameterName, object value)
        {
            command.Parameters.AddWithValue(parameterName, value);
        }
        public void executeAction()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
        public void closeConnection()
        {
            if (reader != null)
            {
                reader.Close();
                connection.Close();
            }
        }
    }
}