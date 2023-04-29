﻿using AutoMapper;

namespace ControleLancamento.Api.Application.Configuration.Mapper
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig()
        {
        }

        public static MapperConfiguration RegisterMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMap());
            });
        }
    }
}