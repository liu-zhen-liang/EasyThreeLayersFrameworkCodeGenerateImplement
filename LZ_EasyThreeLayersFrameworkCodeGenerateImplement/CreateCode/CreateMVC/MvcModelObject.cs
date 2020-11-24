using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.CreateCode.CreateMVC
{
    /// <summary>
    /// 生成简单三层架构数据模型对象类
    /// </summary>
    public class MvcModelObject
    {
        /// <summary>
        /// 要进行生成的表
        /// </summary>
        private Table _table;
        /// <summary>
        /// 存储设置的对象
        /// </summary>
        private MvcSetObject _mvcSetObject;
        /// <summary>
        /// 创建当前生成简单三层架构数据模型对象
        /// </summary>
        /// <param name="tabe">要进行生成的表集合</param>
        /// <param name="mvcSet">MVC生成设置</param>
        public MvcModelObject(Table tabe, MvcSetObject mvcSet)
        {
            //进行赋值
            this._table = tabe;
            this._mvcSetObject = mvcSet;
        }
        /// <summary>
        /// 生成Mvc数据模型类代码方法
        /// </summary>
        /// <returns>数据模型类代码字符串</returns>
        public string CreateMvcModelClassCode()
        {
            //创建存储代码的字符串对象
            StringBuilder code = new StringBuilder();
            //将引用空间存入
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Linq;");
            code.AppendLine("using System.Text;");
            code.AppendLine();
            //存入命名空间
            //判断是否输入了命名空间
            if (string.IsNullOrWhiteSpace(this._mvcSetObject.Namespace))
            {
                //只存入Model
                code.AppendLine("namespace Model");
            }
            else
            {
                //存入命名空间+Model
                code.AppendLine("namespace " + this._mvcSetObject.Namespace + ".Model");
            }
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            //类XML文档注释
            code.AppendLine("    /// " + this._table.TableNote + "数据模型对象");
            code.AppendLine("    /// </summary>");
            //允许序列化
            code.AppendLine("    [Serializable]");
            //设置类名称
            code.AppendLine("    public partial class " + this._table.ModelName);
            code.AppendLine("    {");

            //调用生成构造函数的方法
            this.CreateStructureFunction(code);
            //调用生成属性的方法
            this.CreateAttribute(code);
            //调用生成重写方法代码的方法
            this.CreateOverrideFunction(code);

            //设置类结尾
            code.AppendLine("    }");
            //设置命名空间结尾
            code.AppendLine("}");
            //返回结果
            return code.ToString();
        }
        /// <summary>
        /// 生成构造函数的方法
        /// </summary>
        /// <param name="code">存储生成的构造函数的字符串对象</param>
        private void CreateStructureFunction(StringBuilder code)
        {
            #region 无参构造函数
            //存储一个无参数的构造函数【默认】
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 初始化" + this._table.TableNote + "数据模型对象");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public " + this._table.ModelName + "()");
            code.AppendLine("        {");
            code.AppendLine("            ");
            code.AppendLine("        }");
            #endregion

            //得到所有不能为空的列
            List<Line> notNullLines = this._table.GetNotNullLines();
            //判断是否所有列都不能为空？
            bool allLineNotNull = notNullLines.Count == this._table.Lines.Count;
            //判断不能为空的参数是否为0，如果为0就没有必要进行生成这个构造函数了
            if (notNullLines.Count > 0)
            {
                #region //给不能为空的字段进行赋值【有可能都不为空！】
                code.AppendLine("        /// <summary>");
                //判断是否为全部都是不能为空
                if (allLineNotNull)
                {
                    //显示值：/// 初始化[注释]数据模型对象并给所有字段赋值
                    code.AppendLine("        /// 初始化" + this._table.TableNote + "数据模型对象并给所有字段赋值");
                }
                else
                {
                    //显示值：/// 初始化[注释]数据模型对象并给在SQL中不能为空的字段赋值
                    code.AppendLine("        /// 初始化" + this._table.TableNote + "数据模型对象并给在SQL中不能为空的字段赋值");
                }
                code.AppendLine("        /// </summary>");
                //循环生成参数
                foreach (Line line in notNullLines)
                {
                    //将参数存入
                    code.AppendLine("        " + line.CreateXmlSetNote());
                }
                //将构造函数头存入
                code.Append("        public " + this._table.ModelName + "(");
                //循环将参数与变量名称存入
                foreach (Line line in notNullLines)
                {
                    //将值存入
                    code.Append(line.GetNewCShapvVriableString + ",");
                }
                //移除最后一个，逗号“,”
                code.Remove(code.Length - 1, 1);
                //将括号进行扩回并换行处理
                code.AppendLine(")");
                code.AppendLine("        {");
                //循环设置赋值内容
                foreach (Line line in notNullLines)
                {
                    //注释
                    code.AppendLine("            //给" + line.LineNote + "字段赋值");
                    //赋值内容
                    code.AppendLine("            this." + line.PublicAttributeName + " = " + line.PrivateAttributeName +
                                    ";");
                }
                //大回括号
                code.AppendLine("        }");
                #endregion
            }

            //判断是否所有列都不是不能为空？【如果都要不能为空就没必要写这个全参数的构造函数了！】
            if (!allLineNotNull)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine("        /// 初始化" + this._table.TableNote + "数据模型对象并给所有字段赋值");
                code.AppendLine("        /// </summary>");
                //循环保存参数注释
                foreach (Line line in this._table.Lines)
                {
                    //调用得到注释方法并将注释存入
                    code.AppendLine("        " + line.CreateXmlSetNote());
                }
                //将构造函数头存入
                code.Append("        public " + this._table.ModelName + "(");
                //循环将参数值存入
                foreach (Line line in this._table.Lines)
                {
                    //调用得到参数方法并将结果存入
                    code.Append(line.GetNewCShapvVriableString + ",");
                }
                //移除最后一个字符逗号“,”
                code.Remove(code.Length - 1, 1);
                //将回括号存入并换行
                code.AppendLine(")");
                //将构造函数大括号开始存入
                code.AppendLine("        {");
                //循环将要进行赋值的代码生成并存入
                foreach (Line line in this._table.Lines)
                {
                    //生成注释并存入
                    code.AppendLine("            //给" + line.LineNote + "字段赋值");
                    //生成赋值代码
                    code.AppendLine("            this." + line.PublicAttributeName + " = " + line.PrivateAttributeName +
                                    ";");
                }
                //将大回括号存入
                code.AppendLine("        }");
            }
        }
        /// <summary>
        /// 生成全局属性的方法
        /// </summary>
        /// <param name="code">存储生成的全局属性的字符串对象</param>
        public void CreateAttribute(StringBuilder code)
        {
            //存储一个换行符
            code.AppendLine("        ");
            //加上注释
            code.AppendLine("		//属性存储数据的变量");
            //循环生成存储属性的变量
            foreach (Line line in this._table.Lines)
            {
                //将生成结果存储
                code.AppendLine("        private " + line.Type.CShapTypeString + " _" + line.PrivateAttributeName + ";");
            }
            //存储一个换行符
            code.AppendLine("        ");
            //循环生成全局属性
            foreach (Line line in this._table.Lines)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine("        /// " + line.LineNote);
                code.AppendLine("        /// </summary>");
                //属性头
                code.AppendLine("        public " + line.Type.CShapTypeString + " " + line.PublicAttributeName);
                code.AppendLine("        {");
                code.AppendLine("            get { return this._" + line.PrivateAttributeName + "; }");
                code.AppendLine("            set { this._" + line.PrivateAttributeName + " = value; }");
                code.AppendLine("        }");
            }
        }
        /// <summary>
        /// 生成重写方法代码的方法
        /// </summary>
        /// <param name="code">存储生成重写方法代码的字符串对象</param>
        private void CreateOverrideFunction(StringBuilder code)
        {
            //存储换行符
            code.AppendLine("        ");
            //调用生成Equals方法代码的方法
            this.CreateEqualsFunction(code);
            //调用生成获取哈希码方法代码的方法
            this.CreateGetHashCodeFunction(code);
            //调用生成将当前对象转换成字符串方法
            this.CreateToStringFunction(code);
        }
        /// <summary>
        /// 生成Equals方法代码的方法
        /// </summary>
        /// <param name="code">存储生成的Equals方法代码的字符串</param>
        private void CreateEqualsFunction(StringBuilder code)
        {
            //生成注释
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 对比两个" + this._table.TableNote + "数据模型对象是否一致");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <param name=\"obj\">要进行比对的" + this._table.TableNote + "数据模型对象</param>");
            code.AppendLine("        /// <returns>返回是否一致，为true一致，为false不一致</returns>");
            code.AppendLine("        public override bool Equals(object obj)");
            code.AppendLine("        {");
            code.AppendLine("            //判断传入对象是否为null");
            code.AppendLine("            if (obj == null) return false;");
            code.AppendLine("            //将传入对象转换成" + this._table.TableNote + "数据模型对象");
            code.AppendLine("            " + this._table.ModelName + " " + this._table.PrivateModelName + " = obj as " +
                            this._table.ModelName + ";");
            code.AppendLine("            //判断是否转换成功");
            code.AppendLine("            if (" + this._table.PrivateModelName + " == null) return false;");
            code.AppendLine("            //进行匹配属性的值");
            code.AppendLine("            return");
            //循环匹配属性
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //得到当前循环到的列对象
                Line line = this._table.Lines[i];
                //将注释存入
                code.AppendLine("                //判断" + line.LineNote + "是否一致");
                //判断是否还有下一个属性，如果有就加上&&否则不加
                if (i != this._table.Lines.Count - 1)
                {
                    //将属性对比存入
                    code.AppendLine("                this." + line.PublicAttributeName + " == " +
                                    this._table.PrivateModelName + "." + line.PublicAttributeName + " &&");
                }
                else
                {
                    //将属性对比存入
                    code.AppendLine("                this." + line.PublicAttributeName + " == " +
                                    this._table.PrivateModelName + "." + line.PublicAttributeName + ";");
                }
            }
            //加回括号
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成哈希码方法代码的方法
        /// </summary>
        /// <param name="code">存储生成完成的生成哈希码方法代码的字符串</param>
        private void CreateGetHashCodeFunction(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 将当前" + this._table.TableNote + "数据模型对象转换成哈希码");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <returns>哈希值</returns>");
            code.AppendLine("        public override int GetHashCode()");
            code.AppendLine("        {");
            code.AppendLine("            //将" + this._table.TableNote + "数据模型对象的属性进行按位异或运算处理得到哈希码并返回");
            code.AppendLine("            return");
            //循环进行生成异或代码
            for (int i = 0; i < this._table.Lines.Count; i++)
            {
                //得到当前要进行生成的列对象
                Line line = this._table.Lines[i];
                //生成注释
                code.AppendLine("                //将" + line.LineNote + "进行按位异或运算处理");
                //判断除了这个是否还有属性如果有就加上“^”否则就加分号
                if (i != this._table.Lines.Count - 1)
                {
                    //判断当前属性在C#中是否可以为空！
                    if (line.Type.CShapIsNull)
                    {
                        //存入空行
                        code.Append("                ");
                        //调用生成方法
                        this.CreateGetHashCodeNullCode(line, code);
                        //存入结尾
                        code.AppendLine(" ^");
                    }
                    else
                    {
                        //生成代码
                        code.AppendLine("                this." + line.PublicAttributeName + ".GetHashCode() ^");
                    }
                }
                else
                {
                    //判断当前属性在C#中是否可以为空！
                    if (line.Type.CShapIsNull)
                    {
                        //存入空行
                        code.Append("                ");
                        //调用生成方法
                        this.CreateGetHashCodeNullCode(line, code);
                        //存入结尾
                        code.AppendLine(";");
                    }
                    else
                    {
                        //生成代码
                        code.AppendLine("                this." + line.PublicAttributeName + ".GetHashCode();");
                    }
                }
            }
            //存入回括号
            code.AppendLine("        }");
        }
        /// <summary>
        /// 生成ToString方法代码的方法
        /// </summary>
        /// <param name="code">存储生成的ToString方法代码的字符串</param>
        private void CreateToStringFunction(StringBuilder code)
        {
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 将当前" + this._table.TableNote + "数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        /// <returns>字符串形式副本</returns>");
            code.AppendLine("        public override string ToString()");
            code.AppendLine("        {");
            code.AppendLine("            //将当前" + this._table.TableNote + "数据模型对象转换成字符串副本");
            code.AppendLine("            return");
            code.AppendLine("                \"[\" +");
            //得到当前表在数据库中不能为空的列
            List<Line> lines = this._table.GetNotNullLines();
            //循环将这些列存入
            for (int i = 0; i < lines.Count; i++)
            {
                //得到列对象
                Line line = lines[i];
                //将注释存入
                code.AppendLine("                //将" + line.LineNote + "转换成字符串");
                //判断是否还有下一个属性
                if (i != lines.Count - 1)
                {
                    //将内容存入
                    code.AppendLine("                this." + line.PublicAttributeName + " + \",\" +");
                }
                else
                {
                    //将内容存入
                    code.AppendLine("                this." + line.PublicAttributeName + " +");
                }
            }
            //将字符串回括号存入
            code.AppendLine("                \"]\";");
            //方法回括号存入
            code.AppendLine("        }");
        }
        /// <summary>
        /// 哈希代码中有可以为null的对象必须进行判断处理
        /// </summary>
        /// <param name="line">要进行判断的列</param>
        /// <returns>返回判断代码例如：(this.UName == null ? 0 : this.UName.GetHashCode())</returns>
        /// <param name="code">存储代码的字符串</param>
        private void CreateGetHashCodeNullCode(Line line, StringBuilder code)
        {
            //存储代码
            code.Append("(this." + line.PublicAttributeName + " == null ? 2147483647 : this." + line.PublicAttributeName +
                              ".GetHashCode())");
        }
    }
}
