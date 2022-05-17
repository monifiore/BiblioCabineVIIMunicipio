using LegArtiCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegArtiDAL
{
    public class GenericDAL
    {
        private string _connStr = ConfigHelper.Settings.ConnectionString;


        public string ExecuteWhitJsonRet(string _storedProcedure, Dictionary<string, object> _parameters = null)
        {
            try
            {
                string _returnValue = string.Empty;
                using (SqlConnection _conn = new SqlConnection(_connStr))
                {
                    _conn.Open();
                    using SqlCommand _command = createCommand(_conn, _storedProcedure, _parameters);
                    _command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Ret",
                        DbType = DbType.String,
                        Direction = ParameterDirection.Output,
                        Size = -1
                    });
                    _command.ExecuteNonQuery();
                    _returnValue = _command.Parameters["@Ret"].Value.ToString();
                }
                return _returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteNonQuery(string _storedProcedure, Dictionary<string, object> _parameters = null)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(_connStr))
                {
                    _conn.Open();
                    using SqlCommand _command = createCommand(_conn, _storedProcedure, _parameters);
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> ExecuteWhitJsonRetAsync(string _storedProcedure, Dictionary<string, object> _parameters = null)
        {
            try
            {
                string _returnValue = string.Empty;
                using (SqlConnection _conn = new SqlConnection(_connStr))
                {
                    using SqlCommand _command = createCommand(_conn, _storedProcedure, _parameters);
                    _command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Ret",
                        DbType = DbType.String,
                        Direction = ParameterDirection.Output,
                        Size = -1
                    });
                    await _command.ExecuteNonQueryAsync();
                    _returnValue = _command.Parameters["@Ret"].Value.ToString();
                }
                return _returnValue;
            }
            catch
            {
                throw;
            }
        }

        public async Task ExecuteNonQueryAsync(string _storedProcedure, Dictionary<string, object> _parameters = null)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(_connStr))
                {
                    _conn.Open();
                    using SqlCommand _command = createCommand(_conn, _storedProcedure, _parameters);
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DataSet> ExecuteWhitDataSetRet(string _storedProcedure, Dictionary<string, object> _parameters = null)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection _conn = new SqlConnection(_connStr))
                {
                    _conn.Open();
                    using SqlCommand _command = createCommand(_conn, _storedProcedure, _parameters);
                    using SqlDataAdapter adp = new SqlDataAdapter(_command);
                    Task.Run(() => adp.Fill(ds)).Wait();
                }
                return ds;
            }
            catch
            {
                throw;
            }
        }

        private SqlCommand createCommand(SqlConnection _conn, string _storedProcedure, Dictionary<string, object> _parameters = null)
        {
            SqlCommand _command = new SqlCommand(_storedProcedure, _conn)
            {
                CommandTimeout = 1800,
                CommandType = CommandType.StoredProcedure
            };
            if (_parameters != null) addSqlParameters(_command, _parameters);
            return _command;
        }

        private void addSqlParameters(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            foreach (var parameter in parameters)
                cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
        }



    }
}
