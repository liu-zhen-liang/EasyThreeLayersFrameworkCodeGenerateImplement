using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.CreateCode.CreateMVC
{
    /// <summary>
    ///生成简单三层架构生成业务逻辑层代码类
    /// </summary>
    public class MvcBllObject
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
        /// 创建当前要生成的简单三层架构业务逻辑层对象
        /// </summary>
        /// <param name="tabe">要进行生成的表集合</param>
        /// <param name="mvcSet">MVC生成设置</param>
        public MvcBllObject(Table tabe, MvcSetObject mvcSet)
        {
            //进行赋值
            this._table = tabe;
            this._mvcSetObject = mvcSet;
        }
        /// <summary>
        /// 生成简单三层架构业务逻辑层对象代码方法
        /// </summary>
        /// <returns>生成的代码</returns>
        public string CreateMvcBllClassCode()
        {
            //创建存储生成代码的字符串
            StringBuilder code = new StringBuilder();
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Linq;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using System.Data.SqlClient;");
            code.AppendLine("using " + this._mvcSetObject.Namespace + ".DAL;");
            code.AppendLine("using " + this._mvcSetObject.Namespace + ".Model;");
            code.AppendLine();
            code.AppendLine("namespace " + this._mvcSetObject.Namespace + ".BLL");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// " + this._table.TableNote + "业务逻辑对象");
            code.AppendLine("    /// </summary>");
            code.AppendLine("    public partial class " + this._table.BllName);
            code.AppendLine("    {");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// " + this._table.TableNote + "数据访问对象");
            code.AppendLine("        /// </summary>");
            //实现效果例如：private readonly UserIdentityDal _userIdentityDal = new UserIdentityDal();
            code.AppendLine("        private readonly " + this._table.DalName + " _" + this._table.PrivateDalName +
                            " = new " + this._table.DalName + "();");
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 实例化" + this._table.TableNote + "业务逻辑对象");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public " + this._table.BllName + "()");
            code.AppendLine("        {");
            code.AppendLine("            ");
            code.AppendLine("        }");

            //调用生成方法代码的方法
            this.CreateMvcBllFunctionCode(code);

            code.AppendLine("    }");
            code.AppendLine("}");
            //返回生成的代码
            return code.ToString();
        }
        /// <summary>
        /// 生成简单三层架构业务逻辑层方法代码的方法
        /// </summary>
        /// <param name="code">存储生成完成的代码的方法</param>
        private void CreateMvcBllFunctionCode(StringBuilder code)
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
            code.AppendLine("            //调用数据访问层方法");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".Exists(where, sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 调用生成分页简单版并返回记录数量【传入页码与一页显示多少数据】
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDiyGetSimplenessByPageAndOutCount(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取数据并返回总记录条数");
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
            code.AppendLine("            //调用数据访问层分页获取数据方法");
            code.AppendLine(
    "            return this._" + this._table.PrivateDalName + ".GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, out allItmeCount, sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 调用生成分页简单版【传入页码与一页显示多少数据】
        /// </summary>
        /// <param name="code">存储生成的代码的方法</param>
        private void CreateDiyGetSimplenessByPage(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取数据并返回总记录条数");
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
            code.AppendLine("            //调用数据访问层分页获取数据方法");
            code.AppendLine(
    "            return this._" + this._table.PrivateDalName + ".GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, sqlParameters);");
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
            code.AppendLine("            //调用数据库访问层查询表中所有信息方法并将查询结果返回");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".GetAllModel();");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成添加记录方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateAddData(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 将传入的" + this._table.TableNote + "数据模型对象数据存入数据库，并将自动编号值存入，传入" + this._table.TableNote + "数据模型对象中");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"" + this._table.PrivateModelName + "\">要进行添加到数据库的" +
                            this._table.TableNote + "数据模型对象</param>");
            code.AppendLine("        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>");
            code.AppendLine("        public bool Add(" + this._table.ModelName + " " + this._table.PrivateModelName + ")");
            code.AppendLine("        {");
            code.AppendLine("            //调用数据访问层的添加方法并返回是否添加成功");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".Add(" + this._table.PrivateModelName + ");");
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
            code.AppendLine("            //调用数据访问层查询方法并将查询结果返回");
            code.AppendLine("            return this._" + this._table.PrivateDalName + "." + functionName + "(" +
                            keyLine.PrivateAttributeName + ");");
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
            code.AppendLine("            //调用数据访问层删除方法删除指定元素并返回是否删除成功");
            code.AppendLine("            return this._" + this._table.PrivateDalName + "." + functionName + "(" +
                            keyLine.PrivateAttributeName + ");");
            //回大括号
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
            code.AppendLine("            //调用数据访问层判断是否有此记录方法并返回结果");
            code.AppendLine("            return this._" + this._table.PrivateDalName + "." + functionName + "(" + line.PrivateAttributeName + ");");
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
            code.AppendLine("            //调用数据访问层更新数据方法并将更新结果返回");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".Update(" + this._table.PrivateModelName + ");");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成自定义删除数据方法代码方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDiyDelete(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义删除");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">删除条件</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>是否删除成功，为true成功，为false失败</returns>");
            code.AppendLine("        public bool Delete(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //调用数据访问层的自定义删除方法并返回删除结果");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".Delete(where, sqlParameters);");
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
            code.AppendLine("            //调用数据访问层的判断是否有此记录方法并返回判断结果");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".Exists(" + this._table.PrivateModelName + ");");
            //存入回括号
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成自定义查找数据方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDiyGetData(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义查找");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>查询到的[会员名称]数据模型对象集合</returns>");
            code.AppendLine("        public List<" + this._table.ModelName + "> GetModelList(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //调用数据访问层的自定义查找方法并将查找结果返回");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".GetModelList(where,sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成自定义查询匹配记录有多少条方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDivGetCount(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 自定义查询出匹配记录有多少条");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>匹配记录数量</returns>");
            code.AppendLine("        public int GetCount(string where, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //调用数据访问层自定义查询出匹配记录有多少条方法并将结果返回");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".GetCount(where,sqlParameters);");
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成分页方法代码的方法
        /// </summary>
        /// <param name="code">存储生成代码的字符串</param>
        private void CreateDivGetListByPage(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"where\">查询条件语句(SQL)，没有填空【获取所有数据】</param>");
            code.AppendLine("        /// <param name=\"orderby\">按照什么字段排序</param>");
            code.AppendLine("        /// <param name=\"isDesc\">是否是降序排序</param>");
            code.AppendLine("        /// <param name=\"startIndex\">开始索引</param>");
            code.AppendLine("        /// <param name=\"endIndex\">结束索引</param>");
            code.AppendLine("        /// <param name=\"sqlParameters\">所需SQL参数对象数组</param>");
            code.AppendLine("        /// <returns>查询到的" + this._table.TableNote + "数据模型对象集合</returns>");
            code.AppendLine("        public List<" + this._table.ModelName + "> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)");
            code.AppendLine("        {");
            code.AppendLine("            //调用数据访问层分页获取数据方法并将查询到的数据返回");
            code.AppendLine("            return this._" + this._table.PrivateDalName + ".GetListByPage(where,orderby,isDesc,startIndex,endIndex,sqlParameters);");
            code.AppendLine("        }");
        }
    }
}
