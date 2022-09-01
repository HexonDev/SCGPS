using SCGPS.Domain.Commands.OmdbSvc;
using SCGPS.Domain.Results;

namespace SCGPS.Logic.Services.OmdbSvc
{
    public interface IOmdbService : IBaseService
    {
        Task<SimpleResult<OmdbMovie>> GetOmdbMovieByTitleAsync(GetOmdbMovieCommand command);
    }
}
