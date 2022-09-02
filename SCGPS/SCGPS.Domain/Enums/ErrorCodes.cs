using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain.Enums
{
    public enum ErrorCodes
    {
        #region General: 0000-0099
        [Description("Unknown error")]
        UncategorizedError = 0000,
        [Description("Validation error")]
        ValidationError = 0001,
        //[Description("")]

        #endregion

        #region Service (General): 0100-0199
        [Description("The requested data couldn't be found")]
        ServiceGeneralEntityNotFound = 0100,
        [Description("The entity has no ID")]
        ServiceGeneralNoId = 0101,
        #endregion

        #region MovieService: 0200-0299

        #endregion

        #region ReviewService: 0300-0399
        [Description("Reviewed movie not found")]
        ReviewServiceMovieNotFound = 300,
        #endregion

        #region OmdbService: 0400-0499
        [Description("Movie not found")]
        OmdbServiceMovieNotFound = 400,
        [Description("Can't fetch the movie's data")]
        OmdbServiceOmdbFetchFailed = 401,
        #endregion
    }
}
