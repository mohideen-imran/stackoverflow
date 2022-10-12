using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverFlowException
{
    class Program
    {
        List<SampleObject> sampleObjectList = new List<SampleObject>();
        static void Main(string[] args)
        {
            Program pg = new Program();

            for (int i=0; i<1000; i++)
            {
               var sampleObject = new SampleObject();
                pg.sampleObjectList.Add(
                         new SampleObject() { IsAccepted = true, Sequence = i}                         
                    );
            }

            pg.handler(800, false);

            Console.WriteLine("Hello World!");
        }

        public void handler(int sequence, bool isAccepted)
        {
            var _isAccepted = isAccepted;
            var _sequence = sequence;

            Func<SampleObject, bool> filter = (x => isAccepted ? x.Sequence < sequence : x.Sequence > sequence);

            foreach(var sampleObject in sampleObjectList.Where(filter))
            {
                sampleObject.IsAccepted = isAccepted;
            }
        }
    }

    public class SampleObject
    {
        public SampleObject()
        {
            _isAccepted = this.IsAccepted;
            Sequence = _sequence;
        }

        private readonly bool _isAccepted;
        private readonly int _sequence;

        public int Sequence { get; set; }
        public bool IsAccepted
        {
            get { return _isAccepted; }
            set
            {
                if(value)
                {
                    Program pg = new Program();
                    pg.handler(Sequence, value);
                }
            }
        }
    }
}
