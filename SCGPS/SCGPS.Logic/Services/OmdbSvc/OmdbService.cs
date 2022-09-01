using Microsoft.AspNetCore.WebUtilities;
using SCGPS.Domain.Commands.OmdbSvc;
using SCGPS.Domain.Exceptions;
using SCGPS.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.OmdbSvc
{
    public class OmdbService : IOmdbService
    {
        private readonly IExecuter executer;
        private readonly IHttpClientFactory httpClientFactory;

        public OmdbService(IExecuter executer, IHttpClientFactory httpClientFactory)
        {
            this.executer = executer ?? throw new ArgumentNullException(nameof(executer));
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<SimpleResult<OmdbMovie>> GetOmdbMovieByTitleAsync(GetOmdbMovieCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                var url = QueryHelpers.AddQueryString("http://www.omdbapi.com", new Dictionary<string, string?>
                {
                    { "t", param.Title },
                    { "apikey", "80e8671d" }
                });

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                var httpClient = httpClientFactory.CreateClient();
                var repsonseMessage = await httpClient.SendAsync(requestMessage);
                var responseContent = await repsonseMessage.Content.ReadAsStringAsync();

                var omdbMovie = JsonSerializer.Deserialize<OmdbMovie>(responseContent);

                if(omdbMovie == null)
                {
                    throw new ScGpsException(Domain.Enums.ErrorCodes.ServiceGeneralEntityNotFound);
                }

                return new SimpleResult<OmdbMovie>()
                {
                    Result = omdbMovie
                };
            });
        }
    }
}
