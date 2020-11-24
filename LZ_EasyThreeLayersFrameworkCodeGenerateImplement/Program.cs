using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    static class Program
    {
        /// <summary>
        /// 数据库集合
        /// </summary>
        public static List<DataBase> DataBaseList = new List<DataBase>();
        /// <summary>
        /// 当前服务器名称
        /// </summary>
        public static string ServerName;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SqlServerRegisterForm());
            //判断集合中是否填写了元素
            if (Program.DataBaseList.Count != 0)
            {
                //显示生成代码设置窗体
                Application.Run(new SetGenerateCodeForm());
            }
        }
    }
}
