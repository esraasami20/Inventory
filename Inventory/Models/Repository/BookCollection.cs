using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Inventory.Models.Repository
{
    public class BookCollection
    {
        //Intializes the mongo db repository
        internal MongodbRepo _repo = new MongodbRepo("mongodb://127.0.0.1:27017", "QueryMongoDb");
        //Defines the collection name used by project
        private const string _collectionName = "BookCollection";
        //Contains all documents inside the collection
        public IMongoCollection<Book> Collection;

        //Constructor
        public BookCollection()
        {
            this.Collection = _repo.Db.GetCollection<Book>(_collectionName);
        }
        public void InsertBook(Book book)
        {
            this.Collection.InsertOneAsync(book);
        }
        public  List<Book> SelectAll()
        {
            var query =  this.Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }
        public Book Get(string id)
        {
            return this.Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
        }
        public void UpdateBook(string id, Book book)
        {
            book._id = new ObjectId(id);

            var filter = Builders<Book>.Filter.Eq(s => s._id, book._id);
            this.Collection.ReplaceOneAsync(filter, book);
        }
        public void DeleteBook(string id, Book book)
        {
            book._id = new ObjectId(id);

            var filter = Builders<Book>.Filter.Eq(s => s._id, book._id);
            this.Collection.DeleteOne(filter);
        }
    }
}