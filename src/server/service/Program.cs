using System;
using System.ServiceProcess;

namespace uBizSoft.FileCopy.Server
{
    internal static class Program
    {
#if TRACE
        static void Main(string[] args)
        {
            Worker _work = new Worker();
            Host _host = new Host();

            _host.Start();
            _work.Start();

            Console.WriteLine("hit any key to exit.....");
            Console.ReadLine();

            _work.Stop();
            _host.Stop();
        }
#else
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var ServicesToRun = new ServiceBase[] { new fCopyService() };
            ServiceBase.Run(ServicesToRun);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var _ex = (Exception)e.ExceptionObject;
                var _interface = new uBizSoft.FileCopy.Interface.FileCopy();
                _interface.WriteLog(_ex.Message);
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
#endif
    }
}
