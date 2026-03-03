using AutoMapper;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);//=> profile.CreateMap(typeof(T), GetType());
    }
}