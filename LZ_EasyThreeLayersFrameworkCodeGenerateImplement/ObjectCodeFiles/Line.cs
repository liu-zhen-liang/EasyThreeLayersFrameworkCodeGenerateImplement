using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles
{
    /// <summary>
    /// 列对象
    /// </summary>
    public class Line
    {
        /// <summary>
        /// 实例化当前对象
        /// </summary>
        public Line()
        {
            
        }
        /// <summary>
        /// 创建当前列对象并进行赋值
        /// </summary>
        /// <param name="lineName">列对象名称</param>
        /// <param name="table">父表格对象</param>
        public Line(string lineName, Table table)
        {
            //赋值
            this.LineName = lineName;
            //设置列注释就是列名称
            this.LineNote = lineName;
            //赋值父表格
            this.FathertTable = table;
        }
        /// <summary>
        /// 列名称【在数据库中的原列名称，没有进行处理！！！】
        /// </summary>
        public string LineName { get; private set; }
        /// <summary>
        /// 列名称【在代码中的名称】
        /// </summary>
        public string LineCodeName { get; set; }
        /// <summary>
        /// 列注释
        /// </summary>
        public string LineNote { get; set; }
        /// <summary>
        /// 当前列是否自动增长
        /// </summary>
        public bool IsAutomaticIncrease { get; set; }
        /// <summary>
        /// 父表格对象
        /// </summary>
        public Table FathertTable { get; private set; }
        /// <summary>
        /// 当前表在数据模型层中的类名称
        /// </summary>
        public string ModelName
        {
            get { return this.FathertTable.TableCodeName + "." + this.LineCodeName; }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 小数
        /// </summary>
        public int Decimals { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Explain { get; set; }
        /// <summary>
        /// 数据库变量的名称字符串例如：@id
        /// </summary>
        public string SqlVariableName
        {
            get { return "@" + this.PrivateAttributeName; }
        }
        /// <summary>
        /// 返回当前列私有属性的命名的字符串例如：iD
        /// </summary>
        public string PrivateAttributeName
        {
            get
            {
                //返回当前属性的代码名称首字母小写处理
                return Tool.FirstLetterLower(this.LineCodeName);
            }
        }
        /// <summary>
        /// 返回当前列共有属性的命名字符串例如：ID
        /// </summary>
        public string PublicAttributeName
        {
            get
            {
                //返回当前属性的代码名称首字母大写处理
                return Tool.FirstLetterUpper(this.LineCodeName);
            }
        }
        /// <summary>
        /// 得到当前属性更改成SQL参数的字符串例如：
        /// new SqlParameter("@uiID",SqlDbType.Int,4)
        /// </summary>
        public string GetSqlParameter
        {
            get
            {
                //返回连接完成的值
                return string.Format("new SqlParameter(\"{0}\",SqlDbType.{1},{2})",
                    //将数据库命名的字符串存入
                    this.SqlVariableName,
                    //将当前列的数据库类型存入
                    this.Type.SqlTypeEnum.ToString(),
                    //将位数数量存入
                    this.Type.SqlLength.ToString()
                    );
            }
        }
        /// <summary>
        /// 将当列创建一个变量的字符串例如：
        /// 格式：[C#类型] [名称]
        /// int id
        /// </summary>
        public string GetNewCShapvVriableString
        {
            get
            {
                //返回值
                return this.Type.CShapTypeString + " " + this.PrivateAttributeName;
            }
        }
        /// <summary>
        /// 得到一条XML属性文档注释
        /// </summary>
        /// <returns>XML文档注释</returns>
        public string CreateXmlSetNote()
        {
            //返回XML属性注释
            return string.Format("/// <param name=\"{0}\">{1}</param>", this.PrivateAttributeName,
                this.LineNote);
        }
        /// <summary>
        /// 当前列的数据类型对象
        /// </summary>
        public SqlType Type { get; set; }
        /// <summary>
        /// 将当前对象转换成ListViewItem对象
        /// </summary>
        /// <returns>ListViewItem对象</returns>
        public ListViewItem GetListViewItem()
        {
            //创建ListViewItem对象
            ListViewItem lvi = new ListViewItem(new string[]
            {
                //将列名称存入
                this.LineName,
                //将列注释存入
                this.LineNote
            });
            //将对象和此对象绑定
            lvi.Tag = this;
            //返回当前对象
            return lvi;
        }
    }
}
