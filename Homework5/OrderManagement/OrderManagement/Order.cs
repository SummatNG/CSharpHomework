using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。*/

namespace OrderManagement
{
    class Order
    {
        public string order_name;
        public string order_id;
        public DateTime order_time;
        public double sumPrice
        {
            get
            {
                double sumPrice = 0;
                foreach (OrderItem item in orderItemList)
                {
                    sumPrice += item.item_num * item.item_price;
                }

                return sumPrice;
            }
        }

        public Order(string name, string id)
        {
            this.order_name = name;
            this.order_id = id;
            this.order_time = DateTime.Now;
        }
        public List<OrderItem> orderItemList = new List<OrderItem>();

        public bool AddOrderItem(string name, double price, int num, string id)
        {
            OrderItem orderitem = new OrderItem(name, price, num, id);
            bool isRepeat = false;
            foreach (OrderItem sth in orderItemList)
            {
                if (orderitem.Equals(sth))
                {
                    isRepeat = true;
                }
                else
                {
                    isRepeat = false;
                }
            }
            if (!isRepeat)
            {
                orderItemList.Add(orderitem);
                return true;
            }
            else
            {
                throw new OrderItemRepeatException(name);
            }
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.order_id == order_id;
        }

        public override int GetHashCode()
        {
            return int.Parse(order_id);
        }

        public override string ToString()
        {
            string result = "";
            result += "-----------------------------\n";
            result += "订单号: " + order_id + "\n";
            result += "客户名: " + order_name + "\n";
            result += "-----------------------------\n";
            result += "商品编号    商品名      价格       数量\n";
            foreach (OrderItem orderItem in orderItemList)
            {
                result += orderItem;
            }
            result += "-----------------------------\n";
            result += "总价: " + this.sumPrice + "\n";
            result += "-----------------------------\n";

            return result;
        }

    }
}
