using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;
using WM.Infra.Context.Persistence.Context.Default;

namespace WM.Application.Queries.WishLists.List
{
    public class ListWishListQueryHandler : IRequestHandler<ListWishListQuery, IContractResponse>
    {
        private readonly DefaultContext defaultContext;
        private readonly IMapper mapper;

        public ListWishListQueryHandler(DefaultContext defaultContext, IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(ListWishListQuery query, CancellationToken cancellationToken)
        {
            var wishLists = await this.defaultContext.WishLists
                                      .Where(x => x.WishListUsers.Any(y => y.UserId == query.UserId))
                                      .ProjectTo<ListWishListQueryResponse>(this.mapper.ConfigurationProvider)
                                      .ToListAsync(cancellationToken: cancellationToken);

            return ContractResponse.ValidContractResponse(string.Empty, wishLists);
        }
    }
}
