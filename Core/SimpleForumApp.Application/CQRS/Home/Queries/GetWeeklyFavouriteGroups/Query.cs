﻿using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetWeeklyFavouriteGroups
{
    public class Query : QueryBase<IList<Response>>
    {
    }
}
