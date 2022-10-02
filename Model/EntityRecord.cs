namespace DynamicTouch.RecordsByOwner
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;



    public class EntityRecord : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;

        public EntityRecord()
        {
            OwnerRecords = new RecordsByOwner();
            Requests = new Queue<OrganizationRequest>();
            CountStatus = CountStatus.None;
        }
        public CountStatus CountStatus { get { return OwnerRecords.Status; } set { ; } }
        public Guid? MetadataId { get; set; }
        public bool CountRecords { get; set; }
        public string LogicalName { get; set; }
        public string Displayname { get; set; }
        public string Status
        {
            get
            {
                string returnValue = "";
                switch (CountStatus)
                {
                    case CountStatus.None:
                        returnValue = "";
                        break;
                    case CountStatus.Queued:
                        returnValue = "Queued";
                        break;
                    case CountStatus.Ready:
                        returnValue = "Ready";
                        break;
                    case CountStatus.Counting:
                        returnValue = "Counting";
                        break;
                    case CountStatus.Error:
                        returnValue = "Error";
                        break;
                }
                return returnValue;

            }
            set {; }
        }
        public int RecordCount { get { return OwnerRecords.Count; } }
        public bool Visible { get;  set; }
        public RecordsByOwner OwnerRecords { get; set; }
        private void UpdatePropertyChanged(string name)
        {
            try
            {
                if (PropertyChanged != null)
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            catch (Exception)
            { }
        }
        private Queue<OrganizationRequest> Requests { get; set; }
        public void AddOwner(RecordByOwner recordByOwner, bool selected, bool bulk)
        {
            RecordByOwner item = OwnerRecords.Records.Where(o => o.UserId == recordByOwner.UserId).FirstOrDefault();
            if (item == null)
            {
                OwnerRecords.Records.Add(recordByOwner);
            }
            else
                item.IsSelected = selected;
            if (bulk)
                return;
            UpdatePropertyChanged("OwnerRecords");
        }
        public void ProcessResponses(List<RetrieveMultipleResponse> responses)
        {
            int prevCount = RecordCount;
            string prevOwner = OwnerRecords.ToString();
            CountStatus prevStatus = CountStatus;

            var respo = responses.Where(r => r.EntityCollection.EntityName == LogicalName).ToList();
            OwnerRecords.Records.Where(r => r.IsSelected   ).ToList().ForEach(f =>
                {
                    f.ProcessResonse(respo);
                }
            );
            if (prevCount != RecordCount)            
                UpdatePropertyChanged("RecordCount");
            if (prevOwner != OwnerRecords.ToString())
                UpdatePropertyChanged("OwnerRecords");
            if (prevStatus != CountStatus)
                UpdatePropertyChanged("Status");
        }
        public void QueueQueries(bool bulk)
        {
            var currentStatus = CountStatus;

            OwnerRecords.Records.Where(o => o.MoreRecords == true  ).ToList().ForEach(f =>
                {
                    f.QueueQuery(LogicalName, Requests);                  
                }
            );
            if( CountStatus != currentStatus && !bulk)
                UpdatePropertyChanged("Status");
        }

        public void SetError(Guid userId)
        {
            var currentStatus = CountStatus;
            OwnerRecords.Records.Where(o => o.UserId == userId).ToList().ForEach(r =>
                {
                    r.Status = CountStatus.Error;
                }
            );
            if (CountStatus != currentStatus)
                UpdatePropertyChanged("Status");
        }

        public List<OrganizationRequest> GetRequests()
        {
            var currentStatus = CountStatus;

            List<OrganizationRequest> returnValue = new List<OrganizationRequest>();
            while (Requests.Count > 0 && Requests.Count < 100)
            {
                returnValue.Add(Requests.Dequeue());
            }

            if (CountStatus != currentStatus)
                UpdatePropertyChanged("Status");
            return returnValue;
        }

        internal void SetCounting(QueryExpression query)
        {
            var userId = (Guid)query.Criteria.Conditions.FirstOrDefault().Values.First() ;
            OwnerRecords.Records.Where(r => r.UserId == userId).FirstOrDefault().Status = CountStatus.Counting;
        }
    }
}