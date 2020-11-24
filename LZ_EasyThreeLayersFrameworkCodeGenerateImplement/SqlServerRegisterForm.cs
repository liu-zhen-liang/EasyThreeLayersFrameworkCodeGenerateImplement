using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    public partial class SqlServerRegisterForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlServerRegisterForm()
        {
            //加载控件
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQL_Server_RegisterForm_Load(object sender, EventArgs e)
        {
            //将当前电脑的IP与服务器名称显示在服务器名称下拉框中
            //将当前电脑的名称存入下拉框
            this.cbServerName.Items.Add(Dns.GetHostName());
            //将当前电脑的IP存入下拉框
            this.cbServerName.Items.Add(Dns.GetHostAddresses(Dns.GetHostName())[1].ToString());
            //默认选择第一个项
            this.cbServerName.SelectedIndex = 0;
            //设置下默认选择Windows身份验证
            this.cbIdentityTestAndVerifyType.SelectedIndex = 1;
        }
        /// <summary>
        /// 选择验证方式更改触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbIdentityTestAndVerifyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断是否选择的是Windows身份验证
            //更改登录名、密码框是否可用
            this.txtRegisterName.Enabled = this.txtPassword.Enabled = this.cbIdentityTestAndVerifyType.SelectedIndex != 1;
        }
        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttCancel_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            this.Close();
        }
        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttRegister_Click(object sender, EventArgs e)
        {
            //判断是否填写了服务器名称
            if (this.cbServerName.Text.Length == 0)
            {
                //弹出警告信息
                Tool.ShowWarnMessage("服务器名称不能为空！\r\n服务器名称可以尝试使用“机器名称”或者IP、“(local)”、“.”试一下！");
                //退出方法
                return;
            }
            //创建连接字符串
            string sqlJoinStr;
            //判断选择的验证方式是否为“SQL Server 身份认证”
            if (this.cbIdentityTestAndVerifyType.SelectedIndex == 0)
            {
                //判断用户名是否为空，密码可以设置为空所以不进行匹配！
                if (this.txtRegisterName.Text.Length == 0)
                {
                    //弹出警告信息
                    Tool.ShowWarnMessage("服务器名称不能为空！");
                    //退出方法
                    return;
                }
                //设置连接字符串
                sqlJoinStr =
                    "Data Source=" + this.cbServerName.Text + ";Network Library = DBMSSOCN;INITIAL CATALOG={0};User ID = " + this.txtRegisterName.Text + ";Password = " + this.txtPassword.Text + ";";
            }
            else
            {
                //设置连接字符串
                sqlJoinStr = "Data Source=" + this.cbServerName.Text +
                ";INITIAL CATALOG={0};integrated Security=true;";
            }
            //创建连接对象
            using (SqlConnection sqlConnection = new SqlConnection(string.Format(sqlJoinStr, "master")))
            {
                //判断是否连接失败
                try
                {
                    //打开连接
                    sqlConnection.Open();
                }
                catch
                {
                    //弹出错误信息
                    Tool.ShowMistakeMessage("连接服务器或获取数据信息失败！\r\n1.请检查服务器地址或用户名密码是否正确！\r\n2.请确保是SQL Server正式版，而非SQLEXPRESS版！\r\n3.如果连接失败，服务器名可以尝试用“机器名”代替IP，或者“(local)”或是“.”试一下！");
                    //退出方法
                    return;
                }
                //创建执行SQL语句对象
                using (SqlCommand sqlCommand = new SqlCommand("Exec sp_databases;", sqlConnection))
                {
                    //得到所有查找到的数据库
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        //判断是否查找到了数据
                        if (sqlReader.HasRows)
                        {
                            //循环查询数据
                            while (sqlReader.Read())
                            {
                                //创建数据库对象
                                DataBase db = new DataBase(sqlReader.GetString(0), sqlJoinStr);
                                //将得到的数据存入集合
                                Program.DataBaseList.Add(db);
                            }
                            //将当前服务器名称存入
                            Program.ServerName = this.cbServerName.Text;
                            //关闭当前窗体
                            this.Close();
                        }
                        else
                        {
                            //弹出错误信息
                            Tool.ShowMistakeMessage("未找到任何数据库数据！！！");
                        }
                    }
                }
            }
        }
    }
}
