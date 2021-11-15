using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsEventHandlerSample
{

    public delegate void Percent(int n);
    public delegate void Notify(); //Delegate benötigt Methode

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // von aussen werden wir dem Notify ein Methoden-Zeiger dranhängen
        
        public event Percent CurrentPercentStatus; //von aussen wird diese Property befüllt. 
        
        
        public void StartProcess()
        {
            for (int i = 0; i < 100; i++)
            {

                //REchentinsentive passiert hier 

                //wollen eine Prozentausgabe nach draußen ermöglichen 
                OnCurrentPercentStatus(i);
            }


            //Ich fertig

            if (ProcessCompleted != null) //kann nur verwendet werden, wenn überhaupt von draußen eine Methode drangehöngt wurde
                OnProcessCompleted();
        }

        public virtual void OnProcessCompleted()
        {
            //Von aussen soll ProcessCompleted initialisierten (mit einer EventMethode)
            //Wir callen die Methode, die von aussen drangehängt wird
            ProcessCompleted?.Invoke();
        }


        public virtual void OnCurrentPercentStatus(int percent)
        {
            if (CurrentPercentStatus != null)
                CurrentPercentStatus?.Invoke(percent);
        }

        //public override string ToString()
        //{
        //    return "Ich bin die Process BusinessLogic";
        //}
    }
}
