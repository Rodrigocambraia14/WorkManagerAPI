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

namespace WM.Application.Queries.WishLists.Get
{
    public class GetWishListQueryHandler : IRequestHandler<GetWishListQuery, IContractResponse>
    {
        private readonly DefaultContext defaultContext;
        private readonly IMapper mapper;

        public GetWishListQueryHandler(DefaultContext defaultContext,
                                       IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(GetWishListQuery query, CancellationToken cancellationToken)
        {
            var wishList = await this.defaultContext.WishLists
                                     .Where(x => x.Id == query.Id)
                                     .ProjectTo<GetWishListQueryResponse>(this.mapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (wishList is null)
                throw new Exception("Lista não encontrada !");

            return ContractResponse.ValidContractResponse(string.Empty, wishList);
        }
    }
}
