using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionDemo
{
    /*
    public class Consumer
    {
        MyDependency _dependency = new MyDependency();

        public void ConsumeThings()
        {
            //DoSomething
            _dependency.WriteMessage("Learning In Urdu!");
        }
    }
    */

    public class Consumer
    {
        IMyDependency _dependency;
        public Consumer(IMyDependency dependency)
        {
            _dependency = dependency;
        }

        public void ConsumeThings()
        {
            //DoSomething
            _dependency.WriteMessage("Learning In Urdu!");
        }
    }
    
}
