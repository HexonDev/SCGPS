using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using SCGPS.Domain.Commands.OmdbSvc;
using SCGPS.Domain.Enums;
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
        private readonly IConfiguration configuration;

        public OmdbService(IExecuter executer, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.executer = executer ?? throw new ArgumentNullException(nameof(executer));
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.configuration = configuration;
        }

        public async Task<SimpleResult<OmdbMovie>> GetOmdbMovieByTitleAsync(GetOmdbMovieCommand command)
        {
            return await executer.ExecuteAsync(command, this.GetType(), async param =>
            {
                var url = QueryHelpers.AddQueryString(configuration["Omdb:ApiUrl"], new Dictionary<string, string?>
                {
                    { "t", param.Title },
                    { "apikey", configuration["Omdb:Key"] }
                });

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                var httpClient = httpClientFactory.CreateClient();
                var repsonseMessage = await httpClient.SendAsync(requestMessage);
                var responseContent = await repsonseMessage.Content.ReadAsStringAsync();

                if (!repsonseMessage.IsSuccessStatusCode)
                {
                    throw new ScGpsException(ErrorCodes.OmdbServiceOmdbFetchFailed);
                }

                var omdbMovie = JsonSerializer.Deserialize<OmdbMovie>(responseContent);

                if(omdbMovie == null)
                {
                    throw new ScGpsException(ErrorCodes.OmdbServiceMovieNotFound);
                }

                return new SimpleResult<OmdbMovie>()
                {
                    Result = omdbMovie
                };
            });
        }
    }
}
