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

/*1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；添加一个Import方法可以从XML文件中载入订单。
2、对订单程序中OrderService的各个Public方法添加测试用例。*/

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("My Store:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(" 商品名           商品编号          价格");
            Console.WriteLine(" APPLE            1001          7.2 ");
            Console.WriteLine(" BANANA           1002          10 ");
            Console.WriteLine(" GRAPE            1003          8.7 ");
            Console.WriteLine(" CHIP             1004          6.3");
            Console.WriteLine(" TEA              2001          3.5");
            Console.WriteLine(" COFFEE           2002          26");
            Console.WriteLine(" IPHONE           3001          12699 ");
            Console.WriteLine(" IPAD             3002          10299");
            Console.WriteLine(" PERFUME          4001          1099");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("请输入想要生成的订单数：");
            int orderNum = int.Parse(Console.ReadLine());

            OrderService OrderService = new OrderService();

            try
            {
                //打印订单
                for (int i = 0; i < orderNum; i++)
                {
                    Console.WriteLine("请输入第 " + (i + 1) + " 位顾客的姓名");
                    string name = Console.ReadLine();
                    Order Order = new Order(name, "000" + (i + 1).ToString());
                    OrderService.AddOrder(name, "000" + (i + 1).ToString());


                    Console.WriteLine("你好!" + Order.order_name + "!");
                    Console.WriteLine("您想购买几种商品?");
                    int kindNum = int.Parse(Console.ReadLine());
                    for (int j = 0; j < kindNum; j++)
                    {
                        Console.WriteLine("请输入第 " + (j + 1) + " 种商品的名称:");
                        string itemName = Console.ReadLine();
                        Console.WriteLine("请输入第 " + (j + 1) + " 种商品的数量:");
                        int itemAmount = int.Parse(Console.ReadLine());
                        switch (itemName)
                        {
                            case "APPLE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 7.2, itemAmount, "1001");
                                }
                                break;
                            case "BANANA":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 10, itemAmount, "1002");
                                }
                                break;
                            case "GRAPE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 8.7, itemAmount, "1003");
                                }
                                break;
                            case "CHIP":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 6.3, itemAmount, "1004");
                                }
                                break;
                            case "TEA":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 3.5, itemAmount, "2001");
                                }
                                break;
                            case "COFFEE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 26, itemAmount, "2002");
                                }
                                break;
                            case "IPHONE":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 12699, itemAmount, "3001");
                                }
                                break;
                            case "IPAD":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 10299, itemAmount, "3002");
                                }
                                break;
                            case "PERFUME":
                                {
                                    OrderService.orderList[i].AddOrderItem(itemName, 1099, itemAmount, "4001");
                                }
                                break;
                            default:
                                {
                                    Console.WriteLine("我们不提供此类商品!");
                                    return;
                                }

                        }

                    }
                }
                Console.WriteLine("----------------------------------------");
                OrderService.PrintOrders();

                //索引查询
                Console.WriteLine("请输入对应数字,选择查询订单的方法");
                Console.WriteLine("输入 '0': 按照客户名查询");
                Console.WriteLine("输入 '1': 按照订单号查询");
                int indexMethod = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入查询关键字(相应的客户名/订单号)");
                string keyword = Console.ReadLine();
                var queryResults = OrderService.FindOrder(keyword, indexMethod);

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("以下是查询结果:");
                foreach (var queryResult in queryResults)
                {
                    Console.WriteLine(queryResult);
                }

                Console.WriteLine("----------------------------------------");
                Console.WriteLine();

                //排序
                Console.WriteLine("如果您需要根据订单号对订单进行排序，请输入'1':");
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("以下是排序后的订单:");
                    OrderService.SortOrder();
                    OrderService.PrintOrders();
                }


                //删除订单
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("您可以通过输入订单号来删除相应订单");
                Console.WriteLine("请输入订单号:");
                string IdForDelete = Console.ReadLine();
                OrderService.DeleteOrder(IdForDelete);
                OrderService.PrintOrders();

                //编辑订单
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("您可以通过输入订单号来修改相应订单信息");
                Console.WriteLine("请输入订单号:");
                string IdForAlter = Console.ReadLine();
                Console.WriteLine("请输入您想更改的客户名:");
                string Alter_name = Console.ReadLine();
                Console.WriteLine("请输入您想更改的订单号:");
                string Alter_Id = Console.ReadLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("以下是修改后的订单:");
                OrderService.ChangeOrder(IdForAlter, Alter_name, Alter_Id);
                OrderService.PrintOrders();

            }
            catch (FormatException)
            {
                Console.WriteLine("输入错误");
            }
            catch (InputErrorException e)
            {
                Console.WriteLine(e.Description + "的数量应当是正数");
            }
            catch (OrderItemRepeatException e)
            {
                Console.WriteLine(e.Description + "已经在您的订单中了");
            }
            catch (OrderRepeatException e)
            {
                Console.WriteLine("订单号为" + e.Description + "的订单已经存在");
            }
            catch (OrderNotExistException e)
            {
                Console.WriteLine("找不到" + e.Description);
            }

        }
    }
}
