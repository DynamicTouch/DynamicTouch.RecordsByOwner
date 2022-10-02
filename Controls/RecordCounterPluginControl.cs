using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace DynamicTouch.RecordsByOwner
{


    public partial class RecordCounterPluginControl : PluginControlBase
    {
        private Settings mySettings;
        private List<User> Users;
        private List<Solution> Solutions;
        private List<SolutionComponent> SolutionComponents;
        private List<EntityMetadata> Entities;

        public RecordCounterPluginControl()
        {
            InitializeComponent();

            Entities = new List<EntityMetadata>();
            EntityItems = new BindingList<EntityRecord>();
            SolutionComponents = new List<SolutionComponent>();

            selectUsersAndSolutions1.checkedListBoxSolutions.ItemCheck += CheckedListBoxSolutions_ItemCheck;
            selectUsersAndSolutions1.checkedListBoxUsers.ItemCheck += CheckedListBoxUsers_ItemCheck;
            entityRecordBindingSource.DataSource = EntityItems;
            dataGridView1.DoubleBuffered(true);
        }
        private void CheckedListBoxUsers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Users[e.Index].IsSelected = (e.NewValue != CheckState.Unchecked);
            UpdateOwnerRecords(e.Index);
        }
        private void UpdateOwnerRecords(int index)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Processing",
                Work = (worker, args) =>
                {
                    User u = selectUsersAndSolutions1.checkedListBoxUsers.Items[index] as User;

                    EntityItems.ToList().ForEach(en =>
                    {
                        en.AddOwner(
                                new RecordByOwner
                                {
                                    Count = 0,
                                    EntityId = en.MetadataId,
                                    UserId = u.Id,
                                    UserName = u.Name,
                                    IsSelected = u.IsSelected,
                                    Status = CountStatus.None
                                },
                                u.IsSelected,
                                 true
                            );
                    }
                    );
                    args.Result = "Ready";
                },
                PostWorkCallBack = (args) =>
                {
                    UpdateEntityGridView();
                }
            }
            );
        }
        private void CheckedListBoxSolutions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Solutions[e.Index].IsSelected = (e.NewValue != CheckState.Unchecked);
            UpdateEntityGridView();
        }
        private void UpdateEntityGridView()
        {
            var x = (from e in EntityItems
                     join sc in SolutionComponents on e.MetadataId equals sc.EntityId
                     join s in Solutions on sc.SolutionId equals s.Id
                     where s.IsSelected == true
                     select e).ToList();

            x.ForEach(e =>
            {
                e.Visible = true;
            }
            );
            EntityItems.Except(x).ToList().ForEach(y =>
                {
                    y.Visible = false;
                }
            );

            BindingList<EntityRecord> filtered = new BindingList<EntityRecord>(EntityItems.Where(obj => obj.Visible).ToList());
            dataGridView1.DataSource = filtered;
            dataGridView1.Refresh();
        }
        private void GetData()
        {
            GetUsers();
            GetSolutions();
            GetSolutionsComponents();
            GetEntities();
        }
        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
        private void GetSolutions()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting solutions",
                Work = (worker, args) =>
                {
                    QueryExpression q = new QueryExpression("solution")
                    {
                        ColumnSet = new ColumnSet("friendlyname"),
                        NoLock = true,

                    };
                    q.AddOrder("friendlyname", OrderType.Ascending);

                    args.Result = Service.RetrieveMultiple(q);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {

                        Solutions = result.Entities.Select(s =>
                            new Solution()
                            {
                                Id = s.Id,
                                Name = s.GetAttributeValue<string>("friendlyname")
                            }
                        ).ToList();

                    }
                    selectUsersAndSolutions1.checkedListBoxSolutions.DataSource = Solutions;
                    selectUsersAndSolutions1.checkedListBoxSolutions.DisplayMember = "Name";
                    selectUsersAndSolutions1.checkedListBoxSolutions.Refresh();
                }
            });
        }
        private void GetUsers()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting users",
                Work = (worker, args) =>
                    {
                        QueryExpression q = new QueryExpression("systemuser")
                        {
                            ColumnSet  =new ColumnSet("fullname"),
                            NoLock = true,
                           
                        };
                        q.AddOrder("fullname", OrderType.Ascending);

                        args.Result = Service.RetrieveMultiple(q);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {

                        Users = result.Entities.Select(s =>                            
                            new User()
                            {
                                Id = s.Id,
                                Name = s.GetAttributeValue<string>("fullname")
                            }                            
                        ).ToList();

                    }

                    selectUsersAndSolutions1.checkedListBoxUsers.DataSource = Users;
                    selectUsersAndSolutions1.checkedListBoxUsers.DisplayMember = "Name";
                    selectUsersAndSolutions1.checkedListBoxUsers.Refresh();
                }
            });
        }
        private void GetEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting entities",
                Work = (worker, args) =>
                {
                    RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
                    RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
                    metaDataRequest.EntityFilters = EntityFilters.Entity;
                    args.Result = (RetrieveAllEntitiesResponse)Service.Execute(metaDataRequest);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as RetrieveAllEntitiesResponse;
                    if (result != null)
                    {
                        
                        Entities = result.EntityMetadata.ToList();
                        EntityItems.Clear();
                        Entities.Where(e => e.OwnershipType == OwnershipTypes.UserOwned).Select(e =>
                                             new EntityRecord()
                                             {
                                                 CountRecords = true,
                                                 Displayname = e?.DisplayName?.UserLocalizedLabel?.Label,
                                                 LogicalName = e?.LogicalName,
                                                 MetadataId = e.MetadataId,
                                                 Status = "",
                                                 Visible = false
                                             }
                                       ).ToList()
                                       .ForEach(e =>
                                       {
                                           if(e.LogicalName != "interactionforemail")
                                            EntityItems.Add(e);
                                       });
                        UpdateEntityGridView();
                    }
                }
            });
        }
        private void GetSolutionsComponents()
        {
            //SolutionComponents?.Clear();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting solutionscomponents",
                Work = (worker, args) =>
                {
                    QueryExpression q = new QueryExpression("solutioncomponent")
                    {
                        ColumnSet = new ColumnSet("objectid", "solutionid"),
                        NoLock = true,
                        Distinct = true

                    };
                    q.Criteria.AddCondition("componenttype", ConditionOperator.Equal, 1);
                    args.Result = Service.RetrieveMultiple(q);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {

                        SolutionComponents = result.Entities.Select(s =>
                            new SolutionComponent()
                            {
                                EntityId = s.GetAttributeValue<Guid>("objectid"),
                                SolutionId = s.GetAttributeValue<EntityReference>("solutionid").Id,
                            }
                         ).ToList();
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
            GetData();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            QueueRecords();
        }

        
        private void QueueRecords()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Queuing records",
                Work = (worker, args) =>
                {
                    var items = EntityItems.Where(en =>
                                            en.CountRecords == true
                                            && en.CountStatus != CountStatus.Ready
                                            && en.CountStatus != CountStatus.Error
                                            && en.Visible == true).ToList();
                    if (items.Count == 0)
                        return;

                    items.ForEach(en =>
                    {
                        en.QueueQueries(true);
                    }
                    );
                    
                    
                    ExecuteMultipleRequest req = new ExecuteMultipleRequest()
                    {
                        Settings = new ExecuteMultipleSettings()
                        {
                            ContinueOnError = true,
                            ReturnResponses = true
                        },
                        Requests = new OrganizationRequestCollection()
                    };
                    EntityItems.Where(en =>
                        en.CountRecords == true &&
                        en.CountStatus != CountStatus.Ready &&
                        en.CountStatus != CountStatus.Error
                        ).ToList().ForEach(en =>
                        {
                            req.Requests.AddRange(en.GetRequests());
                        }
                    );
                    args.Result = req;
                },
                PostWorkCallBack = (args) =>
                {
                    UpdateEntityGridView();


                    var result = args.Result as ExecuteMultipleRequest;

                    if (result != null && result.Requests.Count > 0)
                    {
                        ProcessCount(result);
                    }
                    else
                        UpdateEntityGridView();
                }
            }
            ); 


        }


        private void ProcessCount(ExecuteMultipleRequest requests)
        {
            foreach (var f in requests.Requests)
            {
                QueryExpression query = (QueryExpression)((RetrieveMultipleRequest)f).Query;
                var x = EntityItems.Where(e => e.LogicalName == query.EntityName).FirstOrDefault();
                x.SetCounting(query);
            }

            UpdateEntityGridView();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Counting records",
                Work = (worker, args) =>
                {
                    args.Result = Service.Execute(requests);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as ExecuteMultipleResponse;
                    if (result != null)
                    {

                        List<RetrieveMultipleResponse> lstResop = result.Responses.Where(s => s.Fault == null).Select(r => r.Response as RetrieveMultipleResponse).ToList();

                        lstResop.ForEach(ls =>
                        {
                            EntityItems.Where(w => w.LogicalName == ls.EntityCollection.EntityName ).ToList().ForEach(ei
                            =>
                            {
                                ei.ProcessResponses(lstResop);
                            }
                          );
                        }
                        );
                        
                        List<ExecuteMultipleResponseItem> lstError = result.Responses.Where(s => s.Fault != null).Select(r => r as ExecuteMultipleResponseItem).ToList();
                        lstError.ForEach(e =>
                        {
                            var reque = requests.Requests[e.RequestIndex] as RetrieveMultipleRequest;
                            QueryExpression qe = (QueryExpression)reque.Query;
                            Guid userId = (Guid)qe.Criteria.Conditions.ToList().First().Values[0];
                            EntityItems.Where(ent => ent.LogicalName == qe.EntityName).First().SetError(userId);
                        }
                        );
                        QueueRecords();
                    }
                }
            });
        }
    }
}