using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory.Models
{
    public class Book
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string language { get; set; }
        public int pages { get; set; }
        public string Author { get; set; }
        [ForeignKey("BookInventory")]
        public ObjectId BookInventoryId { get; set; }
        public virtual BookInventory BookInventory { get; set; }
    }
}