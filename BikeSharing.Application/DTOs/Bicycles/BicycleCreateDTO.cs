using System;
using BikeSharing.Domain.Enums;

namespace BikeSharing.Application.DTOs.Bicycles
{
    public class BicycleCreateDTO
    {
        public DateTime InServiceDate { get; set; }
        public EnumLocation? Location { get; set; }
    }
}