using System;
using BikeSharing.Domain.Enums;

namespace BikeSharing.Application.DTOs.Bicycles
{
    public class BicycleReadDTO
    {
        public Guid Id { get; set; }
        public DateTime InServiceDate { get; set; }
        public EnumLocation? Location { get; set; }
    }
}