﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LZ_ThreeLayersFrameworkCodeGenerateImplement.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;configuration&gt;
        ///  &lt;connectionStrings&gt;
        ///    &lt;!--name为键 connectionString为值--&gt;
        ///    &lt;add name=&quot;SqlJoin&quot; connectionString=&quot;@连接字符串&quot;/&gt;
        ///  &lt;/connectionStrings&gt;
        ///&lt;/configuration&gt; 的本地化字符串。
        /// </summary>
        internal static string App {
            get {
                return ResourceManager.GetString("App", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;!DOCTYPE html&gt;
        ///&lt;html lang=&quot;en&quot; xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
        ///&lt;head&gt;
        ///    &lt;meta charset=&quot;utf-8&quot; /&gt;
        ///    &lt;title&gt;@数据库名称数据库表信息&lt;/title&gt;
        ///    &lt;style type=&quot;text/css&quot;&gt;
        ///        /* Body style, for the entire document */
        ///        body {
        ///            background: #F3F3F4;
        ///            color: #1E1E1F;
        ///            font-family: &quot;Segoe UI&quot;, Tahoma, Geneva, Verdana, sans-serif;
        ///            padding: 0;
        ///            margin: 0;
        ///        }
        ///        /* Header1 style, used for the main title */
        ///        h1 {
        ///        [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string HtmlShowTableInformation {
            get {
                return ResourceManager.GetString("HtmlShowTableInformation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Bitmap SQL_ServerLOGO {
            get {
                object obj = ResourceManager.GetObject("SQL_ServerLOGO", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 using System;
        ///using System.Collections.Generic;
        ///using System.Configuration;
        ///using System.Data;
        ///using System.Data.SqlClient;
        ///using System.Linq;
        ///using System.Text;
        ///
        ///namespace 要被替换的命名空间
        ///{
        ///    /// &lt;summary&gt;连接数据库的对象
        ///    /// 
        ///    /// &lt;/summary&gt;
        ///    public static class SqlDataBase
        ///    {
        ///        //SQL连接字符串【记得引用程序集System.Configuration】
        ///        private readonly static string SqlJoinString = ConfigurationManager.ConnectionStrings[&quot;SqlJoin&quot;].ConnectionString;
        ///        /// &lt;summary&gt;执行对数据库进行（增、删、改）方法
        ///    [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string SqlDataBase {
            get {
                return ResourceManager.GetString("SqlDataBase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///
        ///&lt;!--
        ///  有关如何配置 ASP.NET 应用程序的详细信息，请访问
        ///  http://go.microsoft.com/fwlink/?LinkId=169433
        ///  --&gt;
        ///
        ///&lt;configuration&gt;
        ///  &lt;connectionStrings&gt;
        ///    &lt;!--name为键 connectionString为值--&gt;
        ///    &lt;add name=&quot;SqlJoin&quot; connectionString=&quot;@连接字符串&quot;/&gt;
        ///  &lt;/connectionStrings&gt;
        ///    &lt;system.web&gt;
        ///      &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
        ///    &lt;/system.web&gt;
        ///&lt;/configuration&gt;
        /// 的本地化字符串。
        /// </summary>
        internal static string Web {
            get {
                return ResourceManager.GetString("Web", resourceCulture);
            }
        }
    }
}