using System;
using AutoMapper;
using myDojo.Infrastructure;
using MyDojo.Query.ViewModels;
using myDojo.Web.Models;

namespace myDojo.Web.Init
{
    public class AutoMapperConfiguration : IStartupTask 
    {
        public void Execute()
        {
            Mapper.CreateMap<MartialArtistDetails, EditMartialArtistForm>();
        }
    }
}