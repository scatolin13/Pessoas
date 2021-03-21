using AutoMapper;
using AutoMapper.Configuration;

namespace Pessoas.Service.CustomAutoMapper
{
    public class CustomMapper<TOne, TTwo>
    {
        readonly MapperConfigurationExpression conf;

        public CustomMapper()
        {
            conf = new MapperConfigurationExpression();
            conf.CreateMap<TOne, TTwo>();
        }

        public TTwo Map<TOne, TTwo>(TOne entity)
        {
            IMapper mapper = new MapperConfiguration(conf).CreateMapper();
            var target = mapper.Map<TOne, TTwo>(entity);

            return target;
        }

        public CustomMapper<TOne, TTwo> Include<TSource, TDestination>()
        {
            conf.CreateMap<TSource, TDestination>();
            return this;
        }
    }
}
