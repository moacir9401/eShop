using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Email.Model.Base
{
    [Table("Email_logs")]
    public class EmailLog : BaseEntity
    { 

        [Column("email")]
        public string Email { get; set; }
        [Column("log")]
        public string Log { get; set; }
        [Column("sent_date")]
        public DateTime SentDate { get; set; }
    }
}
