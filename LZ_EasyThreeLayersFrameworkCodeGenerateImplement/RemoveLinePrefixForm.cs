using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    public partial class RemoveLinePrefixForm : Form
    {
        /// <summary>
        /// 存储生成代码设置窗体字段
        /// </summary>
        private SetGenerateCodeForm setGenerateCodeForm;
        /// <summary>
        /// 创建该对象实例
        /// </summary>
        /// <param name="scvForm"></param>
        public RemoveLinePrefixForm(SetGenerateCodeForm scvForm)
        {
            //加载控件
            InitializeComponent();
            //设置窗体
            this.setGenerateCodeForm = scvForm;
            //注册更改事件
            this.setGenerateCodeForm.RefreshSelectTableEvent += (lb) =>
            {
                //移除所有项
                this.lvLineRemovePrefix.Items.Clear();
                //循环将字符串进行显示在视图中
                foreach (Table table in lb.Items)
                {
                    //得到元素并填入
                    this.lvLineRemovePrefix.Items.Add(table.ToLineRemovePrefixListViewItem());
                }
            };
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLinePrefixForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLinePrefixForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //隐藏当前窗体
            this.Hide();
            //取消关闭窗体
            e.Cancel = true;
        }

        private void lvLineRemovePrefix_MouseDoubleClick(object sender, MouseEventArgs e)
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
                    (listViewItem.Tag as Table).LineRemovePrefix = textBox.Text;
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
                        (listViewItem.Tag as Table).LineRemovePrefix = textBox.Text;
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
    }
}
