using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Events
{
    public class ProductCreatedEvent :INotification
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
    }
}
