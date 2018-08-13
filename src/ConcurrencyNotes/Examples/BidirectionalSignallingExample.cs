using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConcurrencyNotes.Base;

namespace ConcurrencyNotes.Examples
{
    class BidirectionalSignallingExample : ISingleThreadExample
    {
        readonly AutoResetEvent _ready = new AutoResetEvent(false);
        readonly AutoResetEvent _go = new AutoResetEvent(false);
        readonly object _locker = new object();
        string _message;

        public void Execute()
        {
            new Thread(Work).Start();

            _ready.WaitOne(); // ожидаем готовность рабочего потока

            lock (_locker)
            {
                _message = "ooo";
            }
            _go.Set(); // сообщаем рабочему потоку о сообщении
            _ready.WaitOne(); // ожидаем уведомления от рабочека потока о готовности
            lock (_locker)
            {
                _message = "ahhh";
            }
            _go.Set(); // сообщаем рабочему потоку о сообщении
            _ready.WaitOne(); // ожидаем уведомления от рабочека потока о готовности
            lock (_locker)
            {
                _message = null;
            }
            _go.Set(); // сообщаем рабочему потоку о сообщении
        }

        private void Work()
        {
            while (true)
            {
                _ready.Set(); // уведомляем о готовности
                _go.WaitOne(); // ожидаем поступления сигнала

                lock (_locker)
                {
                    if (_message == null)
                    {
                        return; // завершение
                    }
                    Console.WriteLine(_message);
                }
            }
        }
    }
}
