using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PersonManagement.Queries.GetAllPersonDetails
{
    public class Query : QueryBase<IList<Dto>>
    {
    }
}
