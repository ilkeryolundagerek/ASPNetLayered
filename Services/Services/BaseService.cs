using AutoMapper;
using Core.Abstracts;

namespace Services.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
