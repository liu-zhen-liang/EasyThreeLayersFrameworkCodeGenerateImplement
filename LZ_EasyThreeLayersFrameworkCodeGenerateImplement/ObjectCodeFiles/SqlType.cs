using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles
{
    /// <summary>
    /// 数据库转C#类型
    /// </summary>
    public class SqlType
    {
        /// <summary>
        /// 在数据库中的类型
        /// </summary>
        public string SqlTypeString { get; set; }
        /// <summary>
        /// 在数据库中的长度
        /// </summary>
        public int SqlLength { get; set; }
        /// <summary>
        /// 数据库参数枚举
        /// </summary>
        public SqlDbType SqlTypeEnum { get; set; }
        /// <summary>
        /// 在数据库中是否可以为空
        /// </summary>
        public bool SqlIsNull { get; set; }
        /// <summary>
        /// 在C#中的类型字符串
        /// </summary>
        public string CShapTypeString { get; set; }
        /// <summary>
        /// 在C#中的类型
        /// </summary>
        public Type CShapType { get; set; }
        /// <summary>
        /// 在C#中是否可以为空？
        /// </summary>
        public bool CShapIsNull { get; set; }
        /// <summary>
        /// 在C#默认的值字符串例如：byte[] 他的默认是：new byte[0]
        /// </summary>
        public string CShapAcquiesceIn { get; set; }
        /// <summary>
        /// 存储在C#中获取当前类型元素搜用的获取方法例如：int 用：GetInt32
        /// </summary>
        public string CShapGetDataTypeMethodName { get; set; }
        /// <summary>
        /// 传入在数据库中的类型字符串
        /// </summary>
        /// <param name="sqlTypeString">在数据库中类型的字符串</param>
        /// <param name="length">在数据库中的长度</param>
        /// <param name="isNull">在sql中是否可以为空</param>
        /// <returns>数据库类型对象</returns>
        public static SqlType GetSqlType(string sqlTypeString, int length, bool isNull)
        {
            //创建数据库类型对象
            SqlType sqlType = new SqlType();
            //设置长度
            sqlType.SqlLength = length;
            //设置在sql中是否可以为空
            sqlType.SqlIsNull = isNull;
            //得到类型字符串【去除前面后面空白后转换成小写】
            sqlType.SqlTypeString = sqlTypeString.Trim().ToLower();

            #region 判断是哪个类型，并设置其内容
            switch (sqlType.SqlTypeString)
            {
                case "bigint"://long
                    #region long
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "long";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(long);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "long?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(long?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0L";
                    #endregion
                    break;
                case "int"://int
                    #region int
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "int";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(int);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "int?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(int?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0";
                    #endregion
                    break;
                case "smallint"://short
                    #region short
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "short";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(short);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "short?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(short?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0";
                    #endregion
                    break;
                case "tinyint"://byte
                    #region byte
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "byte";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(byte);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "byte?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(byte?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0";
                    #endregion
                    break;
                case "bit"://bool
                    #region bool
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "bool";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(bool);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "bool?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(bool?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "false";
                    #endregion
                    break;
                case "decimal"://decimal
                case "numeric"://decimal
                case "money"://decimal
                case "smallmoney"://decimal
                    #region decimal
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "decimal";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(decimal);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "decimal?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(decimal?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0m";
                    #endregion
                    break;
                case "float"://double
                    #region double
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "double";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(double);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "double?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(double?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0d";
                    #endregion
                    break;
                case "real"://float
                    #region float
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "float";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(float);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "float?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(float?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "0f";
                    #endregion
                    break;
                case "datetime"://DateTime
                case "smalldatetime"://DateTime
                case "date"://DateTime
                    #region DateTime
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "DateTime";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(DateTime);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "DateTime?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(DateTime?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "new DateTime()";
                    #endregion
                    break;
                case "char"://string
                case "nchar"://string
                case "varchar"://string
                case "nvarchar"://string
                case "text"://string
                case "ntext"://string
                    #region string
                    //设置在C#中对应的类型字符串
                    sqlType.CShapTypeString = "string";
                    //设置在C#中对应的类型
                    sqlType.CShapType = typeof(string);
                    //设置在C#中此类型是否可以为空【引用类型】
                    sqlType.CShapIsNull = true;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "string.Empty";
                    #endregion
                    break;
                case "binary"://byte[]
                case "varbinary"://byte[]
                case "image"://byte[]
                case "timestamp"://byte[]
                    #region byte[]
                    //设置在C#中对应的类型字符串
                    sqlType.CShapTypeString = "byte[]";
                    //设置在C#中对应的类型
                    sqlType.CShapType = typeof(byte[]);
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = true;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "new byte[0]";
                    #endregion
                    break;
                case "uniqueidentifier"://Guid
                    #region Guid
                    //判断在sql中是否可以为空
                    if (!isNull)//进入代表不能为空
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "Guid";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(Guid);
                    }
                    else
                    {
                        //设置在C#中对应的类型字符串
                        sqlType.CShapTypeString = "Guid?";
                        //设置在C#中对应的类型
                        sqlType.CShapType = typeof(Guid?);
                    }
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = isNull;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "new Guid()";
                    #endregion
                    break;
                case "Variant"://object
                    #region object
                    //设置在C#中对应的类型字符串
                    sqlType.CShapTypeString = "object";
                    //设置在C#中对应的类型
                    sqlType.CShapType = typeof(object);
                    //设置在C#中此类型是否可以为空【如果在数据库可以为空就为空否则就不为空】【值类型】
                    sqlType.CShapIsNull = true;
                    //设置此类型在C#中默认的值字符串
                    sqlType.CShapAcquiesceIn = "new object()";
                    #endregion
                    break;
            } 
            #endregion

            #region 设置对应的数据库类型枚举
            switch (sqlType.SqlTypeString)
            {
                case "bigint":
                    sqlType.SqlTypeEnum = SqlDbType.BigInt;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetInt64";
                    break;
                case "int":
                    sqlType.SqlTypeEnum = SqlDbType.Int;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetInt32";
                    break;
                case "smallint":
                    sqlType.SqlTypeEnum = SqlDbType.SmallInt;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetInt16";
                    break;
                case "tinyint":
                    sqlType.SqlTypeEnum = SqlDbType.TinyInt;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetByte";
                    break;
                case "bit":
                    sqlType.SqlTypeEnum = SqlDbType.Bit;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetBoolean";
                    break;
                case "decimal":
                    sqlType.SqlTypeEnum = SqlDbType.Decimal;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDecimal";
                    break;
                case "numeric":
                    sqlType.SqlTypeEnum = SqlDbType.Decimal;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDecimal";
                    break;
                case "money":
                    sqlType.SqlTypeEnum = SqlDbType.Money;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDecimal";
                    break;
                case "smallmoney":
                    sqlType.SqlTypeEnum = SqlDbType.SmallMoney;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDecimal";
                    break;
                case "float":
                    sqlType.SqlTypeEnum = SqlDbType.Float;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDouble";
                    break;
                case "real":
                    sqlType.SqlTypeEnum = SqlDbType.Real;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetFloat";
                    break;
                case "datetime":
                    sqlType.SqlTypeEnum = SqlDbType.DateTime;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDateTime";
                    break;
                case "smalldatetime":
                    sqlType.SqlTypeEnum = SqlDbType.SmallDateTime;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDateTime";
                    break;
                case "date":
                    sqlType.SqlTypeEnum = SqlDbType.Date;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetDateTime";
                    break;
                case "timestamp":
                    sqlType.SqlTypeEnum = SqlDbType.Timestamp;
                    //获取数据方法【没有此方法要进行处理才能用！！！】【作为标识存在】
                    sqlType.CShapGetDataTypeMethodName = "Byte[]";
                    break;
                case "char":
                    sqlType.SqlTypeEnum = SqlDbType.Char;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetString";
                    break;
                case "nchar":
                    sqlType.SqlTypeEnum = SqlDbType.NChar;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetString";
                    break;
                case "varchar":
                    sqlType.SqlTypeEnum = SqlDbType.VarChar;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetString";
                    break;
                case "nvarchar":
                    sqlType.SqlTypeEnum = SqlDbType.NVarChar;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetString";
                    break;
                case "text":
                    sqlType.SqlTypeEnum = SqlDbType.Text;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetString";
                    break;
                case "ntext":
                    sqlType.SqlTypeEnum = SqlDbType.NText;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetString";
                    break;
                case "binary":
                    sqlType.SqlTypeEnum = SqlDbType.Binary;
                    //获取数据方法【没有此方法要进行处理才能用！！！】【作为标识存在】
                    sqlType.CShapGetDataTypeMethodName = "Byte[]";
                    break;
                case "varbinary":
                    sqlType.SqlTypeEnum = SqlDbType.VarBinary;
                    //获取数据方法【没有此方法要进行处理才能用！！！】【作为标识存在】
                    sqlType.CShapGetDataTypeMethodName = "Byte[]";
                    break;
                case "image":
                    sqlType.SqlTypeEnum = SqlDbType.Image;
                    //获取数据方法【没有此方法要进行处理才能用！！！】【作为标识存在】
                    sqlType.CShapGetDataTypeMethodName = "Byte[]";
                    break;
                case "uniqueidentifier":
                    sqlType.SqlTypeEnum = SqlDbType.UniqueIdentifier;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetGuid";
                    break;
                case "Variant":
                    sqlType.SqlTypeEnum = SqlDbType.Variant;
                    //获取数据方法
                    sqlType.CShapGetDataTypeMethodName = "GetValue";
                    break;
            }  
            #endregion
            
            //返回设置好的数据库类型
            return sqlType;
        }
    }
}
