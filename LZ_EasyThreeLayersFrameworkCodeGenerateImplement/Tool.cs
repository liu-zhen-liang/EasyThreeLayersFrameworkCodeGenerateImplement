using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement
{
    /// <summary>
    /// 工具静态类
    /// </summary>
    public static class Tool
    {
        /// <summary>
        /// 弹出警告信息框
        /// </summary>
        /// <param name="mesValue">要显示的警告信息内容</param>
        public static void ShowWarnMessage(string mesValue)
        {
            //显示警告信息内容
            MessageBox.Show(mesValue, "三层代码生成器 - 警告信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        /// <summary>
        /// 弹出错误信息框
        /// </summary>
        /// <param name="mesValue">要显示的错误信息内容</param>
        public static void ShowMistakeMessage(string mesValue)
        {
            //显示错误内容
            MessageBox.Show(mesValue, "三层代码生成器 - 错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 弹出提示信息框
        /// </summary>
        /// <param name="mesValue">要显示的提示信息内容</param>
        public static void ShowPromptMessage(string mesValue)
        {
            //显示提示内容
            MessageBox.Show(mesValue, "三层代码生成器 - 提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        /// <summary>
        /// 将字符串首字母大写方法
        /// </summary>
        /// <param name="value">要进行首字母大写的字符串</param>
        /// <returns>首字母大写后的字符串</returns>
        public static string FirstLetterUpper(string value)
        {
            //判断字符串首字符是否为小写，如果是小写就进行转换否则就不需要进行转换
            if (char.IsLower(value[0]))
            {
                //将传入字符串转换成字符数组
                char[] chars = value.ToArray();
                //将字符的单第一个进行大写处理
                chars[0] = char.ToUpper(chars[0]);
                //将字符数组转换成字符串并返回
                return new string(chars);
            }
            //返回原字符串
            return value;
        }
        /// <summary>
        /// 将字符串首字符进行小写处理
        /// </summary>
        /// <param name="value">要进行处理的字符串</param>
        /// <returns>处理完成的字符串</returns>
        public static string FirstLetterLower(string value)
        {
            //判断原字符串是否为大写，如果为大写就进行转换否则就不进行转换直接返回原字符串
            if (char.IsUpper(value[0]))
            {
                //将传入的字符串转换成字符数组
                char[] chars = value.ToArray();
                //将首字符进行小写处理
                chars[0] = char.ToLower(chars[0]);
                //将字符数组转换成字符串并返回
                return new string(chars);
            }
            //返回原字符串
            return value;
        }
        /// <summary>
        /// 移除前缀方法
        /// </summary>
        /// <param name="value">原字符串</param>
        /// <param name="prefix">去除的前缀</param>
        /// <param name="isIgnoreBigOrSmall">是否忽略大小写</param>
        /// <returns>结果</returns>
        public static string RemovePrefix(string value, string prefix, bool isIgnoreBigOrSmall)
        {
            //判断去除的前缀是否大于原字符串，如果大于就返回原字符串
            if (value == null || prefix == null || prefix.Length > value.Length) return value;
            //判断是否忽略大小写
            if (isIgnoreBigOrSmall)//忽略大小写
            {
                //创建存储转换成小写的字符串
                string lowValue = value.ToLower();
                string lowPrefix = prefix.ToLower();
                //循环进行判断是否匹配
                int i;
                for (i = 0; i < lowPrefix.Length; i++)
                {
                    //判断是否匹配
                    if (lowPrefix[i] != lowValue[i]) break;
                }
                //判断是否匹配完成
                if (i == lowPrefix.Length)
                {
                    //进行移除处理并返回结果
                    return value.Remove(0, lowPrefix.Length);
                }
            }
            else//不忽略大小写
            {
                //循环进行匹配是否一致
                int i;
                for (i = 0; i < prefix.Length; i++)
                {
                    //判断是否匹配
                    if (prefix[i] != value[i]) break;
                }
                //判断是否匹配完成
                if (i == prefix.Length)
                {
                    //进行移除处理并返回结果
                    return value.Remove(0, prefix.Length);
                }
            }
            //返回原来的字符串
            return value;
        }
        /// <summary>
        /// 将TimeSpan对象转换成字符串
        /// </summary>
        /// <param name="ts">要进行转换的TimeSpan对象</param>
        /// <returns>转换完成的TimeSpan字符串形式</returns>
        public static string TimeSpanToString(TimeSpan ts)
        {
            bool flag = false;
            StringBuilder stringBuilder = new StringBuilder();
            if (ts.Days > 0)
            {
                stringBuilder.Append(ts.Days.ToString() + "天");
                flag = true;
            }
            if (ts.Hours > 0 || flag)
            {
                stringBuilder.Append(ts.Hours.ToString() + "小时");
                flag = true;
            }
            if (ts.Minutes > 0 || flag)
            {
                stringBuilder.Append(ts.Minutes.ToString() + "分钟");
                flag = true;
            }
            if (ts.Seconds > 0 || flag)
            {
                stringBuilder.Append(ts.Seconds.ToString() + "秒");
                flag = true;
            }
            if (ts.TotalMilliseconds > 0.0 || flag)
            {
                stringBuilder.Append(ts.TotalMilliseconds.ToString() + "毫秒");
            }
            return stringBuilder.ToString();
        }
    }
}
