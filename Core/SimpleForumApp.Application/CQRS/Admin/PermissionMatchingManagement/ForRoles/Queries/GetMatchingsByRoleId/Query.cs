﻿using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Queries.GetMatchingsByRoleId
{
    public class Query : QueryBase<IList<Response>>
    {
        public long RoleId { get; set; }
    }
}
