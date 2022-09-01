using SCGPS.Data.Entities;
using SCGPS.Domain.Commands;
using SCGPS.Domain.Commands.Entity;
using SCGPS.Domain.Results.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.Services.Entity
{
    public interface IEntityService<T> : IBaseService where T : BaseEntity
    {
        Task<EntityResult<T>> AddOrModifyAsync(EntityCommand<T> command);
        Task<EntityResult<T>> DeleteAsync(EntityCommand<T> command);
        Task<EntityResult<T>> GetByIdAsync(IdCommand command);
    }
}
