using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeroBolee.Model
{
    [Table("mb_algorithm")]
    public class AlgorithmEntity
    {
        [Column(TypeName = "INT")]
        public int id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [MaxLength(3999)]
        public String AlgoName { get; set; }
    }
}