using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TechCafe.Api.Test
{
    public class BaseTest
    {
        public BaseTest()
        {
            Mapper.Initialize(config => config.AddProfile(new MapperProfile()));
        }
    }
}
