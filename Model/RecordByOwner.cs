namespace DynamicTouch.RecordsByOwner
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum CountStatus { None = 0, Queued = 1,  Counting = 2, Ready = 3 , Error=4 };

    public class RecordByOwner
    {

        public static int MAX_RECORDCOUNT = 5000;


        public RecordByOwner()      
        {
            MoreRecords = true;
            Status = CountStatus.None;
            PageNumber = 1;
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid? EntityId { get; set; }
        public int Count { get; set; }
        public bool IsSelected { get; set; }
        public string Cookie { get; set; }
        public int PageNumber { get; set; }
        public bool MoreRecords { get; set; }

        public CountStatus Status { get; set; }

        public PagingInfo GetPagingInformation()
        {
            return new PagingInfo()
                {
                    PageNumber = PageNumber,
                    PagingCookie = Cookie,
                    ReturnTotalRecordCount = true,
                    Count = MAX_RECORDCOUNT
                };
        }

        internal CountStatus ProcessResonse(List<RetrieveMultipleResponse> responses)
        {
            var x = responses.Where(re => re.EntityCollection.Entities.FirstOrDefault()?.GetAttributeValue<EntityReference>("ownerid")?.Id == UserId).FirstOrDefault();
            if (x == null)
            {
                MoreRecords = false;
                Status = CountStatus.Ready;
                return CountStatus.Ready;
            }
            MoreRecords = x.EntityCollection.MoreRecords;
            Cookie = x.EntityCollection.PagingCookie;
            PageNumber++;
            Count += x.EntityCollection.Entities.Count;
            if (MoreRecords)
                Status = CountStatus.Counting;
            else
                Status = CountStatus.Ready;
            return Status;
        }


        internal void QueueQuery(string logicalName, Queue<OrganizationRequest> requests)
        {
            if ( IsSelected && MoreRecords && Status != CountStatus.Error)
            {
                if (Status == CountStatus.None)
                    Status = CountStatus.Queued;
                else
                    Status = CountStatus.Counting;
                QueryExpression q = new QueryExpression(logicalName);
                q.ColumnSet.AddColumn("ownerid");
                q.Criteria.AddCondition("ownerid", ConditionOperator.Equal, UserId);
                q.PageInfo = GetPagingInformation();                
                RetrieveMultipleRequest request = new RetrieveMultipleRequest()
                {
                    Query = q
                };
                requests.Enqueue(request);
            }
        }
    }
}
