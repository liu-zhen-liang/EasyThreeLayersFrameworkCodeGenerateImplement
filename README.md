# 简单三层架构代码生成器
## 1.登录你的数据库服务器
  ![Image text](/img-storage/231e81246ac5448d5e44e26a146cb43a.png)
## 2.编辑页面，可以在此页面进行配置生成的数据库、生成表，以及各个层生成得到后缀名称，表注释字段注释等等
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020112514032644.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzI1MTU0Nw==,size_16,color_FFFFFF,t_70#pic_center)

## 3.选择需要生成的表
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125134557965.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzI1MTU0Nw==,size_16,color_FFFFFF,t_70#pic_center)
## 4.设置命名空间、数据访问类名称，去除表名称前缀，还有各个层的表名称后缀，去除各个表的列名称前缀
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125135201103.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzI1MTU0Nw==,size_16,color_FFFFFF,t_70#pic_center)
## 5.设置表注释，列字段注释
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125135659471.png#pic_center)
## 6.选择生成代码的位置
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125135840438.png#pic_center)
## 7.点击生成按钮生成代码
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125140046518.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzI1MTU0Nw==,size_16,color_FFFFFF,t_70#pic_center)
## 8.生成的代码文件
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125140015303.png#pic_center)
## 9.生成的表结构图
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125140154825.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzI1MTU0Nw==,size_16,color_FFFFFF,t_70#pic_center)
## 10.生成的Model代码
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020112514034537.png#pic_center)

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// 用户表数据模型对象
    /// </summary>
    [Serializable]
    public partial class UserInfoTableMod
    {
        /// <summary>
        /// 初始化用户表数据模型对象
        /// </summary>
        public UserInfoTableMod()
        {
            
        }
        /// <summary>
        /// 初始化用户表数据模型对象并给所有字段赋值
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="name">姓名</param>
        /// <param name="password">密码（MD5）</param>
        /// <param name="isAdmin">是否为管理员</param>
        public UserInfoTableMod(long id,string name,string password,bool isAdmin)
        {
            //给编号字段赋值
            this.Id = id;
            //给姓名字段赋值
            this.Name = name;
            //给密码（MD5）字段赋值
            this.Password = password;
            //给是否为管理员字段赋值
            this.IsAdmin = isAdmin;
        }
        
		//属性存储数据的变量
        private long _id;
        private string _name;
        private string _password;
        private bool _isAdmin;
        
        /// <summary>
        /// 编号
        /// </summary>
        public long Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// 密码（MD5）
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsAdmin
        {
            get { return this._isAdmin; }
            set { this._isAdmin = value; }
        }
        
        /// <summary>
        /// 对比两个用户表数据模型对象是否一致
        /// </summary>
        /// <param name="obj">要进行比对的用户表数据模型对象</param>
        /// <returns>返回是否一致，为true一致，为false不一致</returns>
        public override bool Equals(object obj)
        {
            //判断传入对象是否为null
            if (obj == null) return false;
            //将传入对象转换成用户表数据模型对象
            UserInfoTableMod userInfoTableMod = obj as UserInfoTableMod;
            //判断是否转换成功
            if (userInfoTableMod == null) return false;
            //进行匹配属性的值
            return
                //判断编号是否一致
                this.Id == userInfoTableMod.Id &&
                //判断姓名是否一致
                this.Name == userInfoTableMod.Name &&
                //判断密码（MD5）是否一致
                this.Password == userInfoTableMod.Password &&
                //判断是否为管理员是否一致
                this.IsAdmin == userInfoTableMod.IsAdmin;
        }
        /// <summary>
        /// 将当前用户表数据模型对象转换成哈希码
        /// </summary>
        /// <returns>哈希值</returns>
        public override int GetHashCode()
        {
            //将用户表数据模型对象的属性进行按位异或运算处理得到哈希码并返回
            return
                //将编号进行按位异或运算处理
                this.Id.GetHashCode() ^
                //将姓名进行按位异或运算处理
                (this.Name == null ? 2147483647 : this.Name.GetHashCode()) ^
                //将密码（MD5）进行按位异或运算处理
                (this.Password == null ? 2147483647 : this.Password.GetHashCode()) ^
                //将是否为管理员进行按位异或运算处理
                this.IsAdmin.GetHashCode();
        }
        /// <summary>
        /// 将当前用户表数据模型对象转换成字符串副本【仅显示在SQL中不能为空的列】
        /// </summary>
        /// <returns>字符串形式副本</returns>
        public override string ToString()
        {
            //将当前用户表数据模型对象转换成字符串副本
            return
                "[" +
                //将编号转换成字符串
                this.Id + "," +
                //将姓名转换成字符串
                this.Name + "," +
                //将密码（MD5）转换成字符串
                this.Password + "," +
                //将是否为管理员转换成字符串
                this.IsAdmin +
                "]";
        }
    }
}
```

## 11.生成的DAL层代码
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125140525845.png#pic_center)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125141857293.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzI1MTU0Nw==,size_16,color_FFFFFF,t_70#pic_center)

```csharp
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using Maticsoft.Model;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 用户表数据访问对象
    /// </summary>
    public partial class UserInfoTableDal
    {
        /// <summary>
        /// 实例化用户表数据访问对象
        /// </summary>
        public UserInfoTableDal()
        {
            
        }
        /// <summary>
        /// 查询得到用户表表中所有信息
        /// </summary>
        /// <returns>查询到的所有用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetAllModel()
        {
            //创建存储查找到的用户表表中信息集合
            List<UserInfoTableMod> list = new List<UserInfoTableMod>();
            //使用查询语句查询出所有信息
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select Id,Name,Password,IsAdmin From UserInfoTable;"))
            {
                //判断是否查询到了数据
                if (sqlReader.HasRows)
                {
                    //循环得到数据
                    while (sqlReader.Read())
                    {
                        //创建一个用户表数据模型对象
                        UserInfoTableMod userInfoTableMod = new UserInfoTableMod();
                        //存储查询到的编号数据
                        userInfoTableMod.Id = sqlReader.GetInt64(0);
                        //存储查询到的姓名数据
                        userInfoTableMod.Name = sqlReader.GetString(1);
                        //存储查询到的密码（MD5）数据
                        userInfoTableMod.Password = sqlReader.GetString(2);
                        //存储查询到的是否为管理员数据
                        userInfoTableMod.IsAdmin = sqlReader.GetBoolean(3);
                        //将用户表数据模型对象存储到集合中
                        list.Add(userInfoTableMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 将传入的用户表数据模型对象数据存入数据库，并将自动编号值存入，传入用户表数据模型对象中
        /// </summary>
        /// <param name="userInfoTableMod">要进行添加到数据库的用户表数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(UserInfoTableMod userInfoTableMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将姓名存入
                new SqlParameter("@name",SqlDbType.NVarChar,128){Value = userInfoTableMod.Name ?? string.Empty},
                //将密码（MD5）存入
                new SqlParameter("@password",SqlDbType.Char,32){Value = userInfoTableMod.Password ?? string.Empty},
                //将是否为管理员存入
                new SqlParameter("@isAdmin",SqlDbType.Bit,1){Value = userInfoTableMod.IsAdmin}
            };
            //进行插入操作并返回自动编号结果
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Insert Into UserInfoTable(Name,Password,IsAdmin) OutPut Inserted.Id Values(@name,@password,@isAdmin);", sqlParameters))
            {
                //判断是否获取到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条记录
                    sqlReader.Read();
                    //将传入参数转换成编号
                    userInfoTableMod.Id = sqlReader.GetInt64(0);
                    //返回添加成功
                    return true;
                }
                else
                {
                    //返回添加失败
                    return false;
                }
            }
        }
        /// <summary>
        /// 根据主键获取一条记录返回一个用户表数据模型对象
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>如果查找到此记录就返回用户表数据模型对象，否则返回null</returns>
        public UserInfoTableMod GetModel(long id)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将编号存入
                new SqlParameter("@id",SqlDbType.BigInt,8){Value = id}
            };
            //执行一条查找SQL命令
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader("Select Top 1 Id,Name,Password,IsAdmin From UserInfoTable Where Id = @id;", sqlParameters))
            {
                //判断是否查找到数据
                if (sqlReader.HasRows)
                {
                    //得到第一条数据
                    sqlReader.Read();
                    //创建一个用户表数据模型对象
                    UserInfoTableMod userInfoTableMod = new UserInfoTableMod();
                    //存储查询到的编号数据
                    userInfoTableMod.Id = sqlReader.GetInt64(0);
                    //存储查询到的姓名数据
                    userInfoTableMod.Name = sqlReader.GetString(1);
                    //存储查询到的密码（MD5）数据
                    userInfoTableMod.Password = sqlReader.GetString(2);
                    //存储查询到的是否为管理员数据
                    userInfoTableMod.IsAdmin = sqlReader.GetBoolean(3);
                    //将用户表数据模型对象返回
                    return userInfoTableMod;
                }
            }
            //返回null
            return null;
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(long id)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将编号存入
                new SqlParameter("@id",SqlDbType.BigInt,8){Value = id}
            };
            //执行一条按照编号删除记录语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery("Delete From UserInfoTable Where Id = @id;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(long id)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将[编号]存入
                new SqlParameter("@id",SqlDbType.BigInt,8){Value = id}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From UserInfoTable Where Id = @id;", sqlParameters) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="userInfoTableMod">用户表</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(UserInfoTableMod userInfoTableMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将编号存入
                new SqlParameter("@id",SqlDbType.BigInt,8){Value = userInfoTableMod.Id},
                //将姓名存入
                new SqlParameter("@name",SqlDbType.NVarChar,128){Value = userInfoTableMod.Name ?? string.Empty},
                //将密码（MD5）存入
                new SqlParameter("@password",SqlDbType.Char,32){Value = userInfoTableMod.Password ?? string.Empty},
                //将是否为管理员存入
                new SqlParameter("@isAdmin",SqlDbType.Bit,1){Value = userInfoTableMod.IsAdmin}
            };
            //执行更新语句，并返回是否更新完成
            return SqlDataBase.ExecuteNonQuery("Update UserInfoTable Set Name = @name,Password = @password,IsAdmin = @isAdmin Where Id = @id;", sqlParameters) > 0;
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="userInfoTableMod">验证的用户表数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(UserInfoTableMod userInfoTableMod)
        {
            //创建存储参数的数组
            SqlParameter[] sqlParameters = new[]
            {
                //将编号存入
                new SqlParameter("@id",SqlDbType.BigInt,8){Value = userInfoTableMod.Id},
                //将姓名存入
                new SqlParameter("@name",SqlDbType.NVarChar,128){Value = userInfoTableMod.Name ?? string.Empty},
                //将密码（MD5）存入
                new SqlParameter("@password",SqlDbType.Char,32){Value = userInfoTableMod.Password ?? string.Empty},
                //将是否为管理员存入
                new SqlParameter("@isAdmin",SqlDbType.Bit,1){Value = userInfoTableMod.IsAdmin}
            };
            //执行查询语句，并返回是否有此记录
            return (int)SqlDataBase.ExecuteScalar("Select Count(*) From UserInfoTable Where Id = @id And Name = @name And Password = @password And IsAdmin = @isAdmin;", sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>
        /// <param name="sqlParameters">SQL参数对象</param>
        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>
        public bool Exists(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Count(*) From UserInfoTable;"
                    : "Select Count(*) From UserInfoTable Where " + where;
            //返回执行完成所得到的数据集合数量并判断是否有超过一条？
            return (int)SqlDataBase.ExecuteScalar(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义删除【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>是否删除成功，为true成功，为false失败</returns>
        public bool Delete(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Delete From UserInfoTable;"
                    : "Delete From UserInfoTable Where " + where;
            //执行删除语句，并返回是否删除成功
            return SqlDataBase.ExecuteNonQuery(sql, sqlParameters) > 0;
        }
        /// <summary>
        /// 自定义查找【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<UserInfoTableMod> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储[会员名称]数据模型对象的集合
            List<UserInfoTableMod> list = new List<UserInfoTableMod>();
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Id,Name,Password,IsAdmin From UserInfoTable;"
                    : "Select Id,Name,Password,IsAdmin From UserInfoTable Where " + where;
            //执行查找语句
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个用户表数据模型对象
                        UserInfoTableMod userInfoTableMod = new UserInfoTableMod();
                        //存储查询到的编号数据
                        userInfoTableMod.Id = sqlReader.GetInt64(0);
                        //存储查询到的姓名数据
                        userInfoTableMod.Name = sqlReader.GetString(1);
                        //存储查询到的密码（MD5）数据
                        userInfoTableMod.Password = sqlReader.GetString(2);
                        //存储查询到的是否为管理员数据
                        userInfoTableMod.IsAdmin = sqlReader.GetBoolean(3);
                        //将用户表数据模型对象存储到集合中
                        list.Add(userInfoTableMod);
                    }
                }
            }
            //返回查找到的用户表对象的集合
            return list;
        }
        /// <summary>
        /// 自定义查询出匹配记录有多少条【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>匹配记录数量</returns>
        public int GetCount(string where, params SqlParameter[] sqlParameters)
        {
            //创建存储执行语句的字符串
            string sql =
                string.IsNullOrWhiteSpace(where)
                    ? "Select Count(*) From UserInfoTable;"
                    : "Select Count(*) From UserInfoTable Where " + where;
            //返回执行完成所得到的数据集合
            return (int)SqlDataBase.ExecuteScalar(sql, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="startIndex">开始索引【从零开始】</param>
        /// <param name="endIndex">结束索引【包括当前索引指向记录】</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //判断传入的条件是否为“;”如果是就移除
            if (!string.IsNullOrEmpty(where) && where[where.Length - 1] == ';')
                //移除最后一个
                where = where.Remove(where.Length - 1);
            //创建存储用户表数据模型对象的集合
            List<UserInfoTableMod> list = new List<UserInfoTableMod>();
            //合成SQL查询语句
            string sql =
                string.IsNullOrWhiteSpace(where)
                ? "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc")
                    + ") From UserInfoTable) As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() +
                    ";"
               : "Select * From (Select * ,Rn=row_number() Over(Order By " +
                    orderby +
                    " " +
                    (isDesc ? "Desc" : "Asc") +
                    ") From UserInfoTable Where " +
                    //将条件存入内查询，而非外查询！！！
                    where +
                    ") As t Where t.Rn-1 Between " +
                    startIndex.ToString() +
                    " And " +
                    endIndex.ToString() + ";";
            //执行查找语句
            using (SqlDataReader sqlReader = SqlDataBase.ExecuteReader(sql, sqlParameters))
            {
                //判断是否查询到数据
                if (sqlReader.HasRows)
                {
                    //循环查询数据
                    while (sqlReader.Read())
                    {
                        //创建一个用户表数据模型对象
                        UserInfoTableMod userInfoTableMod = new UserInfoTableMod();
                        //存储查询到的编号数据
                        userInfoTableMod.Id = sqlReader.GetInt64(0);
                        //存储查询到的姓名数据
                        userInfoTableMod.Name = sqlReader.GetString(1);
                        //存储查询到的密码（MD5）数据
                        userInfoTableMod.Password = sqlReader.GetString(2);
                        //存储查询到的是否为管理员数据
                        userInfoTableMod.IsAdmin = sqlReader.GetBoolean(3);
                        //将用户表数据模型对象存储到集合中
                        list.Add(userInfoTableMod);
                    }
                }
            }
            //返回查询到的信息集合
            return list;
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
        {
            //得到开始索引
            int beginIndex = pageIndex * pageItemCount;
            //得到结束索引
            int endIndex = (beginIndex + pageItemCount) - 1;
            //调用分页获取数据方法并返回结果
            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="allItmeCount">总共有多少条记录</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
        {
            //得到总记录条数
            allItmeCount = this.GetCount(where, SqlDataBase.CopySqlParameters(sqlParameters));
            //得到开始索引
            int beginIndex = pageIndex * pageItemCount;
            //得到结束索引
            int endIndex = (beginIndex + pageItemCount) - 1;
            //调用分页获取数据方法并返回结果
            return this.GetListByPage(where, orderby, isDesc, beginIndex, endIndex, sqlParameters);
        }
    }
}
```

## 12.生成的BLL层代码（生成的代码只是进行了简单的DAL层封装）
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201125140641153.png#pic_center)

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DAL;
using Maticsoft.Model;

namespace Maticsoft.BLL
{
    /// <summary>
    /// 用户表业务逻辑对象
    /// </summary>
    public partial class UserInfoTableBll
    {
        /// <summary>
        /// 用户表数据访问对象
        /// </summary>
        private readonly UserInfoTableDal _userInfoTableDal = new UserInfoTableDal();
        /// <summary>
        /// 实例化用户表业务逻辑对象
        /// </summary>
        public UserInfoTableBll()
        {
            
        }
        /// <summary>
        /// 查询得到用户表表中所有信息
        /// </summary>
        /// <returns>查询到的所有用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetAllModel()
        {
            //调用数据库访问层查询表中所有信息方法并将查询结果返回
            return this._userInfoTableDal.GetAllModel();
        }
        /// <summary>
        /// 将传入的用户表数据模型对象数据存入数据库，并将自动编号值存入，传入用户表数据模型对象中
        /// </summary>
        /// <param name="userInfoTableMod">要进行添加到数据库的用户表数据模型对象</param>
        /// <returns>返回是否添加成功，为true添加成功，为false添加失败</returns>
        public bool Add(UserInfoTableMod userInfoTableMod)
        {
            //调用数据访问层的添加方法并返回是否添加成功
            return this._userInfoTableDal.Add(userInfoTableMod);
        }
        /// <summary>
        /// 根据主键获取一条记录返回一个用户表数据模型对象
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>如果查找到此记录就返回用户表数据模型对象，否则返回null</returns>
        public UserInfoTableMod GetModel(long id)
        {
            //调用数据访问层查询方法并将查询结果返回
            return this._userInfoTableDal.GetModel(id);
        }
        /// <summary>
        /// 根据主键删除一条记录
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回是否删除成功，为true删除成功，为false删除失败</returns>
        public bool Delete(long id)
        {
            //调用数据访问层删除方法删除指定元素并返回是否删除成功
            return this._userInfoTableDal.Delete(id);
        }
        /// <summary>
        /// 判断是否有此主键对应的记录
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>返回是否有此对应的记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(long id)
        {
            //调用数据访问层判断是否有此记录方法并返回结果
            return this._userInfoTableDal.Exists(id);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="userInfoTableMod">用户表</param>
        /// <returns>返回是否更新成功，为true成功为false失败</returns>
        public bool Update(UserInfoTableMod userInfoTableMod)
        {
            //调用数据访问层更新数据方法并将更新结果返回
            return this._userInfoTableDal.Update(userInfoTableMod);
        }
        /// <summary>
        /// 判断是否有此记录
        /// </summary>
        /// <param name="userInfoTableMod">验证的用户表数据模型对象</param>
        /// <returns>返回是否有此记录，为true代表有此记录，为false代表没有此记录</returns>
        public bool Exists(UserInfoTableMod userInfoTableMod)
        {
            //调用数据访问层的判断是否有此记录方法并返回判断结果
            return this._userInfoTableDal.Exists(userInfoTableMod);
        }
        /// <summary>
        /// 自定义查询判断是否有匹配记录【建议只给数据访问层内部使用！要使用请重新封装！】
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，填空为：【判断数据库是否有记录】</param>
        /// <param name="sqlParameters">SQL参数对象</param>
        /// <returns>返回是否1有匹配记录，返回true为有匹配，返回false为没有匹配</returns>
        public bool Exists(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层方法
            return this._userInfoTableDal.Exists(where, sqlParameters);
        }
        /// <summary>
        /// 自定义删除
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>是否删除成功，为true成功，为false失败</returns>
        public bool Delete(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层的自定义删除方法并返回删除结果
            return this._userInfoTableDal.Delete(where, sqlParameters);
        }
        /// <summary>
        /// 自定义查找
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的[会员名称]数据模型对象集合</returns>
        public List<UserInfoTableMod> GetModelList(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层的自定义查找方法并将查找结果返回
            return this._userInfoTableDal.GetModelList(where,sqlParameters);
        }
        /// <summary>
        /// 自定义查询出匹配记录有多少条
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>匹配记录数量</returns>
        public int GetCount(string where, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层自定义查询出匹配记录有多少条方法并将结果返回
            return this._userInfoTableDal.GetCount(where,sqlParameters);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetListByPage(string where, string orderby, bool isDesc, int startIndex, int endIndex, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法并将查询到的数据返回
            return this._userInfoTableDal.GetListByPage(where,orderby,isDesc,startIndex,endIndex,sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法
            return this._userInfoTableDal.GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, sqlParameters);
        }
        /// <summary>
        /// 分页获取数据并返回总记录条数
        /// </summary>
        /// <param name="where">查询条件语句(SQL)，没有填空【获取所有数据】【条件结尾不要加“;”符号！！！否则会出错！】</param>
        /// <param name="orderby">按照什么字段排序</param>
        /// <param name="isDesc">是否是降序排序</param>
        /// <param name="pageIndex">页面索引【从零开始】</param>
        /// <param name="pageItemCount">一页显示多少数据</param>
        /// <param name="allItmeCount">总共有多少条记录</param>
        /// <param name="sqlParameters">所需SQL参数对象数组</param>
        /// <returns>查询到的用户表数据模型对象集合</returns>
        public List<UserInfoTableMod> GetMinutePage(string where, string orderby, bool isDesc, int pageIndex, int pageItemCount, out int allItmeCount, params SqlParameter[] sqlParameters)
        {
            //调用数据访问层分页获取数据方法
            return this._userInfoTableDal.GetMinutePage(where, orderby, isDesc, pageIndex, pageItemCount, out allItmeCount, sqlParameters);
        }
    }
}
```
