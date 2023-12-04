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

    public FoodDataProvider(IMapper mapper, IUnitOfWork unitOfWork, IRepository repository)
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
    
    public async Task<Foods> UpdateFoodAsync(UpdateFoodDto food, CancellationToken cancellationToken)
    {
        var outfood = _mapper.Map<Foods>(food);

        await _repository.UpdateAsync(outfood, cancellationToken).ConfigureAwait(false);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return outfood;
    }

    public async Task<Foods> DeletedFoodAsync(DeleteFoodDto food, CancellationToken cancellationToken)
    {
        var del = _mapper.Map<Foods>(food);

        await _repository.DeleteAsync(del, cancellationToken).ConfigureAwait(false);

        return del;
    }

    public async Task<Foods> GetFoodAsync(GetFoodDto food, CancellationToken cancellationToken)
    {
       var outfood = await _repository.FirstOrDefaultAsync<Foods>(x => x.Id == food.Id).ConfigureAwait(false);

       return outfood;
    }
}