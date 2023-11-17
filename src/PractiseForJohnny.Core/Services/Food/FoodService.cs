using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Events;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Food;

public class FoodService : IFoodService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository _repository;

    public FoodService(IRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<FoodCreatedEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        var food = _mapper.Map<Foods>(command.Food);

        await _repository.InsertAsync(food, cancellationToken).ConfigureAwait(false);

        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        return new FoodCreatedEvent
        {
            Result = _mapper.Map<FoodCreatedDto>(food)
        };
    }

    public async Task<FoodUpdatedEvent> UpdateFoodAsync(UpdateFoodCommand command,CancellationToken cancellationToken)
    {
        var food = _mapper.Map<Foods>(command.Food);

        await _repository.UpdateAsync(food,cancellationToken).ConfigureAwait(false);
        
        return new FoodUpdatedEvent()
        {
            Result = _mapper.Map<FoodUpdatedDto>(food)
        };
    }

    public async Task<FoodDeletedEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken)
    {
        var food = _mapper.Map<Foods>(command.Food);
        
        await _repository.DeleteAsync(food, cancellationToken).ConfigureAwait(false);
        
        return new FoodDeletedEvent()
        {
            Result = _mapper.Map<FoodDeletedDto>(food)
        };
    }

    public async Task<FoodGetedEvent> GetFoodAsync(GetFoodRequest request, CancellationToken cancellationToken)
    {
        var requestFood = request.Food;
       

       

        return new FoodGetedEvent
        {
            Result = new OutFoodDto()
        };
    }
}