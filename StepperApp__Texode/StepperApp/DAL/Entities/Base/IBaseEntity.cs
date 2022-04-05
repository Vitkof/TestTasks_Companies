using System;

namespace StepperApp.DAL.Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
