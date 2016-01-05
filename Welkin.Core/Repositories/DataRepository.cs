using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace Avanzar.Welkin.Core.Repositories
{
    public class DataRepository : IDataRepository
    {
        string authKey;
        string uri; 

        DocumentClient _client;
        ISettingsRepository _settings;
        public DataRepository(ISettingsRepository settings)
        {
            _settings = settings;
            uri = _settings.DocDBUri;
            authKey = ConfigurationManager.AppSettings["DocumentDBAuhKey"];
        }

        private DocumentClient GetClient( string _uri, string _authKey)
        {
            try
            {
                if (_client == null)
                {
                    return _client = new DocumentClient(new Uri(_uri), _authKey);
                }
                else
                    return _client;

            }
            catch (Exception)
            {
                return null;
            }
        }

        private Database GetDatabase()
        {
            try
            {
                return GetClient(uri, authKey).CreateDatabaseQuery().Where(db => db.Id == "welkindocdb").AsEnumerable().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception("Cannot connect to the Database. See inner exception. " + ex.InnerException);
            }
           
        }


        //Check if the collection is there if not then create
        private void CreateDocumentColelction(string type)
        {
            try
            {
                DocumentCollection documentCollection = GetClient(uri, authKey).
                    CreateDocumentCollectionQuery("dbs/" + GetDatabase().Id).Where(c => c.Id == type).
                    AsEnumerable().FirstOrDefault();

                if (documentCollection == null)
                {
                    GetClient(uri, authKey).CreateDocumentCollectionAsync("dbs/" + GetDatabase().Id,
                        new DocumentCollection
                        {
                            Id = type
                        });
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);          
            }

        }


        public async Task DeleteDocsAsync(string collName)
        {
            using (_client)
            {
                try
                {

                    var coll = GetClient(uri, authKey).CreateDocumentCollectionQuery(GetDatabase().CollectionsLink).Where(d=> d.Id== collName).ToList().First();
                    var docs = GetClient(uri, authKey).CreateDocumentQuery(coll.DocumentsLink);

                    foreach (var doc in docs)
                    {
                        await GetClient(uri, authKey).DeleteDocumentAsync(doc.SelfLink);
                    }

                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    throw;
                }
            }
        }

        public async void UpsertDocument(string document)
        {
            try
            {

                string collName = string.Empty;

                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(document));

                Document doc = Document.LoadFrom<Document>(ms);

                var res = await GetClient(uri, authKey).CreateDocumentAsync("dbs/" + GetDatabase().Id + "/colls/" + collName, doc);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Document. : " + ex.InnerException);
            }
        }
    }
}
