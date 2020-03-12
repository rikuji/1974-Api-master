using System;

namespace BaltaStore.Domain.Commands.OrderCommands.Inputs
{
    public class OrderItemCommand
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
    }
}