using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LZ_EasyThreeLayersFrameworkCodeGenerateImplement.ObjectCodeFiles;

namespace LZ_EasyThreeLayersFrameworkCodeGenerateImplement.CreateCode.CreateMVC
{
    /// <summary>
    /// 生成简单三层架构代码的对象
    /// </summary>
    public class CreateMvcObject
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
        /// 创建当前生成简单三层架构的对象并初始化值
        /// </summary>
        /// <param name="tabe">要进行生成的表集合</param>
        /// <param name="mvcSet">MVC生成设置</param>
        public CreateMvcObject(Table tabe, MvcSetObject mvcSet)
        {
            //进行赋值
            this._table = tabe;
            this._mvcSetObject = mvcSet;
        }
        /// <summary>
        /// 生成MVC【简单三层架构】的数据模型层代码方法
        /// </summary>
        /// <returns>数据模型层代码</returns>
        public string CreateMvcModelClassCode()
        {
            //创建对象并返回值
            return new MvcModelObject(this._table, this._mvcSetObject).CreateMvcModelClassCode();
        }
        /// <summary>
        /// 生成MVC【简单三层架构】的数据访问层代码方法
        /// </summary>
        /// <returns>数据访问层代码</returns>
        public string CreateMvcDalClassCode()
        {
            //创建对象并返回值
            return new MvcDalObject(this._table, this._mvcSetObject).CreateMvcDalClassCode();
        }
        /// <summary>
        /// 生成MVC【简单三层架构】的业务逻辑层代码方法
        /// </summary>
        /// <returns>业务逻辑层代码</returns>
        public string CreateMvcBllClassCode()
        {
            //创建对象并返回值
            return new MvcBllObject(this._table, this._mvcSetObject).CreateMvcBllClassCode();
        }
    }
}
