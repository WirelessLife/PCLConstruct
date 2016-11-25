using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCLConstruct.Client.Helpers;
using PCLConstruct.Client.Helpers.DTO;
using PCLConstruct.Client.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCLConstruct.Client.Services
{
    /// <summary>
    /// Service that gets the data from azure mobile services
    /// </summary>
    public class DataService
    {
        public static DataService Default { get; } = new DataService();

        private MobileServiceClient _MobileService;
        IMobileServiceSyncTable<Form> _formTable;

        AzureSettings _settings;
        private DataService()
        {
            _settings = SettingsHelper.GetConfig();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            var data = await MakeRequest("tables/job");
            var ret = new List<Job>();
            if (data != null)
                ret = JsonConvert.DeserializeObject<List<Job>>(data);
            return ret;
        }

        public async Task<List<CraftWorker>> GetCraftWorkers(string jobId)
        {
            var data = await MakeRequest($"tables/craftworker/{jobId}");
            var ret = new List<CraftWorker>();
            if (data != null)
                ret = JsonConvert.DeserializeObject<List<CraftWorker>>(data);
            return ret;
        }

        public async Task<List<Form>> GetForms(string craftworkerId)
        {
            var data = await MakeRequest($"tables/form/{craftworkerId}");
            var ret = new List<Form>();
            if (data != null)
                ret = JsonConvert.DeserializeObject<List<Form>>(data);
            return ret;
        }

        /// <summary>
        /// Multifactor authenticate the user in the custom API in mobile service
        /// </summary>
        /// <returns></returns>
        public async Task<bool> MfAuthenticateUser()
        {
            var data = await MakeRequest("api/authkey");
            var ret = false;
            if (data != null)
                ret = true;
            return ret;
        }

        private async Task<string> MakeRequest(string path)
        {
            HttpClient httpClient = new HttpClient();
            Uri _uri = new Uri($"{_settings.MobileService}/{path}");
            httpClient.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            var response = httpClient.GetAsync(_uri);
            var responseBody = await response.Result.Content.ReadAsStringAsync();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                return responseBody;
            else
                return null;
        }

        public async Task Initialize(string url, string accessToken)
        {
            throw new NotImplementedException();

            // if already initied just return
            if(!IsInitialized)
                return;

            // create the new object
            _MobileService = new MobileServiceClient(url);

            //// authenticate with mobile services
            //var payload = new JObject();
            //payload["access_token"] = accessToken;
            try
            {
                //    // login to mobile service
                //    await _MobileService.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, payload);

                // sync the data
                var path = Path.Combine(MobileServiceClient.DefaultDatabasePath, "pcl.db");
                var store = new MobileServiceSQLiteStore(path);
                store.DefineTable<Form>();
                await _MobileService.SyncContext.InitializeAsync(store);
                _formTable = _MobileService.GetSyncTable<Form>();
            }
            catch (Exception e)
            {
                var t = e;
                throw;
            }
        }

        public bool IsInitialized
        {
            get
            {
                throw new NotImplementedException();
                return (_MobileService?.SyncContext?.IsInitialized ?? true);
            }
        }

        

        public async Task SyncData()
        {
            throw new NotImplementedException();
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                
                await this._MobileService.SyncContext.PushAsync();
                System.Diagnostics.Debug.WriteLine($"tableName = {_formTable.TableName}");

                await this._formTable.PullAsync(
                    "allForms",
                    this._formTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.",
                        error.TableName, error.Item["id"]);
                }
            }
        }

        //public async Task AddForm(Form form)
        //{
        //    if (!IsInitialized)
        //        throw new Exception("Needs to be initialized first");

        //    if (form == null)
        //    {
        //        form = new Form
        //        {
        //            description = "Sample Form for testin that was added manually",
        //            id = "999-test",
        //            name = "Sample Form",
        //            sections = new List<Section>
        //            {
        //                new Section
        //                {
        //                    fields = new List<Field>
        //                    {
        //                        new Field
        //                        {
        //                            id = 0,
        //                            max = 10000,
        //                            min = 0
        //                        }
        //                    }
        //                },
        //                new Section
        //                {
        //                    fields = new List<Field>
        //                    {
        //                        new Field
        //                        {
        //                            id = 1,
        //                            max = 10000,
        //                            min = 0
        //                        }
        //                    }
        //                }
        //            },
        //            status = Controls.FormStatus.NotStarted
        //        };
        //    }

        //    try
        //    {
        //        //await _formTable.InsertAsync(form);
        //        await _MobileService.SyncContext.PushAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        var t = e;
        //        throw;
        //    }

        //}

        public async Task<List<Form>> GetForms()
        {
            throw new NotImplementedException();
            if (!IsInitialized)
                throw new Exception("Needs to be initialized first");
            try
            {
                var ret = await _formTable.ReadAsync();
                return ret.ToList();
            }
            catch (Exception e)
            {
                var t = e;
                throw;
            }

        }

    }
}
