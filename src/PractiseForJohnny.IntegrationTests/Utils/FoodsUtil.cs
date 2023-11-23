using Autofac;
using Mediator.Net;
using Microsoft.VisualBasic;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.IntegarationTests.Utills;

public class FoodsUtil : TestUtil
{
    public FoodsUtil(ILifetimeScope scope) : base(scope)
    {
    }

    public async Task<CreateFoodResponse> CreateFood(CreateFoodDto food)
    {
       return await RunWithUnitOfWork<IMediator, CreateFoodResponse>(async mediator =>
        {
            var response = await mediator
                .SendAsync<CreateFoodCommand, CreateFoodResponse>(
                    new CreateFoodCommand
                        {Food = food});
            return response;
        });
    }

    public async Task<UpdateFoodResponse> UpdateFood(UpdateFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, UpdateFoodResponse>(async mediator =>
        {
            var response = await mediator
                .SendAsync<UpdateFoodCommand, UpdateFoodResponse>(
                    new UpdateFoodCommand
                        { Food = food });
            return response;
        });
    }

    public async Task<DeleteFoodResponse> DeleteFood(DeleteFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, DeleteFoodResponse>(async mediator =>
        {
            var response = await mediator
                .SendAsync<DeleteFoodCommand, DeleteFoodResponse>
                (
                    new DeleteFoodCommand
                {
                    Food = food
                });
            
            return response;
        });
    }

    public async Task<GetFoodResponse> GetFood(GetFoodDto food)
    {
        return await RunWithUnitOfWork<IMediator, GetFoodResponse>(async mediator =>
        {
            var response = await mediator
                .RequestAsync<GetFoodRequest, GetFoodResponse>
                (
                    new GetFoodRequest
                    {
                        Food = food
                    });

            return response;
        });
    }
}