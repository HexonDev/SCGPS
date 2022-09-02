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
        [Description("Ismeretlen hiba")]
        UncategorizedError = 0000,
        [Description("Validációs hiba")]
        ValidationError = 0001,
        //[Description("")]

        #endregion

        #region Service (General): 0100-0199
        [Description("A keresett adat nem található")]
        ServiceGeneralEntityNotFound = 0100,
        [Description("Az adott entitásnak nincs azonosítója")]
        ServiceGeneralNoId = 0101,
        #endregion

        #region MovieService: 0200-0299

        #endregion

        #region ReviewService: 0300-0399
        [Description("Az értékelt film nem található")]
        ReviewServiceMovieNotFound = 300,
        #endregion

        #region OmdbService: 0400-0499
        [Description("A keresett film nem található")]
        OmdbServiceMovieNotFound = 400,
        [Description("Nem sikerült lekérni a film adatait")]
        OmdbServiceOmdbFetchFailed = 401,
        #endregion
    }
}
