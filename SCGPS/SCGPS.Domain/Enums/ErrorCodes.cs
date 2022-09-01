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
        #region Service (General): 0100-0199
        [Description("A keresett entitás nem található")]
        ServiceGeneralEntityNotFound = 0100,
        [Description("Az adott entitásnak nincs azonosítója")]
        ServiceGeneralNoId = 0101,
        #endregion

        #region MovieService: 0200-0299

        #endregion

        #region ReviewService: 0300-0399
        ReviewServiceMovieNotFound = 300,
        #endregion

    }
}
