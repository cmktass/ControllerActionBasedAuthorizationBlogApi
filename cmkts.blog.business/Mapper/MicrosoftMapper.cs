using AutoMapper;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using cmkts.blog.viewmodel.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.business.Mapper
{
    public class MicrosoftMapper:Profile
    {
        public MicrosoftMapper()
        {
            CreateMap<User, UserVM>();
            CreateMap<UserVM, User>();
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
            CreateMap<Post, PostVM>();
            CreateMap<PostVM, Post>();
        }
    }
}
