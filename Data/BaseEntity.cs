using System;
using System.ComponentModel.DataAnnotations;

namespace YinHua.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

    }
}