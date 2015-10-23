using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.ProductMaps;

namespace Infrastructure.Persistance.RouteProductMap
{
    public class RouteProductMap
    {
        [Key]
        public Guid Id { get; set; }
        public ICollection<RouteProductMapProduct> Products { get; set; }
        public RouteProductMapType RouteProductMapType { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Route.Route Route { get; set; }
    }
}
