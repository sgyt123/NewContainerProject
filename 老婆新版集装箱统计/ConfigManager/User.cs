using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigManager
{
    public class User
    {

        public static User CurrUser = new User();
        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginUser { get; set; }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Power { get; set; }
    }
}
