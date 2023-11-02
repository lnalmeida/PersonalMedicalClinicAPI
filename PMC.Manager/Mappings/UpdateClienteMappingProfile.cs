using AutoMapper;
using PMC.Core.Domain;
using PMC.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Manager.Mappings
{
    public class UpdateClienteMappingProfile: Profile
    {
        public UpdateClienteMappingProfile() 
        {
            CreateMap<UpdateClienteModelView, Cliente>()
                .ForMember(d => d.LastUpdatedAt, options => options.MapFrom(s => DateTime.Now))
                .ForMember(d => d.BirthDate, options => options.MapFrom(s => s.BirthDate.Date));
        }
    }
}
