using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models.Repository
{
    public class MongodbRepo
    {
        //The client that manage the connection
        public MongoClient Client;
        //The interface that manage the database
        public IMongoDatabase Db;
        public MongodbRepo(string url, string database)
        {
            this.Client = new MongoClient(url);
            //if the database is not exist, creates the database
            this.Db = this.Client.GetDatabase(database);
        }
    }
}