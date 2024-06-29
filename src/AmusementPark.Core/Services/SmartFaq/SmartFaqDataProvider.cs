using AutoMapper;
using System.Reflection;
using AmusementPark.Core.Data;
using AmusementPark.Core.Domain;
using AmusementPark.Message;
using AmusementPark.Message.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AmusementPark.Core.Extension;
using AmusementPark.Message.Requests;
using AmusementPark.Message.Attributes;

namespace AmusementPark.Core.Services.SmartFaq;

public class SmartFaqDataProvider : ISmartFaqDataProvider
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public SmartFaqDataProvider(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<(int Count, List<UserQuestionDto> UserQuestions)> GetUserQuestionsAsync(
        GetUserQuestionsForReviewRequest request, CancellationToken cancellationToken)
    {
        var query =  _repository.Query<UserQuestion>().Where(i => request.status == i.Status);

        if (request.correct_qid != null)
            query = query.Where(i => i.CorrectQid == request.correct_qid);

        var count = await query.CountAsync(cancellationToken).ConfigureAwait(false);

        query = GenerateUserQuestionsSorting(query, request.sortField, request.sortDirection);

        var userQustions = await query
            .Skip(request.skip)
            .Take(request.take)
            .ProjectTo<UserQuestionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
        
        return (count, userQustions);
    }

    public async Task<List<UserQuestion>> GetUserQuestionsByIdsAsync(List<int> userQuestionIds,
        CancellationToken cancellationToken)
    {
        return await _repository.Query<UserQuestion>()
            .Where(i => userQuestionIds.Contains(i.Id))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }
    
    public async Task UpdateUserQuestionsAsync(List<UserQuestion> userQuestions, CancellationToken cancellationToken)
    {
       await _repository.UpdateAllAsync(userQuestions, cancellationToken).ConfigureAwait(false);
    }

    private IQueryable<UserQuestion> GenerateUserQuestionsSorting(IQueryable<UserQuestion> query, string sortField, string sortDirection)
    {
        var sortPropertyName = FindSortPropertyNameBySortField(sortField);

        if (sortPropertyName != null)
        {
            query = sortDirection switch
            {
                JohnnyConstants.SortDirectionAscending => query.OrderBy(sortPropertyName),
                JohnnyConstants.SortDirectionDescending => query.OrderByDescending(sortPropertyName),
                _ => query
            };
        }

        return query;
    }
    
    public string? FindSortPropertyNameBySortField(string sortField)
    {
        return typeof(UserQuestion).GetProperties()
            .Where(property => property.GetCustomAttribute<SortColumnAttribute>()?.SortKey == sortField)
            .Select(property => property)
            .ToList().FirstOrDefault()?.Name;
    }
}