using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.CreateCode.CreateMVC
{
    /// <summary>
    /// Mvc设置类
    /// </summary>
    public class MvcSetObject
    {
        /// <summary>
        /// 类所在命名空间
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// 数据库访问类名称
        /// </summary>
        public string SqlVisitClassName { get; set; }
        /// <summary>
        /// 数据访问层类后缀名称
        /// </summary>
        public string DalName { get; set; }
        /// <summary>
        /// 业务逻辑处理层类后缀名称
        /// </summary>
        public string BllName { get; set; }
        /// <summary>
        /// 数据模型层类后缀名称
        /// </summary>
        public string ModelName { get; set; }
    }
}
