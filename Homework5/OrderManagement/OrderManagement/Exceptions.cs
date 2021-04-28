using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{

    class InputErrorException : ApplicationException
    {
        public string Description { get; set; }
        public InputErrorException(string description)
        {
            Description = description;
        }
    }

    class OrderNotExistException : ApplicationException
    {
        public string Description { get; set; }
        public OrderNotExistException(string description)
        {
            Description = description;
        }
    }

    class OrderRepeatException : ApplicationException
    {
        public string Description { get; set; }
        public OrderRepeatException(string description)
        {
            Description = description;
        }
    }

    class OrderItemRepeatException : ApplicationException
    {
        public string Description { get; set; }
        public OrderItemRepeatException(string description)
        {
            Description = description;
        }
    }
}
