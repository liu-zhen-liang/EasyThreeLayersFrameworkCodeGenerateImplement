using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Policy;
using System.Text;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.CreateCode.CreateMVC
{
    /// <summary>
    /// 生成简单三层架构数据访问对象类
    /// </summary>
    public class MvcDalObject
    {
        /// <summary>
        /// 要进行生成的表
        /// </summary>
        private readonly Table _table;
        /// <summary>
        /// 存储设置的对象
        /// </summary>
        private readonly MvcSetObject _mvcSetObject;
        /// <summary>
        /// 创建当前要生成的简单三层架构数据访问层对象
        /// </summary>
        /// <param name="tabe">要进行生成的表集合</param>
        /// <param name="mvcSet">MVC生成设置</param>
        public MvcDalObject(Table tabe, MvcSetObject mvcSet)
        {
            //进行赋值
            this._table = tabe;
            this._mvcSetObject = mvcSet;
        }
        /// <summary>
        /// 生成简单三层架构数据访问层对象代码方法
        /// </summary>
        /// <returns>简单三层架构数据访问层类代码字符串</returns>
        public string CreateMvcDalClassCode()
        {
            //创建存储简单三层架构数据访问层代码的字符串对象
            StringBuilder code = new StringBuilder();
            //将命名空间存入
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using System.Data.SqlClient;");
            code.AppendLine("using System.Linq;");
            code.AppendLine("using System.Net.Configuration;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using " + this._mvcSetObject.Namespace + ".Model;");
            code.AppendLine();
            //命名空间
            code.AppendLine("namespace " + this._mvcSetObject.Namespace + ".DAL");
            code.AppendLine("{");
            //类注释
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + this._table.TableNote + "数据访问对象");
            code.AppendLine("    /// </summary>");
            code.AppendLine("    public partial class " + this._table.DalName);
            code.AppendLine("    {");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 实例化" + this._table.TableNote + "数据访问对象");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public " + this._table.DalName + "()");
            code.AppendLine("        {");
            code.AppendLine("            ");
            code.AppendLine("        }");
            //调用生成简单三层架构数据访问类代码的方法
            this.CreateMvcDalFunction(code);

            //类回括号
            code.AppendLine("    }");
            //命名空间回括号
            code.AppendLine("}");
            //返回内容
            return code.ToString();
        }
        /// <summary>
        /// 生成简单三层架构数据访问类方法代码的方法
        /// </summary>
        /// <param name="code">存储生成的代码的字符串对象</param>
        private void CreateMvcDalFunction(StringBuilder code)
        {
            //调用生成获取所有数据方法的代码的方法
            this.CreateGetAllData(code);
            //调用生成添加方法代码的方法
            this.CreateAddData(code);
            //判断是否有主键，如果没有就不生成
            if (this._table.PrimaryKey != null)
            {
                //调用按照键生成代码方法并将主键存入，和注释存入【GetModel】
                this.CreateKeyGetData(code, this._table.PrimaryKey, ("根据主键获取一条记录返回一个" + this._table.TableNote + "数据模型对象"), "GetModel");
                //调用按照键生成删除语句的方法，将主键与注释存入【Delete】
                this.CreateKeyDelete(code, this._table.PrimaryKey, ("根据主键删除一条记录"), "Delete");
                //调用生成判断是否有此记录方法代码的方法【Exists】
                this.CreateExists(code, this._table.PrimaryKey, "判断是否有此主键对应的记录", "Exists");
            }
            //循环给当前表的唯一键创建查询
            foreach (Line line in this._table.UniqueList)
            {
                //调用按照键生成代码方法将唯一键存入和注释存入【GetModel】
                this.CreateKeyGetData(code, line, ("根据" + line.LineNote + "获取一条记录"), ("Get" + line.PublicAttributeName + "CorrespondingModel"));
                //调用根据键生产厂删除语句方法的代码的方法，并将唯一键和注释存入【Delete】
                this.CreateKeyDelete(code, line, ("删除" + line.LineNote + "所对应的一条记录"), ("Delete" + line.PublicAttributeName + "CorrespondingTakeNotes"));
                //调用生成判断是否有此记录方法代码的方法【Exists】
                this.CreateExists(code, line, ("判断是否存在此" + line.LineNote + "对应的记录"), ("ExistsThis" + line.PublicAttributeName));
            }
            //判断是否有一个以上的列，如果只有一个列就不生成修改方法【会出错！】
            if (this._table.Lines.Count > 1)
            {
                //调用生成按照主键修改代码的方法
                this.CreateUpdate(code);
            }
            //调用生成判断是否有这个记录方法的代码的方法
            this.CreateExists(code);
            //调用生成自定义自定义判断是否有此记录方法
            this.CreateDiyExists(code);
            //调用生成自定义删除方法代码的方法
            this.CreateDiyDelete(code);
            //调用生成自定义查询方法代码的方法
            this.CreateDiyGetData(code);
            //调用生成自定义查询记录数量方法代码的方法
            this.CreateDivGetCount(code);
            //调用生成分页查询方法代码的方法
            this.CreateDivGetListByPage(code);
            //调用生成分页简单版【传入页码与一页显示多少数据】
            this.CreateDiyGetSimplenessByPage(code);
            //调用生成分页简单版并返回记录数量【传入页码与一页显示多少数据】
            this.CreateDiyGetSimplenessByPageAndOutCount(code);
        }
        /// <summary>
        /// 生成自定义自定义判断是否有此记录方法
        /// </summary>
        /// <param name="code">存储生成代码字符串对象</param>
        private void CreateDiyExists(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">SQL参数对象</param>");
            code.AppendLine("        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>");
            code.AppendLine("        public bool Exists(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储执行语句的字符串");
            code.AppendLine("            string sql =");
            code.AppendLine("                string.IsNullOrWhiteSpace(where)");
            code.AppendLine("                    ? \"Select Count(*) From " + this._table.TableName + ";\"");
            code.AppendLine("                    : \"Select Count(*) From " + this._table.TableName + " Where \" + where;");
            code.AppendLine("            //返回执行完成所得到的数据集合数量并判断是否有超过一条？");
            code.AppendLine("            return (int)" + this._mvcSetObject.SqlVisitClassName + ".ExecuteScalar(sql, sqlParameters) > 0;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 调用生成分页简单版并返回记录数量【传入页码与一页显示多少数据】
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDiyGetSimplenessByPageAndOutCount(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>");
            code.AppendLine("        /// <param name=\"orderby\">按照什么字段排序</param>");
            code.AppendLine("        /// <param name=\"isDesc\">是否是降序排序</param>");
            code.AppendLine("        /// <param name=\"pageIndex\">页面索引【从零开始】</param>");
            code.AppendLine("        /// <param name=\"pageItemCount\">一页显示多少数据</param>");
            code.AppendLine("        /// <param name=\"allItmeCount\">总共有多少条记录</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>查询到的新闻数据模型对象集合</returns>");
            code.AppendLine(
                "        public List<" + this._table.ModelName + "> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //得到总记录条数");
            code.AppendLine("            allItmeCount = this.GetCount(where, " + this._mvcSetObject.SqlVisitClassName +
                            ".CopySqlParameters(sqlParameters));");
            code.AppendLine("            //得到开始索引");
            code.AppendLine("            int beginIndex = pageIndex * pageItemCount;");
            code.AppendLine("            //得到结束索引");
            code.AppendLine("            int endIndex = (beginIndex + pageItemCount) - 1;");
            code.AppendLine("            //调用分页获取数据方法并返回结果");
            code.AppendLine(
                "            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 调用生成分页简单版【传入页码与一页显示多少数据】
        /// </summary>
        /// <param name="code">存储生成的代码的方法</param>
        private void CreateDiyGetSimplenessByPage(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>");
            code.AppendLine("        /// <param name=\"orderby\">按照什么字段排序</param>");
            code.AppendLine("        /// <param name=\"isDesc\">是否是降序排序</param>");
            code.AppendLine("        /// <param name=\"pageIndex\">页面索引【从零开始】</param>");
            code.AppendLine("        /// <param name=\"pageItemCount\">一页显示多少数据</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>查询到的新闻数据模型对象集合</returns>");
            code.AppendLine(
                "        public List<" + this._table.ModelName + "> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //得到开始索引");
            code.AppendLine("            int beginIndex = pageIndex * pageItemCount;");
            code.AppendLine("            //得到结束索引");
            code.AppendLine("            int endIndex = (beginIndex + pageItemCount) - 1;");
            code.AppendLine("            //调用分页获取数据方法并返回结果");
            code.AppendLine(
                "            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 创建生成获取所有数据的方法的代码的方法
        /// </summary>
        /// <param name="code"></param>
        private void CreateGetAllData(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 查询得到" + this._table.TableNote + "表中所有信息");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <returns>查询到的所有" + this._table.TableNote + "数据模型对象集合</returns>");
            code.AppendLine("        public List<" + this._table.ModelName + "> GetAllModel()");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储查找到的" + this._table.TableNote + "表中信息集合");
            code.AppendLine("            List<" + this._table.ModelName + "> list = new List<" + this._table.ModelName +
                            ">();");
            code.AppendLine("            //使用查询语句查询出所有信息");
            code.AppendLine("            using (SqlDataReader sqlReader = " +
                //存入数据访问类名称
                this._mvcSetObject.SqlVisitClassName +
                ".ExecuteReader(\"" +
                //存入获取所有信息语句
                this._table.GetSqlSelectCode() +
                ";\"))");
            code.AppendLine("            {");
            code.AppendLine("                //判断是否查询到了数据");
            code.AppendLine("                if (sqlReader.HasRows)");
            code.AppendLine("                {");
            code.AppendLine("                    //循环得到数据");
            code.AppendLine("                    while (sqlReader.Read())");
            code.AppendLine("                    {");
            code.AppendLine("                        //创建一个" + this._table.TableNote + "数据模型对象");
            //创建存储信息对象例如：UserIdentityMod userIdentityMod = new UserIdentityMod();
            code.AppendLine("                        " + this._table.ModelName + " " + this._table.PrivateModelName + " = new " + this._table.ModelName + "();");
            //循环进行参数赋值
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //存储注释
                code.AppendLine("                        //存储查询到的" + this._table.Lines[i].LineNote + "数据");
                //存入空格【排版】
                code.Append("                        ");
                //调用生成属性获取与赋值的代码方法
                this.CreateGiveObjectAssignmentCode(code, this._table.Lines[i], i);
            }
            code.AppendLine("                        //将" + this._table.TableNote + "数据模型对象存储到集合中");
            code.AppendLine("                        list.Add(" + this._table.PrivateModelName + ");");
            code.AppendLine("                    }");
            code.AppendLine("                }");
            code.AppendLine("            }");
            code.AppendLine("            //返回查询到的信息集合");
            code.AppendLine("            return list;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成添加记录方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateAddData(StringBuilder code)
        {
            //得到是自动编号的列
            List<Line> identityLines = this._table.GetIdentityLines();
            //得到不是自动编号的列
            List<Line> notIdentityLines = this._table.GetNotIdentityLines();
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 将传入的" + this._table.TableNote + "数据模型对象数据存入数据库，并将自动编号值存入，传入" + this._table.TableNote + "数据模型对象中");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + this._table.PrivateModelName + "\">要进行添加到数据库的" +
                            this._table.TableNote + "数据模型对象</param>");
            code.AppendLine("        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>");
            code.AppendLine("        public bool Add(" + this._table.ModelName + " " + this._table.PrivateModelName + ")");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储参数的数组");
            code.AppendLine("            SqlParameter[] sqlParameters = new[]");
            code.AppendLine("            {");
            #region SQL参数
            //循环存入SQL参数
            for (int i = 0; i < notIdentityLines.Count; i++)
            {
                //得到循环到的列
                Line line = notIdentityLines[i];
                //存入注释
                code.AppendLine("                //将" + line.LineNote + "存入");
                //存入占位符
                code.Append("                ");
                //调用存储生成SQL参数的方法
                this.CreateSqlParameterValue(code, line, (this._table.PrivateModelName + "." + line.PublicAttributeName));
                //判断是否遇到最后一个列，如果是就直接换行否则要加上“,”逗号
                if (i != notIdentityLines.Count - 1)
                {
                    //加入逗号并换行
                    code.AppendLine(",");
                }
                else
                {
                    //仅换行
                    code.AppendLine();
                }
            }
            #endregion
            code.AppendLine("            };");
            //判断是否有自动编号的值，如果有就要进行返回，否则就不进行返回
            if (identityLines.Count > 0)
            {
                code.AppendLine("            //进行插入操作并返回自动编号结果");
                code.AppendLine("            using (SqlDataReader sqlReader = " +
                    //将数据库访问类名称存入
                                this._mvcSetObject.SqlVisitClassName +
                                ".ExecuteReader(\"" +
                    //将生成的插入语句存入
                                this._table.GetSqlAddDataCode(identityLines, notIdentityLines) +
                                "\", sqlParameters))");
                code.AppendLine("            {");
                code.AppendLine("                //判断是否获取到数据");
                code.AppendLine("                if (sqlReader.HasRows)");
                code.AppendLine("                {");
                code.AppendLine("                    //得到第一条记录");
                code.AppendLine("                    sqlReader.Read();");
                //循环调用得到返回的自动编号值
                for (int i = 0; i < identityLines.Count; i++)
                {
                    //得到当前列对象
                    Line line = identityLines[i];
                    //生成注释
                    code.AppendLine("                    //将传入参数转换成" + line.LineNote);
                    //存储占位符【排版】
                    code.Append("                    ");
                    //调用生成赋值的语句
                    this.CreateGiveObjectAssignmentCode(code, line, i);
                }
                code.AppendLine("                    //返回添加成功");
                code.AppendLine("                    return true;");
                code.AppendLine("                }");
                code.AppendLine("                else");
                code.AppendLine("                {");
                code.AppendLine("                    //返回添加失败");
                code.AppendLine("                    return false;");
                code.AppendLine("                }");
                code.AppendLine("            }");
            }
            else
            {
                code.AppendLine("            //进行插入操作并返回结果");
                code.AppendLine("            return " +
                    //存入数据库访问类名称
                                this._mvcSetObject.SqlVisitClassName +
                                ".ExecuteNonQuery(\"" +
                    //得到插入数据语句
                                this._table.GetSqlAddDataCode(identityLines, notIdentityLines) +
                                "\", sqlParameters) > 0;");
            }
            code.AppendLine("        }");
        }
        /// <summary>
        /// 根据输入的键列来创建查询一条记录的方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        /// <param name="keyLine">用来查询的键</param>
        /// <param name="note">注释字符串</param>
        /// <param name="functionName">生成的函数名称例如主键获取：GetModel</param>
        private void CreateKeyGetData(StringBuilder code, Line keyLine, string note, string functionName)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// " + note);
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + keyLine.PrivateAttributeName + "\">" +
                            keyLine.LineNote + "</param>");
            code.AppendLine("        /// <returns>如果查找到此记录就返回" + this._table.TableNote + "数据模型对象，否则返回null</returns>");
            code.AppendLine("        public " + this._table.ModelName + " " + functionName + "(" + keyLine.GetNewCShapvVriableString + ")");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储参数的数组");
            code.AppendLine("            SqlParameter[] sqlParameters = new[]");
            code.AppendLine("            {");
            code.AppendLine("                //将" + keyLine.LineNote + "存入");

            //存储参数
            //存入空格【排版】
            code.Append("                ");
            //调用存储Sql参数的方法
            this.CreateSqlParameterValue(code, keyLine, keyLine.PrivateAttributeName);
            //换行
            code.AppendLine();

            code.AppendLine("            };");
            //存入执行SQL命令注释
            code.AppendLine("            //执行一条查找SQL命令");
            //存入创建对象
            code.AppendLine("            using (SqlDataReader sqlReader = " +
                //存入数据库访问类名称
                this._mvcSetObject.SqlVisitClassName +
                ".ExecuteReader(\"" +
                //存入查询语句
                this._table.GetSqlSelectCode(keyLine) +
                "\", sqlParameters))");
            code.AppendLine("            {");
            code.AppendLine("                //判断是否查找到数据");
            code.AppendLine("                if (sqlReader.HasRows)");
            code.AppendLine("                {");
            code.AppendLine("                    //得到第一条数据");
            code.AppendLine("                    sqlReader.Read();");
            code.AppendLine("                    //创建一个" + this._table.TableNote + "数据模型对象");
            //创建存储信息对象例如：UserIdentityMod userIdentityMod = new UserIdentityMod();
            code.AppendLine("                    " + this._table.ModelName + " " + this._table.PrivateModelName + " = new " + this._table.ModelName + "();");

            //循环进行参数赋值
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //存储注释
                code.AppendLine("                    //存储查询到的" + this._table.Lines[i].LineNote + "数据");
                //存入空格【排版】
                code.Append("                    ");
                //调用生成属性获取与赋值的代码方法
                this.CreateGiveObjectAssignmentCode(code, this._table.Lines[i], i);
            }

            code.AppendLine("                    //将" + this._table.TableNote + "数据模型对象返回");
            code.AppendLine("                    return " + this._table.PrivateModelName + ";");
            code.AppendLine("                }");
            code.AppendLine("            }");
            code.AppendLine("            //返回null");
            code.AppendLine("            return null;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成按照指定的列【主键、唯一键】来删除记录方法代码方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串对象</param>
        /// <param name="keyLine">指定列</param>
        /// <param name="note">方法注释</param>
        /// <param name="functionName">方法名称</param>
        private void CreateKeyDelete(StringBuilder code, Line keyLine, string note, string functionName)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// " + note);
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + keyLine.PrivateAttributeName + "\">" + keyLine.LineNote +
                            "</param>");
            code.AppendLine("        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>");
            code.AppendLine("        public bool " + functionName + "(" + keyLine.GetNewCShapvVriableString + ")");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储参数的数组");
            code.AppendLine("            SqlParameter[] sqlParameters = new[]");
            code.AppendLine("            {");
            //存入参数注释
            code.AppendLine("                //将" + keyLine.LineNote + "存入");
            //存入空格【进行排版】
            code.Append("                ");
            //调用存入参数方法
            this.CreateSqlParameterValue(code, keyLine, keyLine.PrivateAttributeName);
            //换行
            code.AppendLine();
            code.AppendLine("            };");
            code.AppendLine("            //执行一条按照" + keyLine.LineNote + "删除记录语句，并返回是否删除成功");
            code.AppendLine("            return " +
                //存入数据访问类名称
                this._mvcSetObject.SqlVisitClassName
                + ".ExecuteNonQuery(\"Delete From " +
                //将表名称存入
                            this._table.TableName +
                            " Where " +
                //将列名称存入
                            keyLine.LineName +
                            " = " +
                //将列在SQL参数中的命名字符串存入
                            keyLine.SqlVariableName
                            + ";\", sqlParameters) > 0;");
            //回大括号
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成更新信息方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串对象</param>
        private void CreateUpdate(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 更新数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + this._table.PrivateModelName + "\">" + this._table.TableNote +
                            "</param>");
            code.AppendLine("        /// <returns>返回是否更新成功，为true成功为false失败</returns>");
            code.AppendLine("        public bool Update(" + this._table.ModelName + " " + this._table.PrivateModelName + ")");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储参数的数组");
            code.AppendLine("            SqlParameter[] sqlParameters = new[]");
            code.AppendLine("            {");
            //循环存入参数
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //得到列对象
                Line line = this._table.Lines[i];
                //将注释存入
                code.AppendLine("                //将" + line.LineNote + "存入");
                //将占位符存入
                code.Append("                ");
                //调用生成SQL参数语句代码方法
                this.CreateSqlParameterValue(code, line, (this._table.PrivateModelName + "." + line.PublicAttributeName));
                //判断是否为最后一个参数了，如果是就不存入“,”逗号否则就存入
                if (i != this._table.Lines.Count - 1)
                {
                    //存入逗号
                    code.AppendLine(",");
                }
                else
                {
                    //仅换行
                    code.AppendLine();
                }
            }
            code.AppendLine("            };");
            code.AppendLine("            //执行更新语句，并返回是否更新完成");
            code.AppendLine("            return " +
                //存入数据库访问类
                            this._mvcSetObject.SqlVisitClassName +
                            ".ExecuteNonQuery(\"" +
                //得到根据主键修改的代码
                            this._table.GetSqlPrimaryKeyUpdateCode() +
                            "\", sqlParameters) > 0;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成判断是否有此记录方法代码的方法
        /// </summary>
        /// <param name="code">存储生成的代码字符串对象</param>
        private void CreateExists(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 判断是否有此记录");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + this._table.PrivateModelName + "\">验证的" +
                            this._table.TableNote + "数据模型对象</param>");
            code.AppendLine("        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>");
            code.AppendLine("        public bool Exists(" + this._table.ModelName + " " + this._table.PrivateModelName + ")");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储参数的数组");
            code.AppendLine("            SqlParameter[] sqlParameters = new[]");
            code.AppendLine("            {");
            //循环存入参数
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //得到列对象
                Line line = this._table.Lines[i];
                //将注释存入
                code.AppendLine("                //将" + line.LineNote + "存入");
                //将占位符存入
                code.Append("                ");
                //调用生成SQL参数语句代码方法
                this.CreateSqlParameterValue(code, line, (this._table.PrivateModelName + "." + line.PublicAttributeName));
                //判断是否为最后一个参数了，如果是就不存入“,”逗号否则就存入
                if (i != this._table.Lines.Count - 1)
                {
                    //存入逗号
                    code.AppendLine(",");
                }
                else
                {
                    //仅换行
                    code.AppendLine();
                }
            }
            code.AppendLine("            };");
            code.AppendLine("            //执行查询语句，并返回是否有此记录");
            //存入执行语句与返回值
            code.AppendLine("            return (int)" +
                //存入访问类名称
                this._mvcSetObject.SqlVisitClassName +
                ".ExecuteScalar(\"" +
                //存入执行SQL语句
                this._table.GetSqlCountCode(this._table.Lines) +
                "\", sqlParameters) > 0;");
            //存入回括号
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成判断是否有此记录方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        /// <param name="line">按照那个列进行判断</param>
        /// <param name="note">注释</param>
        /// <param name="functionName">生成的方法名称</param>
        private void CreateExists(StringBuilder code, Line line, string note, string functionName)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// " + note);
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + line.PrivateAttributeName + "\">" + line.LineNote +
                            "</param>");
            code.AppendLine("        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>");
            code.AppendLine("        public bool " + functionName + "(" + line.GetNewCShapvVriableString + ")");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储参数的数组");
            code.AppendLine("            SqlParameter[] sqlParameters = new[]");
            code.AppendLine("            {");
            code.AppendLine("                //将[编号]存入");
            //存入占位符
            code.Append("                ");
            //存入SQL参数
            this.CreateSqlParameterValue(code, line, line.PrivateAttributeName);
            //换行
            code.AppendLine();
            code.AppendLine("            };");
            code.AppendLine("            //执行查询语句，并返回是否有此记录");
            code.AppendLine("            return (int)" +
                //存入数据库访问类名称
                            this._mvcSetObject.SqlVisitClassName +
                            ".ExecuteScalar(\"" +
                //存入查询数量的语句
                            this._table.GetSqlCountCode(new List<Line>() { line })
                            + "\", sqlParameters) > 0;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成自定义查找数据方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDiyGetData(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>查询到的[会员名称]数据模型对象集合</returns>");
            code.AppendLine("        public List<" + this._table.ModelName + "> GetModelList(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储[会员名称]数据模型对象的集合");
            code.AppendLine("            List<" + this._table.ModelName + "> list = new List<" + this._table.ModelName + ">();");
            code.AppendLine("            //创建存储执行语句的字符串");
            code.AppendLine("            string sql =");
            code.AppendLine("                string.IsNullOrWhiteSpace(where)");
            code.AppendLine("                    ? \"" + this._table.GetSqlSelectCode() + ";\"");
            code.AppendLine("                    : \"" + this._table.GetSqlSelectCode() + " Where \" + where;");
            code.AppendLine("            //执行查找语句");
            code.AppendLine("            using (SqlDataReader sqlReader = " +
                //存入数据访问类名称
                this._mvcSetObject.SqlVisitClassName
                + ".ExecuteReader(sql, sqlParameters))");
            code.AppendLine("            {");
            code.AppendLine("                //判断是否查询到数据");
            code.AppendLine("                if (sqlReader.HasRows)");
            code.AppendLine("                {");
            code.AppendLine("                    //循环查询数据");
            code.AppendLine("                    while (sqlReader.Read())");
            code.AppendLine("                    {");
            code.AppendLine("                        //创建一个" + this._table.TableNote + "数据模型对象");
            //创建存储信息对象例如：UserIdentityMod userIdentityMod = new UserIdentityMod();
            code.AppendLine("                        " + this._table.ModelName + " " + this._table.PrivateModelName + " = new " + this._table.ModelName + "();");
            //循环进行参数赋值
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //存储注释
                code.AppendLine("                        //存储查询到的" + this._table.Lines[i].LineNote + "数据");
                //存入空格【排版】
                code.Append("                        ");
                //调用生成属性获取与赋值的代码方法
                this.CreateGiveObjectAssignmentCode(code, this._table.Lines[i], i);
            }
            code.AppendLine("                        //将" + this._table.TableNote + "数据模型对象存储到集合中");
            code.AppendLine("                        list.Add(" + this._table.PrivateModelName + ");");
            code.AppendLine("                    }");
            code.AppendLine("                }");
            code.AppendLine("            }");
            code.AppendLine("            //返回查找到的" + this._table.TableNote + "对象的集合");
            code.AppendLine("            return list;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成自定义删除数据方法代码方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDiyDelete(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义删除【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">删除条件</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>是否删除成功，为true成功，为false失败</returns>");
            code.AppendLine("        public bool Delete(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储执行语句的字符串");
            code.AppendLine("            string sql =");
            code.AppendLine("                string.IsNullOrWhiteSpace(where)");
            code.AppendLine("                    ? \"Delete From " + this._table.TableName + ";\"");
            code.AppendLine("                    : \"Delete From " + this._table.TableName + " Where \" + where;");
            code.AppendLine("            //执行删除语句，并返回是否删除成功");
            code.AppendLine("            return " + this._mvcSetObject.SqlVisitClassName +
                            ".ExecuteNonQuery(sql, sqlParameters) > 0;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成自定义查询匹配记录有多少条方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDivGetCount(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义查询出匹配记录有多少条【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>匹配记录数量</returns>");
            code.AppendLine("        public int GetCount(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //创建存储执行语句的字符串");
            code.AppendLine("            string sql =");
            code.AppendLine("                string.IsNullOrWhiteSpace(where)");
            code.AppendLine("                    ? \"Select Count(*) From " + this._table.TableName + ";\"");
            code.AppendLine("                    : \"Select Count(*) From " + this._table.TableName + " Where \" + where;");
            code.AppendLine("            //返回执行完成所得到的数据集合");
            code.AppendLine("            return (int)" + this._mvcSetObject.SqlVisitClassName + ".ExecuteScalar(sql, sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成分页方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDivGetListByPage(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取数据【建议只给数据访问层内部使用！要使用请重新封装！】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>");
            code.AppendLine("        /// <param name=\"orderby\">按照什么字段排序</param>");
            code.AppendLine("        /// <param name=\"isDesc\">是否是降序排序</param>");
            code.AppendLine("        /// <param name=\"startIndex\">开始索引【从零开始】</param>");
            code.AppendLine("        /// <param name=\"endIndex\">结束索引【包括当前索引指向记录】</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>查询到的" + this._table.TableNote + "数据模型对象集合</returns>");
            code.AppendLine("        public List<" + this._table.ModelName + "> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //判断传入的条件是否为“;”如果是就移除");
            code.AppendLine("            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')");
            code.AppendLine("                //移除最后一个");
            code.AppendLine("                where = where.Remove(where.Length - 1);");
            code.AppendLine("            //创建存储" + this._table.TableNote + "数据模型对象的集合");
            code.AppendLine("            List<" + this._table.ModelName + "> list = new List<" + this._table.ModelName + ">();");
            code.AppendLine("            //合成SQL查询语句");
            code.AppendLine("            string sql =");
            code.AppendLine("                string.IsNullOrWhiteSpace(where)");
            code.AppendLine("                ? \"Select * From (Select * ,Rn=row_number() Over(Order By \" +");
            code.AppendLine("                    orderby +");
            code.AppendLine("                    \" \" +");
            code.AppendLine("                    (isDesc ? \"Desc\" : \"Asc\")");
            code.AppendLine("                    + \") From " + this._table.TableName + ") As t Where t.Rn-1 Between \" +");
            code.AppendLine("                    startIndex.ToString() +");
            code.AppendLine("                    \" And \" +");
            code.AppendLine("                    endIndex.ToString() +");
            code.AppendLine("                    \";\"");
            code.AppendLine("               : \"Select * From (Select * ,Rn=row_number() Over(Order By \" +");
            code.AppendLine("                    orderby +");
            code.AppendLine("                    \" \" +");
            code.AppendLine("                    (isDesc ? \"Desc\" : \"Asc\") +");
            code.AppendLine("                    \") From " + this._table.TableName + " Where \" +");
            code.AppendLine("                    //将条件存入内查询，而非外查询！！！");
            code.AppendLine("                    where +");
            code.AppendLine("                    \") As t Where t.Rn-1 Between \" +");
            code.AppendLine("                    startIndex.ToString() +");
            code.AppendLine("                    \" And \" +");
            code.AppendLine("                    endIndex.ToString() + \";\";");
            code.AppendLine("            //执行查找语句");
            code.AppendLine("            using (SqlDataReader sqlReader = " +
                //存入数据库访问类
                this._mvcSetObject.SqlVisitClassName +
                ".ExecuteReader(sql, sqlParameters))");
            code.AppendLine("            {");
            code.AppendLine("                //判断是否查询到数据");
            code.AppendLine("                if (sqlReader.HasRows)");
            code.AppendLine("                {");
            code.AppendLine("                    //循环查询数据");
            code.AppendLine("                    while (sqlReader.Read())");
            code.AppendLine("                    {");
            code.AppendLine("                        //创建一个" + this._table.TableNote + "数据模型对象");
            //创建存储信息对象例如：UserIdentityMod userIdentityMod = new UserIdentityMod();
            code.AppendLine("                        " + this._table.ModelName + " " + this._table.PrivateModelName + " = new " + this._table.ModelName + "();");
            //循环进行参数赋值
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //存储注释
                code.AppendLine("                        //存储查询到的" + this._table.Lines[i].LineNote + "数据");
                //存入空格【排版】
                code.Append("                        ");
                //调用生成属性获取与赋值的代码方法
                this.CreateGiveObjectAssignmentCode(code, this._table.Lines[i], i);
            }
            code.AppendLine("                        //将" + this._table.TableNote + "数据模型对象存储到集合中");
            code.AppendLine("                        list.Add(" + this._table.PrivateModelName + ");");
            code.AppendLine("                    }");
            code.AppendLine("                }");
            code.AppendLine("            }");
            code.AppendLine("            //返回查询到的信息集合");
            code.AppendLine("            return list;");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成给SQL数据模型对象属性赋值代码方法例如：userIdentityMod.UiID = sqlReader.GetInt32(0);
        /// 进行处理代码如果传入为空的处理
        /// </summary>
        /// <param name="code">存储生成代码的字符串对象</param>
        /// <param name="line">生成的列对象</param>
        /// <param name="index">获取数据的索引例如：.GetInt32(0)括号里面的值</param>
        private void CreateGiveObjectAssignmentCode(StringBuilder code, Line line, int index)
        {
            //得到索引转换成字符串内容
            string Index = index.ToString();
            //将数据模型类与列共有属性存入例如：userIdentityMod.UiID = 
            code.Append(line.FathertTable.PrivateModelName + "." + line.PublicAttributeName + " = ");
            //判断当前列在c#中是否可以为空，并且在数据库也必须可以为空就可以进行判断是否可能为空，否则就不进行判断
            if (line.Type.CShapIsNull && line.Type.SqlIsNull)
            {
                //判断获取函数是否为：Byte[]【没有此方法仅作为标识存在！】这个标识代表存储的是字节数据！就进行获取字节数据处理
                if (line.Type.CShapGetDataTypeMethodName == "Byte[]")
                {
                    //存储获取方法：sqlReader.IsDBNull([索引]) ? null : (sqlReader.GetValue([索引]) as byte[]);
                    code.AppendLine("sqlReader.IsDBNull(" + Index + ") ? null : (sqlReader.GetValue(" + Index + ") as byte[]);");
                }
                else
                {
                    //存储获取方法：sqlReader.IsDBNull([索引]) ? null : ([类型])sqlReader.[获取方法]([索引]);
                    code.AppendLine("sqlReader.IsDBNull(" + Index + ") ? null : (" + line.Type.CShapTypeString + ")sqlReader." + line.Type.CShapGetDataTypeMethodName + "(" + Index + ");");
                }
            }
            else
            {
                //判断获取函数是否为：Byte[]【没有此方法仅作为标识存在！】这个标识代表存储的是字节数据！就进行获取字节数据处理
                if (line.Type.CShapGetDataTypeMethodName == "Byte[]")
                {
                    //存入内容：sqlReader.GetValue([索引]) as byte[];
                    code.AppendLine("sqlReader.GetValue(" + Index + ") as byte[];");
                }
                else
                {
                    //存入内容：sqlReader.[获取方法]([索引]);
                    code.AppendLine("sqlReader." + line.Type.CShapGetDataTypeMethodName + "(" + Index + ");");
                }
            }
        }
        /// <summary>
        /// 生成SQL参数例如：new SqlParameter("@uiID",SqlDbType.Int,4){Value = id}，如果遇到不能为空等情况会进行空处理
        /// </summary>
        /// <param name="code">存储生成代码的字符串对象</param>
        /// <param name="line">生成的列对象</param>
        /// <param name="variableName">赋值的变量字符串</param>
        private void CreateSqlParameterValue(StringBuilder code, Line line, string variableName)
        {
            //将生成列SQL参数对象字符串存入
            code.Append(line.GetSqlParameter);
            //判断当前列在C#中是否可以为空？
            if (line.Type.CShapIsNull)
            {
                //判断在数据库中是否可以为空
                if (line.Type.SqlIsNull)
                {
                    //将{Value = [变量] ?? (object)DBNull.Value}存入
                    code.Append("{Value = " + variableName + " ?? (object)DBNull.Value}");
                }
                else
                {
                    //因为在数据库中不能为空所以就存储默认值进入
                    //将{Value = [变量] ?? [默认值]}
                    code.Append("{Value = " + variableName + " ?? " + line.Type.CShapAcquiesceIn + "}");
                }
            }
            else
            {
                //因为在C#中不可为空在数据库中肯定也不能为空就直接放心存入即可
                //直接将值存入：{Value = [变量]}
                code.Append("{Value = " + variableName + "}");
            }
        }
    }
}
