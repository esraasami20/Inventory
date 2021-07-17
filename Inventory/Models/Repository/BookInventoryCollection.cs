using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models.Repository
{
    public class BookInventoryCollection
    {
        //Intializes the mongo db repository
        internal MongodbRepo _repo = new MongodbRepo("mongodb://127.0.0.1:27017", "QueryMongoDb");
        //Defines the collection name used by project
        private const string _collectionName = "BookInventoryCollection";
        //Contains all documents inside the collection
        public IMongoCollection<BookInventory> Collection;

        //Constructor
        public BookInventoryCollection()
        {
            this.Collection = _repo.Db.GetCollection<BookInventory>(_collectionName);
        }
        public void InsertBookInventory(BookInventory bookInventory)
        {
            this.Collection.InsertOneAsync(bookInventory);
        }
        public List<BookInventory> SelectAll()
        {
            var query = this.Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }
        public BookInventory Get(string bookInventoryId)
        {
            return this.Collection.Find(new BsonDocument { { "_id", new ObjectId(bookInventoryId) } }).FirstAsync().Result;
        }
        public void UpdateBookInventory(string bookInventoryId, BookInventory bookInventory)
        {
            bookInventory._id = new ObjectId(bookInventoryId);

            var filter = Builders<BookInventory>.Filter.Eq(s => s._id, bookInventory._id);
            this.Collection.ReplaceOneAsync(filter, bookInventory);
        }
        public void DeleteBookInventory(string bookInventoryId, BookInventory book)
        {
            book._id = new ObjectId(bookInventoryId);

            var filter = Builders<BookInventory>.Filter.Eq(s => s._id, book._id);
            this.Collection.DeleteOne(filter);
        }
    }
}