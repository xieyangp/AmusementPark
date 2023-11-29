using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Core.Extension;
using PractiseForJohnny.Message;
using PractiseForJohnny.Message.Attributes;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.Requests;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Core.Services.SmartFaq;

public class SmartFaqDataProvider : ISmartFaqDataProvider
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public SmartFaqDataProvider(IRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<(int Count, List<UserQuestionDto> UserQuestions)> GetQuestions(GetUserQuestionsRequest command, CancellationToken cancellationToken)
    {
        var query =  _repository.Query<UserQuestion>().Where(i => command.status == i.Status);

        if (command.correct_qid != null)
            query = query.Where(i => i.CorrectQid == command.correct_qid);

        var count = await query.CountAsync(cancellationToken).ConfigureAwait(false);

        query = GenerateUserQuestionsSorting(query, command.sortField, command.sortDirection);

        var userQustions = await query
            .Skip(command.skip)
            .Take(command.take)
            .ProjectTo<UserQuestionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
            
        
        return (count, userQustions);
    }

    public async Task<List<UserQuestion>> GetUserQuestionsAsync(List<int> userQuestionIds, CancellationToken cancellationToken)
    {
        return await _repository.Query<UserQuestion>().Where(i => userQuestionIds.Contains(i.Id)).ToListAsync().ConfigureAwait(false);
    }

    public async Task<List<UserQuestion>> DeleteUerQuestionsAsync(List<int> userQuestionIds, CancellationToken cancellationToken)
    {
        var userQuestions = _repository.Query<UserQuestion>().Where(i => userQuestionIds.Contains(i.Id));

        await _repository.DeleteAllAsync(userQuestions).ConfigureAwait(false);

        return await userQuestions.ToListAsync();
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