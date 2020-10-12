using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LootLoOnline_FunctionApp.Models
{
    [Table("VisitedUsers", Schema = "User")]
    public class VisitedUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string MacId { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> CatagoryID { get; set; }
        public string CatagoryPath { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ProductTitle { get; set; }
        public string ProductUrl { get; set; }
        public string ImageUrl { get; set; }
        public string ProductId { get; set; }
        public Nullable<System.DateTime> LastVisitedDate { get; set; }
        public Nullable<bool> ClickedOnBuyNow { get; set; }
    }
}
