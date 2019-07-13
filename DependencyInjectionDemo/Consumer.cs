using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionDemo
{

    //public class Consumer
    //{
    //    MyDependency _dependency = new MyDependency();

    //    public void ConsumeThings()
    //    {
    //        //DoSomething
    //        _dependency.WriteMessage("Learning In Urdu!");
    //    }
    //}

    #region Change Code to Make it DI 

    public class Consumer
    {
        IMyDependency _dependency;
        IEmailSender _emailSender;
        public Consumer(IMyDependency dependency, IEmailSender emailSender)
        {
            _dependency = dependency;
            _emailSender = emailSender;
        }

        public void ConsumeThings()
        {
            //DoSomething
            _dependency.WriteMessage("Learning In Urdu!");
            _emailSender.SendEmail();
        }
    }

    #endregion
}
