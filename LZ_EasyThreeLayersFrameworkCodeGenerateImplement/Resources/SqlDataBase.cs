using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 要被替换的命名空间
{
    /// <summary>连接数据库的对象
    /// 
    /// </summary>
    public static class SqlDataBase
    {
        //SQL连接字符串【记得引用程序集System.Configuration】
        private readonly static string SqlJoinString = ConfigurationManager.ConnectionStrings["SqlJoin"].ConnectionString;
        /// <summary>执行对数据库进行（增、删、改）方法
        /// 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pmr">sql变量的内容</param>
        /// <returns>所影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pmr)
        {
            //创建连接数据库对象
            using (SqlConnection con = new SqlConnection(SqlDataBase.SqlJoinString))
            {
                //执行sql语句方法
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //判断传入的变量数组是否为空
                    if (pmr != null)
                    {
                        //将变量存入SqlCommand对象中
                        cmd.Parameters.AddRange(pmr);
                    }
                    //打开数据库的连接
                    con.Open();
                    //判断是否抛出异常
                    try
                    {
                        //执行语句
                        return cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        //返回-1
                        return -1;
                    }
                }
            }
        }
        /// <summary>执行只返回单个参数的方法
        /// 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pmr">sql变量的内容</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] pmr)
        {
            //创建连接数据库的对象
            using (SqlConnection con = new SqlConnection(SqlDataBase.SqlJoinString))
            {
                //创建执行sql语句的对象
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //判断sql变量是否为空
                    if (pmr != null)
                    {
                        //将sql变量存入执行sql语句的对象中
                        cmd.Parameters.AddRange(pmr);
                    }
                    //打开数据库连接
                    con.Open();
                    //执行sql语句
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>执行返回多个参数的方法
        /// 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pmr">sql变量数组</param>
        /// <returns>返回的SqlDataReader对象</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pmr)
        {
            //创建连接数据库的对象
            //防止SqlConnection对象自动执行Clone()、Dispose()方法来释放资源后
            //返回的SqlDataReader对象访问不到数据了
            //配合cmd.ExecuteReader()方法中的枚举解决此问题
            SqlConnection con = new SqlConnection(SqlDataBase.SqlJoinString);
            //创建执行sql语句的对象
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                //判断传入的sql变量是否为空
                if (pmr != null)
                {
                    //将sql变量存入SqlCommand对象中
                    cmd.Parameters.AddRange(pmr);
                }
                //打开数据连接
                con.Open();
                try
                {
                    //返回SqlDataReader对象,括号中的枚举参数是为了保证用完此SqlDataReader对象后自动执行
                    //Clone()、Dispose()方法来释放SqlConnection对象的资源
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    //释放资源
                    cmd.Clone();
                    cmd.Dispose();
                    //把异常继续往上抛出
                    throw;
                }
            }
        }
        /// <summary>查询数据返回DataTable对象
        /// 
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="pms">sql变量</param>
        /// <returns>DataTable对象</returns>
        public static DataTable ExecuteDtaaTable(string sql, params SqlParameter[] pms)
        {
            //创建一个DataTable对象来存储查找出来的表
            DataTable dt = new DataTable();
            //窗SqlDataAdapter对象查找数据库
            using (SqlDataAdapter asapter = new SqlDataAdapter(sql, SqlDataBase.SqlJoinString))
            {
                //判断传入的sql变量是否为空
                if (pms != null)
                {
                    //将sql变量存储到SqlDataAdapter对象中
                    asapter.SelectCommand.Parameters.AddRange(pms);
                }
                //获取数据库的值并将值存储到DataTable对象中
                asapter.Fill(dt);
            }
            //将表对象返回
            return dt;
        }
		/// <summary>
        /// 进行浅拷贝SQL参数对象
        /// </summary>
        /// <param name="sqlParameters">要被拷贝的SQL参数对象数组</param>
        /// <returns>拷贝完成的SQL参数数组</returns>
        public static SqlParameter[] CopySqlParameters(SqlParameter[] sqlParameters)
        {
            //判断传入参数数组是否为null，或者元素数量为零
            if (sqlParameters == null || sqlParameters.Length == 0) return new SqlParameter[0];
            //创建存储复制内容的数组
            SqlParameter[] sqlParametersCopy = new SqlParameter[sqlParameters.Length];
            //循环复制
            for (int i = 0; i < sqlParameters.Length; i++)
            {
                //得到要被复制的SQL参数对象
                SqlParameter sqlParameter = sqlParameters[i];
                //存储复制的SQL参数对象
                SqlParameter sqlParameterCopy = new SqlParameter();
                //赋值
                sqlParameterCopy.CompareInfo = sqlParameter.CompareInfo;
                sqlParameterCopy.DbType = sqlParameter.DbType;
                sqlParameterCopy.Direction = sqlParameter.Direction;
                sqlParameterCopy.IsNullable = sqlParameter.IsNullable;
                sqlParameterCopy.LocaleId = sqlParameter.LocaleId;
                sqlParameterCopy.Offset = sqlParameter.Offset;
                sqlParameterCopy.ParameterName = sqlParameter.ParameterName;
                sqlParameterCopy.Precision = sqlParameter.Precision;
                sqlParameterCopy.Scale = sqlParameter.Scale;
                sqlParameterCopy.Size = sqlParameter.Size;
                sqlParameterCopy.SourceColumn = sqlParameter.SourceColumn;
                sqlParameterCopy.SourceColumnNullMapping = sqlParameter.SourceColumnNullMapping;
                sqlParameterCopy.SourceVersion = sqlParameter.SourceVersion;
                sqlParameterCopy.SqlDbType = sqlParameter.SqlDbType;
                sqlParameterCopy.SqlValue = sqlParameter.SqlValue;
                sqlParameterCopy.TypeName = sqlParameter.TypeName;
                sqlParameterCopy.UdtTypeName = sqlParameter.UdtTypeName;
                sqlParameterCopy.Value = sqlParameter.Value;
                sqlParameterCopy.XmlSchemaCollectionDatabase = sqlParameter.XmlSchemaCollectionDatabase;
                sqlParameterCopy.XmlSchemaCollectionName = sqlParameter.XmlSchemaCollectionName;
                sqlParameterCopy.XmlSchemaCollectionOwningSchema = sqlParameter.XmlSchemaCollectionOwningSchema;
                //将当前对象存入
                sqlParametersCopy[i] = sqlParameterCopy;
            }
            //返回结果
            return sqlParametersCopy;
        }
    }
}
