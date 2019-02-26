﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.AutoMapperConfig.AutoMapper
{
    /// <summary>
    /// AutoMapper初始化类
    /// </summary>
    public class AutoMapperStartupTask
    {
        public void Execute()
        {
            AutoMapperConfiguration.Init();
        }
    }
}
