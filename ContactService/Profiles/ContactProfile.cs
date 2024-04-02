using AutoMapper;
using ContactService.Dtos;
using ContactService.Models;

namespace ContactService.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            // Source -> Target
            CreateMap<Contact, ContactDto>();
            CreateMap<CreateContactDto, Contact>();
            CreateMap<Contact, ContactDetailsDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Subcategory.Name));
        }
    }
}