using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("ImageStore")]
    public class ImageStore
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageBase64String { get; set; }
        public string ImagePathString { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
