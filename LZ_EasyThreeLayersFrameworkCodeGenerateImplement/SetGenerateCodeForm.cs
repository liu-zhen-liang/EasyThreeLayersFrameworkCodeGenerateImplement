using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.CreateCode.CreateMVC;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    public partial class SetGenerateCodeForm : Form
    {
        /// <summary>
        /// 存储设置列清除前缀窗体
        /// </summary>
        private RemoveLinePrefixForm removeLinePrefixForm;
        /// <summary>
        /// 选择的数据库对象【要进行生成代码的数据库对象】
        /// </summary>
        private DataBase SelectDataBase;
        /// <summary>
        /// 创建实例对象
        /// </summary>
        public SetGenerateCodeForm()
        {
            //加载控件
            InitializeComponent();
            //创建设置列去除前缀的窗体
            this.removeLinePrefixForm = new RemoveLinePrefixForm(this);
        }
        /// <summary>
        /// ListView的鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //得到当前ListView控件
            ListView listView = sender as ListView;
            //得到点击的位置的项
            ListViewItem listViewItem = listView.GetItemAt(e.X, e.Y);
            //得到要获取的索引位置
            int index = listViewItem.SubItems.Count - 1;
            //得到注释项的位置及大小
            Rectangle rectangle = listViewItem.SubItems[index].Bounds;
            //生成一个文本框
            TextBox textBox = new TextBox();
            //设置文本框样式
            textBox.BorderStyle = BorderStyle.FixedSingle;
            //给文本框失去焦点触发事件【失去焦点得将输入的值重新设置回去】
            textBox.LostFocus += (obj, evt) =>
            {
                //将值设置回去
                listViewItem.SubItems[index].Text = textBox.Text;
                //判断是否是表格对象
                if (listViewItem.Tag is Table)
                {
                    //转换成表格对象并设置注释
                    (listViewItem.Tag as Table).TableNote = textBox.Text;
                }
                //判断是否为列对象
                else if (listViewItem.Tag is Line)
                {
                    //转换成列对象并设置注释
                    (listViewItem.Tag as Line).LineNote = textBox.Text;
                }
                //将当前控件关闭掉，并释放资源
                textBox.Dispose();
            };
            //注册按键事件
            textBox.KeyDown += (obj, evt) =>
            {
                //判断按下的键位是否为确定键
                if (evt.KeyCode == Keys.Enter)
                {
                    //将值设置回去
                    listViewItem.SubItems[index].Text = textBox.Text;
                    //判断是否是表格对象
                    if (listViewItem.Tag is Table)
                    {
                        //转换成表格对象并设置注释
                        (listViewItem.Tag as Table).TableNote = textBox.Text;
                    }
                    //判断是否为列对象
                    else if (listViewItem.Tag is Line)
                    {
                        //转换成列对象并设置注释
                        (listViewItem.Tag as Line).LineNote = textBox.Text;
                    }
                    //将当前控件关闭掉，并释放资源
                    textBox.Dispose();
                }
            };
            //设置文本框值为注释项的值
            textBox.Text = listViewItem.SubItems[index].Text;
            //设置文本框大小
            textBox.Bounds = rectangle;
            //将当前文本框存入父容器控件
            listView.Controls.Add(textBox);
            //设置焦点
            textBox.Focus();
        }
        /// <summary>
        /// 窗体加载完成触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetGenerateCodeForm_Load(object sender, EventArgs e)
        {
            //将数据库中所有信息存入下拉框
            this.cbDataBaseList.DataSource = Program.DataBaseList;
        }
        /// <summary>
        /// 选择数据库下拉框发生改变触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDataBaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //将当前服务器地址显示出来
            this.labServerName.Text = "当前服务器：" + Program.ServerName;
            //得到选择的数据库并设置
            this.SelectDataBase = this.cbDataBaseList.SelectedItem as DataBase;
            //得到选择的数据库中的所有表信息
            this.SelectDataBase.GetAllTable();

            //将选择不要进行生成的表与要生成的表的ListBox控件中的元素清空
            this.lbNotSelectTableList.Items.Clear();
            this.lbSelectTableList.Items.Clear();

            //将选择的数据库中的表存入显示不要进行生成的表的ListBox控件中
            foreach (Table table in this.SelectDataBase.Tables)
            {
                //将元素存入
                this.lbNotSelectTableList.Items.Add(table);
            }
            //调用刷新方法
            this.RefreshSelectTable();
        }
        /// <summary>
        /// 点击将没有选择的表全部移动到选择表的ListBox中按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAllToSelectTable_Click(object sender, EventArgs e)
        {
            //调用全部移动方法
            this.ListBoxAllMove(this.lbNotSelectTableList, this.lbSelectTableList);
            //调用刷新方法
            this.RefreshSelectTable();
        }
        /// <summary>
        /// 将ListBoxA的所有项移动到ListBoxB中
        /// </summary>
        /// <param name="listBoxA">A项</param>
        /// <param name="listBoxB">B项</param>
        public void ListBoxAllMove(ListBox listBoxA, ListBox listBoxB)
        {
            //循环将A项中所有项添加到B项中
            foreach (var item in listBoxA.Items)
            {
                //将元素添加到ListBoxB中
                listBoxB.Items.Add(item);
            }
            //删除A中所有项
            listBoxA.Items.Clear();
        }
        /// <summary>
        /// 将ListBoxA的选择项移动到ListBoxB中
        /// </summary>
        /// <param name="listBoxA">A项</param>
        /// <param name="listBoxB">B项</param>
        public void ListBoxSelectMove(ListBox listBoxA, ListBox listBoxB)
        {
            //开始倒序移动ListBoxA中的选择项到ListBoxB中
            for (int i = listBoxA.SelectedIndices.Count - 1; i >= 0; i--)
            {
                //移动到ListBoxB中并移除此项
                listBoxB.Items.Add(listBoxA.Items[listBoxA.SelectedIndices[i]]);
                //移除此项
                listBoxA.Items.RemoveAt(listBoxA.SelectedIndices[i]);
            }
        }
        /// <summary>
        /// 将选择的项移动到要进行处理的表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSelectToSelectTable_Click(object sender, EventArgs e)
        {
            //调用移除选择项方法
            this.ListBoxSelectMove(this.lbNotSelectTableList, this.lbSelectTableList);
            //调用刷新方法
            this.RefreshSelectTable();
        }
        /// <summary>
        /// 移动选择项到不要处理的表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSelectToNotSelectTable_Click(object sender, EventArgs e)
        {
            //调用移动选择项方法
            this.ListBoxSelectMove(this.lbSelectTableList, this.lbNotSelectTableList);
            //调用刷新方法
            this.RefreshSelectTable();
        }
        /// <summary>
        /// 将要进行处理的表全部移动到不要进行处理的表集合中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttAllToNotSelectTable_Click(object sender, EventArgs e)
        {
            //调用移动全部方法
            this.ListBoxAllMove(this.lbSelectTableList, this.lbNotSelectTableList);
            //调用刷新方法
            this.RefreshSelectTable();
        }
        /// <summary>
        /// 选择表发生改变触发的事件
        /// </summary>
        public event Action<ListBox> RefreshSelectTableEvent;
        /// <summary>
        /// 更改要进行生成代码的项触发的事件
        /// </summary>
        private void RefreshSelectTable()
        {
            //清除所有表注释项
            this.lvTableNote.Items.Clear();
            //将属性清空
            this.lvLineNote.Items.Clear();
            //循环将所有要添加的项存入
            foreach (Table table in this.lbSelectTableList.Items)
            {
                //将元素存入
                this.lvTableNote.Items.Add(table.ToListViewItem());
            }
            //判断是否为空，如果不为空就触发事件
            if (this.RefreshSelectTableEvent != null) this.RefreshSelectTableEvent(this.lbSelectTableList);
        }
        /// <summary>
        /// 选择表发生改变触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvTableNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            //得到选择的项
            if (this.lvTableNote.SelectedItems.Count > 0)
            {
                //得到选择的项的表
                Table table = this.lvTableNote.SelectedItems[0].Tag as Table;
                //清除所有视图
                this.lvLineNote.Items.Clear();
                //循环将其元素存入
                foreach (Line line in table.Lines)
                {
                    //将元素存入
                    this.lvLineNote.Items.Add(line.GetListViewItem());
                }
            }
        }
        /// <summary>
        /// 点击选择路径按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSelectSavePath_Click(object sender, EventArgs e)
        {
            //创建选择文件夹的窗体对象
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //设置默认停留的路径位置
            fbd.SelectedPath = this.txtSavePath.Text;
            //创建选择文件夹窗体
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //得到选择的路径
                this.txtSavePath.Text = fbd.SelectedPath;
            }

        }
        /// <summary>
        /// 点击显示去除列前缀窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttSetRemoveLinePrefix_Click(object sender, EventArgs e)
        {
            //显示窗体
            this.removeLinePrefixForm.Show();
        }
        /// <summary>
        /// 点击生成代码触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttBgeinCreateCode_Click(object sender, EventArgs e)
        {
            //判断是否填写了数据库访问类名称
            if (this.txtDataBaseClassName.Text.Length == 0)
            {
                //弹出警告
                Tool.ShowWarnMessage("数据库访问类对象名称不能为空！！！");
                //退出方法
                return;
            }
            //判断是否填写了命名空间
            if (this.txtNamespace.Text.Length == 0)
            {
                //弹出警告
                Tool.ShowWarnMessage("命名空间不能为空！！！");
                //退出方法
                return;
            }
            //判断是否选择了要进行生成代码的表
            if (this.lbSelectTableList.Items.Count == 0)
            {
                //弹出警告
                Tool.ShowWarnMessage("请先选择要进行生成代码的表！！！");
                //退出方法
                return;
            }
            //得到当前是否为Web项目
            bool isWeb = this.cbIsWeb.Checked;
            //得到选择的数据库对象
            DataBase selectDataBase = this.cbDataBaseList.SelectedItem as DataBase;
            //得到要进行生成代码的表对象【数量等于选择要进行处理的表的数量】
            List<Table> tabeList = new List<Table>(this.lbSelectTableList.Items.Count);

            #region 得到要进行生成代码的表
            //循环进行存入
            foreach (Table table in this.lbSelectTableList.Items)
            {
                //将值存入集合
                tabeList.Add(table);
                //设置表去除前缀后的内容
                table.TableCodeName = Tool.RemovePrefix(table.TableName, this.txtDeletePrefix.Text,
                    this.cbIgnoreBigOrSmall.Checked);
                //设置表在模型层名称
                table.ModelName = table.TableCodeName + this.txtModelName.Text;
                //设置表在数据存储层名称
                table.DalName = table.TableCodeName + this.txtDalName.Text;
                //设置表在业务逻辑层名称
                table.BllName = table.TableCodeName + this.txtBllName.Text;
                //循环设置列代码名称
                foreach (Line line in table.Lines)
                {
                    //设置代码名称【去除前缀】
                    line.LineCodeName = Tool.RemovePrefix(line.LineName, table.LineRemovePrefix, false);
                }
            }
            //得到设置对象
            MvcSetObject mvcSetObject = new MvcSetObject()
            {
                //设置命名空间名称
                Namespace = this.txtNamespace.Text,
                //设置Sql类的名称
                SqlVisitClassName = this.txtDataBaseClassName.Text,
                //设置数据存储层类后缀
                DalName = this.txtDalName.Text,
                //设置业务逻辑处理层后缀
                BllName = this.txtBllName.Text,
                //设置数据模型对象后缀
                ModelName = this.txtModelName.Text
            };
            #endregion

            //得到要进行保存的路径
            string savePath = this.txtSavePath.Text;
            //得到Model【数据模型】层文件夹路径
            string modelSavePath = Path.Combine(savePath, "Model");
            //判断路径是否存在，如果不存在就创建
            if (!Directory.Exists(modelSavePath))
                //生成文件夹
                Directory.CreateDirectory(modelSavePath);
            //得到BLL【业务逻辑】层文件夹路径
            string bllSavePath = Path.Combine(savePath, "BLL");
            //判断路径是否存在，如果不存在就创建
            if (!Directory.Exists(bllSavePath))
                //生成文件夹
                Directory.CreateDirectory(bllSavePath);
            //得到DAL【数据访问】层文件夹路径
            string dalSavePath = Path.Combine(savePath, "DAL");
            //判断路径是否存在，如果不存在就创建
            if (!Directory.Exists(dalSavePath))
                //生成文件夹
                Directory.CreateDirectory(dalSavePath);
            //设置开始生成按钮不可用
            this.buttBgeinCreateCode.Enabled = false;
            //设置进度条最大值
            this.pbSchedule.Maximum = tabeList.Count;
            //设置进度条当前值
            this.pbSchedule.Value = 0;
            //开启线程
            ThreadPool.QueueUserWorkItem((a) =>
            {
                //创建计时对象
                Stopwatch stopwatch = new Stopwatch();
                //开始计时
                stopwatch.Start();
                //循环生成代码
                foreach (Table table in tabeList)
                {
                    //创建生成MVC【简单三层架构】代码对象
                    CreateMvcObject createMvcObject = new CreateMvcObject(table, mvcSetObject);
                    //调用生成数据模型层代码方法
                    string mvcModCode = createMvcObject.CreateMvcModelClassCode();
                    //调用生成业务逻辑层代码方法
                    string mvcBllCode = createMvcObject.CreateMvcBllClassCode();
                    //调用生成数据访问层代码方法
                    string mvcDalCode = createMvcObject.CreateMvcDalClassCode();

                    //保存生成的数据模型层代码方法
                    File.WriteAllText(Path.Combine(modelSavePath, (table.ModelName + ".cs")), mvcModCode, Encoding.UTF8);
                    //保存生成的业务逻辑层代码方法
                    File.WriteAllText(Path.Combine(bllSavePath, (table.BllName + ".cs")), mvcBllCode, Encoding.UTF8);
                    //保存生成的数据访问层代码方法
                    File.WriteAllText(Path.Combine(dalSavePath, (table.DalName + ".cs")), mvcDalCode, Encoding.UTF8);
                    //在当前进度条创建线程中执行内容
                    this.pbSchedule.BeginInvoke(new Action(() =>
                    {
                        //设置进度条值++
                        this.pbSchedule.Value++;
                        //得到百分比
                        this.labSchedule.Text = (((double)this.pbSchedule.Value / (double)this.pbSchedule.Maximum) * 100D).ToString("0.0") + "%";
                    }));
                }
                //得到SqlDataBase文件的文本
                string sqlDataBaseString =
                    global::LZ_EasyThreeLayersFrameworkCodeGenerateImplement.Properties.Resources.SqlDataBase;
                //替换命名空间
                sqlDataBaseString = sqlDataBaseString.Replace("要被替换的命名空间", (mvcSetObject.Namespace + ".DAL"));
                //判断数据库访问类名称是否不等于“SqlDataBase”如果不等于就进行替换，否则就不进行替换
                if (mvcSetObject.SqlVisitClassName != "SqlDataBase")
                    //替换类名称
                    sqlDataBaseString = sqlDataBaseString.Replace("SqlDataBase", mvcSetObject.SqlVisitClassName);
                //将当前类进行保存
                File.WriteAllText(Path.Combine(dalSavePath, (mvcSetObject.SqlVisitClassName + ".cs")), sqlDataBaseString,
                    Encoding.UTF8);
                //判断是Web项目不？
                if (isWeb)
                {
                    //得到模板Web配置文件
                    string webConfig = global::LZ_EasyThreeLayersFrameworkCodeGenerateImplement.Properties.Resources.Web;
                    //将连接字符串替换进入
                    webConfig = webConfig.Replace("@连接字符串", selectDataBase.SqlJoin);
                    //保存Web配置文件
                    File.WriteAllText(Path.Combine(savePath, "Web.config"), webConfig, Encoding.UTF8);
                }
                else
                {
                    //得到模板App配置文件
                    string appConfig = global::LZ_EasyThreeLayersFrameworkCodeGenerateImplement.Properties.Resources.App;
                    //将连接字符串替换进入
                    appConfig = appConfig.Replace("@连接字符串", selectDataBase.SqlJoin);
                    //保存app配置文件
                    File.WriteAllText(Path.Combine(savePath, "App.config"), appConfig, Encoding.UTF8);
                }
                //判断是否需要生成表图
                if (this.cbCreateTableHTML.Checked)
                {
                    //创建存储内容的字符串对象
                    StringBuilder code = new StringBuilder();
                    //循环生成代码
                    foreach (Table table in tabeList)
                    {
                        //调用生成代码方法
                        this.ToHtml(table, code);
                    }
                    //除去尾部两个字符\r\n【换行】
                    code.Remove(code.Length - 2, 2);
                    //得到HTML文件
                    string html =
                        global::LZ_EasyThreeLayersFrameworkCodeGenerateImplement.Properties.Resources
                            .HtmlShowTableInformation;
                    //进行替换标题
                    html = html.Replace("@数据库名称", selectDataBase.DataBaseName);
                    //替换内容
                    html = html.Replace("@表信息", code.ToString());
                    //保存生成的html文件
                    File.WriteAllText(Path.Combine(savePath, ("数据库" + selectDataBase.DataBaseName + "表结构图.html")), html, Encoding.UTF8);
                }
                //结束计时
                stopwatch.Stop();
                //用按钮创建的线程中设置内容
                this.buttBgeinCreateCode.BeginInvoke(new Action(() =>
                {
                    //设置按钮为可用
                    this.buttBgeinCreateCode.Enabled = true;
                    //显示生成成功信息
                    Tool.ShowPromptMessage(
                        string.Format(
                            "代码生成完成！生成详细信息：\r\n一共为 {0} 个表生成代码\r\n{0} 个表生成代码成功！\r\n0 个表生成代码失败！\r\n一共用时：{1} \r\n代码保存在：“{2}”路径下！",
                            tabeList.Count, Tool.TimeSpanToString(stopwatch.Elapsed), savePath));
                }));
            });
        }
        /// <summary>
        /// 将指定表格生成为HTML形式
        /// </summary>
        /// <param name="tab">要进行生成的表对象</param>
        /// <param name="code">存储生成完成内容</param>
        public void ToHtml(Table tab, StringBuilder code)
        {
            //生成标题
            code.AppendLine("    <h2>" + tab.TableName + "表</h2>");
            //生成表格
            code.AppendLine("    <table align=\"center\">");
            code.AppendLine("        <tr>");
            code.AppendLine("            <th>序号</th>");
            code.AppendLine("            <th>列名</th>");
            code.AppendLine("            <th>数据类型</th>");
            code.AppendLine("            <th>长度</th>");
            code.AppendLine("            <th>小数位</th>");
            code.AppendLine("            <th>标识</th>");
            code.AppendLine("            <th>主键</th>");
            code.AppendLine("            <th>允许空</th>");
            code.AppendLine("            <th>默认值</th>");
            code.AppendLine("            <th>说明</th>");
            code.AppendLine("        </tr>");
            //循环进行生成标签
            foreach (Line line in tab.Lines)
            {
                code.AppendLine("        <tr>");
                code.AppendLine("            <td>" + line.SerialNumber + "</td>");
                code.AppendLine("            <td>" + line.LineName + "</td>");
                code.AppendLine("            <td>" + line.Type.SqlTypeString + "</td>");
                code.AppendLine("            <td>" + ((line.Type.SqlTypeString == "nvarchar" || line.Type.SqlTypeString == "nchar") ? (line.Type.SqlLength / 2).ToString() : line.Type.SqlLength >= 2147483646 ? "max" : line.Type.SqlLength.ToString()) + "</td>");
                code.AppendLine("            <td>" + line.Decimals + "</td>");
                code.AppendLine("            <td>" + (line.IsAutomaticIncrease ? "是" : "否") + "</td>");
                code.AppendLine("            <td>" + (line.LineName == (tab.PrimaryKey ?? new Line()).LineName ? "是" : "否") + "</td>");
                code.AppendLine("            <td>" + (line.Type.SqlIsNull ? "是" : "否") + "</td>");
                code.AppendLine("            <td>" + (line.DefaultValue ?? "").Replace("(", "").Replace(")", "").Replace("'", "") + "</td>");
                code.AppendLine("            <td>" + line.Explain + "</td>");
                code.AppendLine("        </tr>");
            }
            code.AppendLine("    </table>");
        }
        /// <summary>
        /// 窗体大小发生改变触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetGenerateCodeForm_SizeChanged(object sender, EventArgs e)
        {
            //832, 873
            //要将宽度固定在832，将高度锁定在不能小于873
            //得到高度
            int height = this.Height;
            //判断当前高度是否小于873
            if (height < 873)
            {
                //更改高度为873
                height = 873;
            }
            //设置大小
            this.Size = new Size(832, height);
        }
    }
}
