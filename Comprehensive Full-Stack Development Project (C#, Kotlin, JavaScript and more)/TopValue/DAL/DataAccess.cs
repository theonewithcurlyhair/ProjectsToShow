using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Types.Types;

namespace DAL
{
    public class DataAccess
    {
        public DataTable Execute(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            int retVal;

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                retVal = cmd.ExecuteNonQuery();
                UnloadParms(parms, cmd);
            }

            return retVal;
        }

        /// <summary>
        /// returns object, which I can use in many ways (parsing into different datatypes)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public object ExecuteScaler(string sql, CommandType cmdType, List<ParmStruct> parms = null)
        {
            SqlCommand cmd = CreateCommand(sql, cmdType, parms);
            cmd.Connection.Open();
            object retVal = cmd.ExecuteScalar();
            UnloadParms(parms, cmd);
            cmd.Connection.Close();
            return retVal;
        }

        private SqlCommand CreateCommand(string cmdText, CommandType cmdType, List<ParmStruct> parms)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings1.Default.cnnString);

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;

            if (parms != null)
            {
                foreach (ParmStruct p in parms)
                {
                    cmd.Parameters.Add(new SqlParameter(p.Name,
                        p.DataType, p.Size));
                    cmd.Parameters[p.Name].Value = p.Value;
                    cmd.Parameters[p.Name].Direction = p.Direction;
                }
            }

            return cmd;
        }
        private void UnloadParms(List<ParmStruct> parms, SqlCommand cmd)
        {
            if (parms != null)
            {
                for (int i = 0; i <= parms.Count - 1; i++)
                {
                    ParmStruct p = parms[i];
                    p.Value = cmd.Parameters[i].Value;
                    parms[i] = p;
                }
            }
        }
    }
}
