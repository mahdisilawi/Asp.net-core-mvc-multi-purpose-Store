using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Common.Dto;

namespace Hyper_Store.Application.Services.Common.Queries.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IApplicationDbContext _db;
        public GetSliderService(IApplicationDbContext db)
        {
            _db = db;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _db.Sliders
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new SliderDto
                {
                    Link = p.Link,
                    Src = p.Src
                }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
}
