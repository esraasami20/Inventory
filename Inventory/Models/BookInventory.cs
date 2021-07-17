using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BookInventory
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        [BsonElement("Name")]
        public string InventoryName { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        //public List<Book> books { get; set; }
        public virtual IEnumerable<ObjectId> BookIds { get; set; }

    }
}