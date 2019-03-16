﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Services.UserAppServices.Dto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "请输入用户名")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required(ErrorMessage = "请输入确认密码")]
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }
    }
}
