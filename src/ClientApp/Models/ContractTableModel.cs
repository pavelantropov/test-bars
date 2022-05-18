using System;

namespace ClientApp.Models
{
    public class ContractTableModel
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsValid =>
            (DateTime.UtcNow - UpdatedOn)?.Days < 30;
    }
}