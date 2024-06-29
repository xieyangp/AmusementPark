using Autofac;
using Mediator.Net;
using AmusementPark.Message.Commands;
using AmusementPark.Message.DTO;
using AmusementPark.Message.Requests;

namespace PractiseForJohnny.IntegarationTests.Utills;

public class FoodsUtil : TestUtil
{
    public FoodsUtil(ILifetimeScope scope) : base(scope)
    {
    }

    public async Task<CreateFoodResponse> CreateFoodAsync(CreateFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, CreateFoodResponse>(async mediator =>
        {
            var response = await mediator.SendAsync<CreateFoodCommand, CreateFoodResponse>(
                new CreateFoodCommand { Food = food }); 
            
            return response;
        });
    }

    public async Task<UpdateFoodResponse> UpdateFoodAsync(UpdateFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, UpdateFoodResponse>(async mediator =>
        {
            var response = await mediator.SendAsync<UpdateFoodCommand, UpdateFoodResponse>(
                new UpdateFoodCommand { Food = food }); 
            
            return response;
        });
    }

    public async Task<DeleteFoodResponse> DeleteFoodAsync(DeleteFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, DeleteFoodResponse>(async mediator =>
        {
            var response = await mediator.SendAsync<DeleteFoodCommand, DeleteFoodResponse>(
                new DeleteFoodCommand { Food = food }); 

            return response;
        });
    }

    public async Task<GetFoodResponse> GetFoodAsync(GetFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, GetFoodResponse>(async mediator =>
        {
            var response = await mediator.RequestAsync<GetFoodRequest, GetFoodResponse>(
                new GetFoodRequest { Food = food }); 

            return response;
        });
    }
}