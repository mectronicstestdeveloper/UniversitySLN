using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BackEnd.Data
{
    public abstract class BaseData : IDisposable
    {
        /// <summary>
        /// <para>Objeto de la conexión a la base de datos.</para>
        /// </summary>
        protected SqlConnection _conn;

        /// <summary>
        /// <para>Cadena de texto con la conexión a la base de datos.</para>
        /// </summary>
        protected string _strConn;

        /// <summary>
        /// <para>Contructor de la clase , donde se inicializan las variables globales.</para>
        /// </summary>
        /// <param name="conn">Objeto de la conexión</param>
        public BaseData(SqlConnection conn)
        {
            this._conn = conn;
            this._strConn = conn.ConnectionString;
        }

        /// <summary>
        /// Metodo que abre la conexión a la base de datos
        /// </summary>
        public void Open()
        {
            this._conn.Open();
        }

        /// <summary>
        /// Método que cierra la conexión de la base de datos
        /// </summary>
        public void Close()
        {
            this._conn.Close();
        }

        /// <summary>
        /// Método que crea la conexión con la base de datos
        /// </summary>
        public void CreateConnection()
        {
            this._conn = new SqlConnection(this._strConn);
        }

        /// <summary>
        /// <para>Método que permite crear el objeto conexión a partir de la cadena de conexión.</para>
        /// </summary>
        /// <returns>DbConnection</returns>
        public DbConnection GetConnection() => new SqlConnection(this._strConn);

        /// <summary>
        /// <para>Atributo que permite verificar si el objeto debe ser cerrado.</para>
        /// </summary>
        /// <returns>Bool</returns>
        private bool disposedValue = false;

        /// <summary>
        /// <para>Método que permite cerrar la instacia del objeto y por ende las conexiones.</para>
        /// </summary>
        /// <param name="disposing">Variable para saber si debe ser cerrado</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Close();
                    this._conn.Dispose();
                }
                this._conn = null;
                disposedValue = true;
            }
        }

        /// <summary>
        /// <para>Método para cerrar la instacina del objeto.</para>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}