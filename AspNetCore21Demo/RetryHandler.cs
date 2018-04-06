using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore21Demo
{
    public class RetryHandler : DelegatingHandler
    {
        public int RetryCount { get; set; } = 5;

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(RetryCount < 1)
            {
                throw new ArgumentOutOfRangeException("RetryCount must be greater than or equal to 1");
            }

            for (var i = 0; i < RetryCount; i++)
            {
                try
                {
                    var response = await base.SendAsync(request, cancellationToken);
                    response.EnsureSuccessStatusCode();
                    return response;
                }
                catch(HttpRequestException) when (i == RetryCount - 1)
                {
                    throw;
                }
                catch (HttpRequestException)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(50));
                }
            }

            throw null;
        }
    }
}
