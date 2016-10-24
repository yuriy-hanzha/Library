using AutoMapper;
using Library.Data.DTOs;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration SetupMappings()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Book, BookModel>();
            });
        }
    }
}
