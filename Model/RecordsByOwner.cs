namespace DynamicTouch.RecordsByOwner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    public class RecordsByOwner  
    {

        public RecordsByOwner()
        {
            Records = new List<RecordByOwner>();
        }

        public CountStatus Status { get
            {

                CountStatus returnValue = CountStatus.None;

                if (Records.Where(t => t.Status == CountStatus.Error).Count() > 0)
                    returnValue = CountStatus.Error;
                    if (Records.Count == Records.Where(t => t.Status == CountStatus.Ready).Count())
                    returnValue = CountStatus.Ready;
                else if (Records.Where(r => r.Status == CountStatus.Counting).Count() > 0)
                    returnValue = CountStatus.Counting;
                else if (Records.Where(r => r.Status == CountStatus.Queued).Count() > 0)
                    returnValue = CountStatus.Queued;
                else if (Records.Where(r => r.Status == CountStatus.None).Count() > 0)
                    returnValue = CountStatus.None;

                return returnValue;
            }
        }

        public int Count { get { return Records.Sum(s => s.Count);  } }
        public List<RecordByOwner> Records { get; set; }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Records.Where(R=>R.IsSelected).ToList().ForEach(s =>
                {
                    builder.Append($"{s.UserName}: {s.Count}\n");
                }
            );
            return builder.ToString();
        }

    }
}
