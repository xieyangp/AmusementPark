using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Core.Services.Food;

public class FoodDataProvider : IFoodDataProvider
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository _repository;

    public FoodDataProvider(IMapper mapper,IUnitOfWork unitOfWork, IRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task<Foods> CreatedFoodAsync(Foods food, CancellationToken cancellationToken)
    {
        await _repository.InsertAsync(food, cancellationToken).ConfigureAwait(false);

        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        return food;
    }
    
    public async Task UpdatedFoodAsync(UpdateFoodDto food, CancellationToken cancellationToken)
    {
        var old = await _repository.FirstOrDefaultAsync<Foods>(x => x.Id == food.Id,cancellationToken).ConfigureAwait(false);
        
        await _repository.UpdateAsync(_mapper.Map(food,old),cancellationToken).ConfigureAwait(false);
    }

    public async Task<DeleteFoodDto> DeletedFoodAsync(DeleteFoodDto food, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(_mapper.Map<Foods>(food), cancellationToken).ConfigureAwait(false);
        
        return food;
    }

    public async Task<OutFoodDto> GetFoodAsync(GetFoodDto food, CancellationToken cancellationToken)
    {
       var outfood = await _repository.FirstOrDefaultAsync<Foods>(x => x.Id == food.Id).ConfigureAwait(false);

       return _mapper.Map<OutFoodDto>(outfood);
    }
}