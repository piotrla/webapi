using AutoMapper;

public class CaseProfile : Profile
{
    public CaseProfile()
    {
        CreateMap<Case, CaseDTO>();
        CreateMap<CaseDTO, Case>();
    }
}