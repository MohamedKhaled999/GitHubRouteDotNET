using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared;

namespace Services.MappingProfiles
{
    internal class PictureUrlResolver : IValueResolver<Product, ProductResultDTO, string>
    {
        private readonly IConfiguration configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Product source, ProductResultDTO destination, string destMember, ResolutionContext context)
        {
            return $"{configuration["BaseUrl"]}{source.PictureUrl}";   
        }

    }
}