using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles
{
    /// <summary>
    /// 数据库对象
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// 创建当前数据库对象并进行赋值
        /// </summary>
        /// <param name="dataBaseName">数据库名称</param>
        /// <param name="sqlJoinStr">没有设置数据库的连接字符串例如：Data Source=CZ-20151125CZWL;INITIAL CATALOG={0};integrated Security=true;</param>
        public DataBase(string dataBaseName, string sqlJoinStr)
        {
            //给表集合字段赋值
            this.Tables = new List<Table>();
            //设置数据的名称
            this.DataBaseName = dataBaseName;
            //得到数据库连接字符串
            this.SqlJoin = string.Format(sqlJoinStr, this.DataBaseName);
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DataBaseName { get; private set; }
        /// <summary>
        /// 数据库中的表对象集合
        /// </summary>
        public List<Table> Tables { get; private set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string SqlJoin { get; set; }
        /// <summary>
        /// 得到数据库中的所有表信息
        /// </summary>
        public void GetAllTable()
        {
            //创建数据库连接
            using (SqlConnection sqlConnection = new SqlConnection(this.SqlJoin))
            {
                //打开连接
                sqlConnection.Open();
                //创建执行SQL语句方法
                using (SqlCommand sqlCommand = new SqlCommand("Exec sp_tables;", sqlConnection))
                {
                    //创建获取数据对象
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        //判断是否查询到数据
                        if (sqlReader.HasRows)
                        {
                            //清除表集合中的所有数据
                            this.Tables.Clear();
                            //循环查询数据
                            while (sqlReader.Read())
                            {
                                //判断是否为可用的表
                                if (sqlReader.GetString(3).ToLower() == "table" && sqlReader.GetString(1).ToLower() == "dbo")
                                {
                                    //创建表对象
                                    Table table = new Table(sqlReader.GetString(2), this);
                                    //将表存入集合中
                                    this.Tables.Add(table);
                                }
                            }
                        }
                    }
                }
            }
            //异步获取列与表的主键、唯一键
            ThreadPool.QueueUserWorkItem((a) =>
            {
                //循环调用获取列方法
                foreach (Table table in Tables)
                {
                    //循环调用获取列方法
                    table.GetAllLine();
                }

                //创建数据库连接
                using (SqlConnection sqlConnection = new SqlConnection(this.SqlJoin))
                {
                    //打开连接
                    sqlConnection.Open();

                    #region 得到所有主键
                    //创建执行SQL语句对象
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT tab.name,idx.name,col.name FROM sys.indexes idx JOIN sys.index_columns idxCol ON (idx.object_id = idxCol.object_id AND idx.index_id = idxCol.index_id AND idx.is_primary_key = 1)JOIN sys.tables tab ON (idx.object_id = tab.object_id)JOIN sys.columns col ON (idx.object_id = col.object_id AND idxCol.column_id = col.column_id);", sqlConnection))
                    {
                        //创建获取数据对象
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            //判断是否查询到数据
                            if (sqlReader.HasRows)
                            {
                                //循环获取数据
                                while (sqlReader.Read())
                                {
                                    //得到主键所在的表
                                    string tableName = sqlReader.GetString(0);
                                    //得到主键所在的字段
                                    string lineName = sqlReader.GetString(2);
                                    //循环得到指定的表
                                    foreach (Table table in this.Tables)
                                    {
                                        //判断是否匹配此表
                                        if (table.TableName == tableName)
                                        {
                                            //循环匹配此表的列
                                            foreach (Line line in table.Lines)
                                            {
                                                //判断是否匹配此列
                                                if (line.LineName == lineName)
                                                {
                                                    //将此列存入表的主键列中
                                                    table.PrimaryKey = line;
                                                    //退出循环
                                                    break;
                                                }
                                            }
                                            //退出循环
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    //创建得到所有唯一键对象
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT tab.name,idx.name,col.name FROM sys.indexes idx JOIN sys.index_columns idxCol ON (idx.object_id = idxCol.object_id AND idx.index_id = idxCol.index_id AND idx.is_unique_constraint = 1)JOIN sys.tables tab ON (idx.object_id = tab.object_id) JOIN sys.columns col ON (idx.object_id = col.object_id AND idxCol.column_id = col.column_id);", sqlConnection))
                    {
                        //获取元素
                        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                        {
                            //判断是否加载到数据
                            if (sqlReader.HasRows)
                            {
                                //循环加载数据
                                while (sqlReader.Read())
                                {
                                    //得到表名称
                                    string tableName = sqlReader.GetString(0);
                                    //得到列名称
                                    string lineName = sqlReader.GetString(2);
                                    //循环进行判断此键是哪个表的
                                    foreach (Table table in this.Tables)
                                    {
                                        //判断是否为此表
                                        if (table.TableName == tableName)
                                        {
                                            //循环得到列
                                            foreach (Line line in table.Lines)
                                            {
                                                //判断是否匹配此列
                                                if (line.LineName == lineName)
                                                {
                                                    //将此列存入表的唯一键集合中
                                                    table.UniqueList.Add(line);
                                                    //退出循环
                                                    break;
                                                }
                                            }
                                            //退出循环
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
        /// <summary>
        /// 将当前数据库对象转换成字符串【显示数据库名称】
        /// </summary>
        /// <returns>数据库名称</returns>
        public override string ToString()
        {
            //显示数据库名称
            return this.DataBaseName;
        }
    }
}
