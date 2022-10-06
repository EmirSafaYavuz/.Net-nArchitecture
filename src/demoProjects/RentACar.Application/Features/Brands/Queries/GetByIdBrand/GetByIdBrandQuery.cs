using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Models;
using RentACar.Application.Features.Brands.Queries.GetListBrand;
using RentACar.Application.Features.Brands.Rules;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetByIdBrand;

public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
{
    public int Id { get; set; }
    
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

            await _brandBusinessRules.BrandShouldExistWhenRequested(brand);
            
            BrandGetByIdDto mappedGetByIdBrandModel = _mapper.Map<BrandGetByIdDto>(brand);
            return mappedGetByIdBrandModel;
        }
    }
}