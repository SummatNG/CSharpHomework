using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

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

    class OrderService
    {
        public List<Order> orderList = new List<Order>();
        int orderAmount = 0;

        //添加订单
        public bool AddOrder(string name, string id)
        {
            Order order = new Order(name, id);
            bool isRepeat = false;
            foreach (Order sth in orderList)
            {
                if (sth.Equals(order))
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
                orderList.Add(order);
                orderAmount++;
                return true;
            }
            else
            {
                throw new OrderRepeatException(id);
            }

        }

        //按照订单号索引
        public int FindIndexById(string id)
        {
            int i = 0;
            foreach (Order sth in orderList)
            {
                if (sth.order_id == id)
                    return i;
                i++;
            }
            throw new OrderNotExistException(id);
        }

        //删除订单
        public bool DeleteOrder(string id)
        {
            int index = FindIndexById(id);
            orderList.RemoveAt(index);
            orderAmount--;
            return true;
        }

        //修改订单
        public void ChangeOrder(string id, string after_name, string after_id)
        {
            int index = FindIndexById(id);
            orderList[index].order_name = after_name;
            orderList[index].order_id = after_id;

        }

        //查询方法
        enum IndexMethod
        {
            IndexByOrderName = 0,
            IndexByOrderId = 1
        }

        //查询订单
        public IEnumerable<Order> FindOrder(string inputString, int flag)
        {
            switch ((IndexMethod)flag)
            {
                case IndexMethod.IndexByOrderName:
                    {
                        var query = from order in orderList
                                    where order.order_name == inputString
                                    orderby order.sumPrice
                                    select order;
                        if (query != null)
                        {
                            return query;
                        }
                        else
                        {
                            throw new OrderNotExistException(inputString);
                        }
                    }
                case IndexMethod.IndexByOrderId:
                    {
                        var query = from order in orderList
                                    where order.order_id == inputString
                                    orderby order.sumPrice
                                    select order;
                        if (query != null)
                        {
                            return query;
                        }
                        else
                        {
                            throw new OrderNotExistException(inputString);
                        }
                    }
                default:
                    return null;
            }
        }

        //排序
        public void SortOrder()
        {
            orderList.Sort((order1, order2) => int.Parse(order1.order_id).CompareTo(int.Parse(order2.order_id)));
        }


        //打印订单
        public void PrintOrders()
        {
            Console.WriteLine("您的订单:");
            for (int i = 0; i < orderAmount; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Order" + (i + 1) + ":");
                Console.Write(orderList[i]);
                Console.WriteLine(" ");
            }
        }



    }
}

