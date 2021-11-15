using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsEventHandlerSample
{
    public class ProcessBusinessLogic2
    {
        public event EventHandler ProcessCompleted;
        public event EventHandler ProcessCompletedNew; 

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            if (ProcessCompleted != null)
                ProcessCompleted?.Invoke(this, e); 
        }
        protected virtual void OnProcessCompletedNew(MyEventArgs e)
        {
            if (ProcessCompletedNew != null)
                ProcessCompletedNew?.Invoke(this, e);
        }


        public void StartProcess()
        {
            //Mach etwas

            OnProcessCompleted(EventArgs.Empty);

            MyEventArgs myEventArgs = new MyEventArgs();
            myEventArgs.Uhrzeit = DateTime.Now;

            OnProcessCompletedNew(myEventArgs);
        }

        
    }


    public class MyEventArgs : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}
