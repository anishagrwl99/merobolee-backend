using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Infrastructure
{
    public class UriService: IUriService
    {
        public string baseUri;
        public UriService(string baseUri)
        {
            this.baseUri = baseUri;
        }
        public Uri GetUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(baseUri);
            if (pagination == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(baseUri, name: "pageNo", value: pagination.pageNo.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, name: "size", value: pagination.size.ToString());

            return new Uri(modifiedUri);
        }
    }
}
