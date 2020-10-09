﻿namespace Pezza.Common.Mapping
{
    using System.Collections.Generic;
    using System.Linq;
    using Pezza.Common.DTO;
    using Pezza.Common.Entities;

    public static class OrderMapping
    {
        public static OrderDTO Map(this Order entity) =>
           (entity != null) ? new OrderDTO
           {
               Id = entity.Id,
               Amount = entity.Amount,
               CustomerId = entity.CustomerId,
               DateCreated = entity.DateCreated,
               RestaurantId = entity.RestaurantId,
               OrderItems = entity.OrderItems.Map()
           } : null;

        public static IEnumerable<OrderDTO> Map(this IEnumerable<Order> entity) =>
           entity.Select(x => x.Map());

        public static ICollection<OrderDTO> Map(this ICollection<Order> entity) =>
           entity.Select(x => x.Map()).ToList();

        public static Order Map(this OrderDTO dto) =>
           (dto != null) ? new Order
           {
               Id = dto.Id,
               Amount = dto.Amount,
               CustomerId = dto.CustomerId,
               DateCreated = dto.DateCreated,
               RestaurantId = dto.RestaurantId,
               OrderItems = dto.OrderItems.Map()
           } : null;

        public static IEnumerable<Order> Map(this IEnumerable<OrderDTO> dto) =>
           dto.Select(x => x.Map());

        public static ICollection<Order> Map(this ICollection<OrderDTO> dto) =>
           dto.Select(x => x.Map()).ToList();
    }
}