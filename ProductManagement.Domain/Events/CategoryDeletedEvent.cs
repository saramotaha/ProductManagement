using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Events
{
    public class CategoryDeletedEvent : INotification
    {
        public int Id { get; set; }
    }
}
