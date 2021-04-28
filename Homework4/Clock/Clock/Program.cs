using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    class Program
    {

        public delegate void ClockHandler(ClockEventArgs args);

        public class ClockEventArgs
        {
            private DateTime currentTime;
            private DateTime alarmTime;

            public DateTime CurrentTime
            {
                get
                {
                    return currentTime;
                }
                set
                {
                    currentTime = value;
                }
            }
            public DateTime AlarmTime
            {
                get
                {
                    return alarmTime;
                }
                set
                {
                    alarmTime = value;
                }
            }
        }

        public class ClockEvent
        {
            private bool isPause = true;
            public event ClockHandler Tick;
            public event ClockHandler Alarm;

            public void ShowTime(DateTime alarmColck)
            {
                ClockEventArgs args = new ClockEventArgs();
                args.AlarmTime = alarmColck;
                while (true)
                {
                    args.CurrentTime = System.DateTime.Now;
                    if (DateTime.Compare(args.CurrentTime, args.AlarmTime) >= 0 && isPause)
                    {
                        Console.WriteLine();
                        Console.WriteLine("闹钟响了!");
                        Console.WriteLine();
                        Console.WriteLine("输入任意符号关掉闹钟");

                        if (Alarm != null)
                        {
                            Alarm(args);
                        }

                        if (Console.ReadLine() != null)
                        {
                            isPause = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"当前时间为 {DateTime.Now}");
                        if (Tick != null)
                        {
                            Tick(args);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        static void Main(string[] args)
        {
            var clockevent = new ClockEvent();
            DateTime alarmTime = new DateTime();
            int year, month, day, hour, minute, second;
            Console.WriteLine("请设定时间");
            Console.WriteLine("注意:");
            Console.WriteLine("1. 按顺序输入年月日时分秒");
            Console.WriteLine("2. 每输入一项，请按回车键");
            Console.WriteLine("3. 如果不设定秒数，请输入0");
            try
            {
                year = int.Parse(Console.ReadLine());
                month = int.Parse(Console.ReadLine());
                day = int.Parse(Console.ReadLine());
                hour = int.Parse(Console.ReadLine());
                minute = int.Parse(Console.ReadLine());
                second = int.Parse(Console.ReadLine());
                alarmTime = new DateTime(year, month, day, hour, minute, second);
                Console.WriteLine($"你已将闹钟时间设定为 {alarmTime}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("错误:超出范围");
            }
            catch (FormatException)
            {
                Console.WriteLine("错误:格式有误");
            }
            finally
            {
                clockevent.ShowTime(alarmTime);
            }
        }

    }
}
