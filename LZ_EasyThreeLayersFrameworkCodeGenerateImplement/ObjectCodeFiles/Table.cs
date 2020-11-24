using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles
{
    /// <summary>
    /// 表对象
    /// </summary>
    public class Table
    {
        /// <summary>
        /// 创建当前表对象并进行赋值
        /// </summary>
        /// <param name="tableName">表对象名称</param>
        public Table(string tableName, DataBase dateBase)
        {
            //给当前列对象集合进行赋值
            this.Lines = new List<Line>();
            //赋值
            this.TableName = tableName;
            //设置表注释就是表名称
            this.TableNote = tableName;
            //赋值父数据库
            this.FathertDataBase = dateBase;
            //给要移除的列前缀默认赋值为空
            this.LineRemovePrefix = string.Empty;
            //设置集合内容
            this.UniqueList = new List<Line>();
        }
        /// <summary>
        /// 表名称【在数据库中的原表名称，没有进行处理！！！】
        /// </summary>
        public string TableName { get; private set; }
        /// <summary>
        /// 当前表在代码中的名称【去掉前缀后的结果】
        /// </summary>
        public string TableCodeName { get; set; }
        /// <summary>
        /// 表注释
        /// </summary>
        public string TableNote { get; set; }
        /// <summary>
        /// 列对象集合
        /// </summary>
        public List<Line> Lines { get; private set; }
        /// <summary>
        /// 父数据库对象
        /// </summary>
        public DataBase FathertDataBase { get; private set; }
        /// <summary>
        /// 当前表在数据模型层中的类名称例如：UserIdentityMod
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 当前表在数据模型层对象创建的私有变量名称例如：userIdentityMod
        /// </summary>
        public string PrivateModelName
        {
            get { return Tool.FirstLetterLower(this.ModelName); }
        }
        /// <summary>
        /// 当前表在数据存储层中的类名称例如：UserIdentityDal
        /// </summary>
        public string DalName { get; set; }
        /// <summary>
        /// 当前表在数据存储层对象创建的私有变量名称：例如：userIdentityDal
        /// </summary>
        public string PrivateDalName
        {
            get { return Tool.FirstLetterLower(this.DalName); }
        }
        /// <summary>
        /// 当前表在业务逻辑层中的类名称例如：UserIdentityBll
        /// </summary>
        public string BllName { get; set; }
        /// <summary>
        /// 当前表在业务逻辑层对象创建的私有变量名称：例如：userIdentityBll
        /// </summary>
        public string PrivateBllName
        {
            get { return Tool.FirstLetterLower(this.BllName); }
        }
        //存储列移除的前缀字符串【默认为空】
        private string _lineRemovePrefix;
        /// <summary>
        /// 列移除的前缀字符串【默认为空】
        /// </summary>
        public string LineRemovePrefix
        {
            get
            {
                //返回
                return this._lineRemovePrefix;
            }
            set
            {
                //循环进行设置值
                foreach (Line line in this.Lines)
                {
                    //得到其代码名称
                    line.LineCodeName = Tool.RemovePrefix(line.LineName, value, false);
                }
                //存入值
                this._lineRemovePrefix = value;
            }
        }
        /// <summary>
        /// 主键列，如果没有主键就是null
        /// </summary>
        public Line PrimaryKey { get; set; }
        /// <summary>
        /// 当前表的唯一键集合默认其中元素为0
        /// </summary>
        public List<Line> UniqueList { get; set; }
        /// <summary>
        /// 得到当前表的所有列的字段集合的查询属性列用于Select语句
        /// 例如：uiID,uName
        /// </summary>
        /// <returns>例如：uiID,uName</returns>
        public string GetSqlParameter()
        {
            //创建存储连接字符串的对象
            StringBuilder sqlBuilder = new StringBuilder();
            //循环进行连接处理
            foreach (Line line in this.Lines)
            {
                //进行连接处理
                sqlBuilder.Append(line.LineCodeName);
                //加入逗号
                sqlBuilder.Append(',');
            }
            //判断最后一个是否为逗号
            if (sqlBuilder[sqlBuilder.Length - 1] == ',')
            {
                //移除这个逗号
                sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            }
            //返回字符串
            return sqlBuilder.ToString();
        }
        /// <summary>
        /// 获取所有列数据
        /// </summary>
        public void GetAllLine()
        {
            //创建数据库连接
            using (SqlConnection sqlConnection = new SqlConnection(this.FathertDataBase.SqlJoin))
            {
                //打开连接
                sqlConnection.Open();
                //得到列名称
                using (SqlCommand sqlCommand = new SqlCommand("exec sp_columns '" + this.TableName + "';", sqlConnection))
                {
                    //创建获取元素对象
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        //判断是否获取到元素
                        if (sqlReader.HasRows)
                        {
                            //移除所有元素
                            this.Lines.Clear();
                            //循环获取元素
                            while (sqlReader.Read())
                            {
                                //创建列对象
                                Line line = new Line(sqlReader.GetString(3), this);
                                //得到列类型
                                string lineType = sqlReader.GetString(5);
                                //将类型进行分割【因为：自动增长的类型是：[类型] identity 例如：int identity】
                                string[] linStrings = lineType.Split(new char[]
                                {
                                    ' '
                                }, StringSplitOptions.RemoveEmptyEntries);
                                //判断是否有两个元素并且第二个元素为identity，就填写自动编号
                                line.IsAutomaticIncrease = (linStrings.Length > 1 &&
                                                            linStrings[1].Trim().ToLower() == "identity");
                                //调用设置类型
                                line.Type = SqlType.GetSqlType(linStrings[0], sqlReader.GetInt32(7),
                                    (sqlReader.GetString(17).ToLower() != "no"));

                                //将序号存入
                                line.SerialNumber = sqlReader.GetInt32(16);
                                //将小数存入
                                line.Decimals = sqlReader.IsDBNull(8) ? 0 : sqlReader.GetInt16(8);
                                //将默认值存入
                                line.DefaultValue = sqlReader.IsDBNull(12) ? null : sqlReader.GetString(12);
                                //将说明存入
                                line.Explain = sqlReader.IsDBNull(11) ? null : sqlReader.GetString(11);
                                //将列存入
                                this.Lines.Add(line);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 将当前对象转换成字符串形式的副本【显示表名称】
        /// </summary>
        /// <returns>表名称</returns>
        public override string ToString()
        {
            //显示表名称
            return this.TableName;
        }
        /// <summary>
        /// 将当前对象转换成ListViewItem对象
        /// </summary>
        /// <returns>转换完成的ListViewItem项</returns>
        public ListViewItem ToListViewItem()
        {
            //创建要进行返回的ListViewItem对象并赋值
            ListViewItem lvi = new ListViewItem(new string[]
            {
                //将表名称存入
                this.TableName,
                //将表注释存入
                this.TableNote
            });
            //将当前对象存入当前项
            lvi.Tag = this;
            //返回当前项
            return lvi;
        }
        /// <summary>
        /// 将当前对象转换成ListViewItem对象【选择移除列前缀】
        /// </summary>
        /// <returns>转换完成ListViewItem对象【选择移除列前缀】</returns>
        public ListViewItem ToLineRemovePrefixListViewItem()
        {
            //创建要进行返回的ListViewItem对象并赋值
            ListViewItem lvi = new ListViewItem(new string[]
            {
                //将表名称存入
                this.TableName,
                //移除前缀字符串
                this.LineRemovePrefix
            });
            //将当前对象存入当前项
            lvi.Tag = this;
            //返回当前项
            return lvi;
        }
        /// <summary>
        /// 获取到当前表对象中所有在SQL中设置了不能为空的列对象
        /// </summary>
        /// <returns>不能为空的列对象集合</returns>
        public List<Line> GetNotNullLines()
        {
            //创建存储不能为空的列对象集合
            List<Line> lines = new List<Line>();
            //循环遍历判断是否有不能为空的列
            foreach (Line line in this.Lines)
            {
                //判断他的类型在sql是否设置了不能为空
                if (!line.Type.SqlIsNull)
                    //将列对象存入
                    lines.Add(line);
            }
            //返回列对象
            return lines;
        }
        /// <summary>
        /// 获取当前表的获取所有元素【无条件】的代码【生成的SQL代码不加“;”分号的！】
        /// </summary>
        /// <returns>获取所有元素【无条件】</returns>
        public string GetSqlSelectCode()
        {
            //创建存储数据的字符串对象
            StringBuilder codeBuilder = new StringBuilder();
            //存储头
            codeBuilder.Append("Select ");
            //循环将所有列存入
            foreach (Line line in this.Lines)
            {
                codeBuilder.Append(line.LineName + ",");
            }
            //移除最后一个逗号【一般都有至少一个列】
            codeBuilder.Remove(codeBuilder.Length - 1, 1);
            //存入From语句
            codeBuilder.Append(" From ");
            //将表名称存入
            codeBuilder.Append(this.TableName);
            //返回生成代码
            return codeBuilder.ToString();
        }
        /// <summary>
        /// 按照指定的列来获取元素
        /// </summary>
        /// <param name="whereLine">条件列</param>
        /// <returns>获取元素【有条件】</returns>
        public string GetSqlSelectCode(Line whereLine)
        {
            //创建存储数据的字符串对象
            StringBuilder codeBuilder = new StringBuilder();
            //存储头
            codeBuilder.Append("Select Top 1 ");
            //循环将所有列存入
            foreach (Line line in this.Lines)
            {
                codeBuilder.Append(line.LineName + ",");
            }
            //移除最后一个逗号【一般都有至少一个列】
            codeBuilder.Remove(codeBuilder.Length - 1, 1);
            //存入From语句
            codeBuilder.Append(" From ");
            //将表名称存入
            codeBuilder.Append(this.TableName);
            //将条件存入
            codeBuilder.AppendFormat(" Where {0} = {1};", whereLine.LineName, whereLine.SqlVariableName);
            //返回结果
            return codeBuilder.ToString();
        }
        /// <summary>
        /// 生成当前表按照条件获取数量的方法
        /// </summary>
        /// <param name="lines">条件列集合</param>
        /// <returns>生成的SQL语句字符串</returns>
        public string GetSqlCountCode(List<Line> lines)
        {
            //创建存储SQL语句的字符串对象
            StringBuilder codeBuilder = new StringBuilder();
            //存储头
            codeBuilder.AppendFormat("Select Count(*) From {0} Where ", this.TableName);
            //循环存入条件
            for (int i = 0; i < lines.Count; i++)
            {
                //得到当前列对象
                Line line = lines[i];
                //存入当前条件
                codeBuilder.AppendFormat("{0} = {1}", line.LineName, line.SqlVariableName);
                //判断是否是最后一个如果是就不存入And直接存入;
                if (i != lines.Count - 1)
                {
                    //存入“ And ”
                    codeBuilder.Append(" And ");
                }
                else
                {
                    //存入分号
                    codeBuilder.Append(';');
                }
            }
            //返回SQL语句
            return codeBuilder.ToString();
        }
        /// <summary>
        /// 根据传入的自动编号列与非自动编号列生成SQL插入语句
        /// </summary>
        /// <param name="identityLines">自动编号列对象集合</param>
        /// <param name="notIdentityLines">非自动编号列对象集合</param>
        /// <returns>SQL插入语句</returns>
        public string GetSqlAddDataCode(List<Line> identityLines, List<Line> notIdentityLines)
        {
            //创建存储SQL插入语句的字符串
            StringBuilder codeBuilder = new StringBuilder();
            //存入插入头
            codeBuilder.AppendFormat("Insert Into {0}(", this.TableName);
            //循环将非自动编号元素存入
            for (int i = 0; i < notIdentityLines.Count; i++)
            {
                //将元素存入
                codeBuilder.Append(notIdentityLines[i].LineName);
                //判断是否到最后面了？，如果不是就存入逗号
                if (i != notIdentityLines.Count - 1)
                {
                    //存入逗号
                    codeBuilder.Append(',');
                }
            }
            //存入回括号
            codeBuilder.Append(") ");
            //判断是否为自动编号的元素，如果有就进行用OutPut
            if (identityLines != null && identityLines.Count > 0)
            {
                #region 插入返回值
                //存入OutPut
                codeBuilder.Append("OutPut ");
                //循环存入要进行返回的值
                for (int i = 0; i < identityLines.Count; i++)
                {
                    //将元素加入
                    codeBuilder.Append("Inserted." + identityLines[i].LineName);
                    //判断是否为最后一个元素
                    if (i != identityLines.Count - 1)
                    {
                        //存入“,”逗号
                        codeBuilder.Append(", ");
                    }
                    else
                    {
                        //存入空格
                        codeBuilder.Append(' ');
                    }
                }
                #endregion
            }
            //存入插入开始
            codeBuilder.Append("Values(");
            //循环将不是自动编号的值作为SQL参数存入
            for (int i = 0; i < notIdentityLines.Count; i++)
            {
                //将元素存入【例如：@id】
                codeBuilder.Append(notIdentityLines[i].SqlVariableName);
                //判断是否到最后面了？，如果不是就存入逗号
                if (i != notIdentityLines.Count - 1)
                {
                    //存入逗号
                    codeBuilder.Append(',');
                }
            }
            //加入“);”
            codeBuilder.Append(");");
            //返回完成的值
            return codeBuilder.ToString();
        }
        /// <summary>
        /// 获取当前表对象中所有自动编号列对象集合
        /// </summary>
        /// <returns>自动编号列对象集合</returns>
        public List<Line> GetIdentityLines()
        {
            //创建集合存储字段编号的值
            List<Line> list = new List<Line>();
            //循环当前列对象
            foreach (Line line in this.Lines)
            {
                //判断是否是字典增长的列，如果是就存入
                if (line.IsAutomaticIncrease)
                    //将当前列存入集合
                    list.Add(line);
            }
            //返回集合
            return list;
        }
        /// <summary>
        /// 获取当前表对象中所有不是自动编号列对象集合
        /// </summary>
        /// <returns>不是自动编号列对象集合</returns>
        public List<Line> GetNotIdentityLines()
        {
            //创建集合存储字段编号的值
            List<Line> list = new List<Line>();
            //循环当前列对象
            foreach (Line line in this.Lines)
            {
                //判断是否不是字典增长的列，如果不是就存入
                if (!line.IsAutomaticIncrease)
                    //将当前列存入集合
                    list.Add(line);
            }
            //返回集合
            return list;
        }
        /// <summary>
        /// 根据主键生成修改SQL代码
        /// </summary>
        /// <returns>生成的SQL修改代码</returns>
        public string GetSqlPrimaryKeyUpdateCode()
        {
            //判断主键是否为空？
            if (this.PrimaryKey == null) return "无主键请自定义修改SQL语句！！！";
            //创建存储语句的字符串对象
            StringBuilder codeBuilder = new StringBuilder();
            //存入修改开始与表名称
            codeBuilder.Append("Update " + this.TableName + " Set ");
            //循环存入要进行修改的元素
            for (int i = 0; i < this.Lines.Count; i++)
            {
                //得到当前列
                Line line = this.Lines[i];
                //判断是否不为主键【主键不用进行修改！】
                if (line.LineName != this.PrimaryKey.LineName)
                {
                    //生成列并存入例如：uName = @uName
                    codeBuilder.AppendFormat("{0} = {1}", line.LineName, line.SqlVariableName);
                    //判断是否为最后一个如果是就不存入逗号“,”否则就存入
                    if (i != this.Lines.Count - 1)
                    {
                        //存入逗号
                        codeBuilder.Append(",");
                    }
                }
            }
            //存入条件
            codeBuilder.AppendFormat(" Where {0} = {1};", this.PrimaryKey.LineName, this.PrimaryKey.SqlVariableName);
            //返回修改语句
            return codeBuilder.ToString();
        }
    }
}
