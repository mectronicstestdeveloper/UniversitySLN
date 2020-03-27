using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BackEnd.Data
{
    /// <summary>
    /// <para>Extensiones que permiten alterar los parametros de métodos.</para>
    /// </summary>
    public static class SqlClientExtensions
    {
        /// <summary>
        /// <para>Método extensivo que permite obtner el valor Guid de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>Guid</returns>
        public static Guid GetSqlGuid(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlGuid(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                Guid id = Guid.Empty;
                return id;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor Int de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>Int</returns>
        public static int GetSqlInt32(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlInt32(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor Double  de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>Double</returns>
        public static double GetSqlDouble(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlDouble(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor Decimal de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>Decimal</returns>
        public static decimal GetSqlDecimal(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlDecimal(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor Decimal(Money) de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>Decimal</returns>
        public static decimal GetSqlMoney(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlMoney(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor String de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>String</returns>
        public static string GetSqlString(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlString(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor  de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>Bool</returns>
        public static bool GetSqlBoolean(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetSqlBoolean(reader.GetOrdinal(Column)).Value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// <para>Método extensivo que permite obtner el valor DateTime de un data reader por su alias.</para>
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns>DateTime</returns>
        public static DateTime GetSqlDateTime(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetDateTime(reader.GetOrdinal(Column));
            }
            catch
            {
                DateTime value = new DateTime(0000, 0, 00);
                return value;
            }
        }

        /// <summary>
        /// Método extensivo que permite obtner el valor Date de un data reader por su alias
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns></returns>
        public static DateTime GetDateTime(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetDateTime(reader.GetOrdinal(Column));
            }
            catch
            {
                DateTime value = new DateTime(0000, 0, 00);
                return value;
            }
        }

        /// <summary>
        /// Método extensivo que permite obtner el valor int de un data reader por su alias
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="Column">Alias de la Columna</param>
        /// <returns></returns>
        public static Byte GetByte(this SqlDataReader reader, string Column)
        {
            try
            {
                return reader.GetByte(reader.GetOrdinal(Column));
            }
            catch
            {
                return 0;
            }
        }
    }
}