using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionDemo
{

    //public class MyDependency
    //{
    //    public MyDependency()
    //    {
    //    }
    //    public void WriteMessage(string message)
    //    {
    //        Console.WriteLine(
    //            $"MyDependency.WriteMessage called. Message: {message}");
    //    }
    //}


    #region Changing Code to Support DI


    //Introduce Dependency Injection using Constructor
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }
    public class MyDependency : IMyDependency
    {
        public MyDependency()
        {
        }
        public void WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency.WriteMessage called. Message: {message}");
        }
    }



    public class MyDependency2 : IMyDependency
    {
        public MyDependency2()
        {
        }
        public void WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency2.WriteMessage called. Message: {message}");
        }
    }



    public interface IEmailSender
    {
        void SendEmail();
    }

    public class MyEmailSender : IEmailSender
    {
        public void SendEmail()
        {
            Console.WriteLine("SendEmail: Send Email is called!");
        }
    }

    #endregion
}
