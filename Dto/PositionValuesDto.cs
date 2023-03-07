using System;

namespace MeroBolee.Dto;

public class PositionValuesDto
{
    public long SupplierId { get; set; }
    public long TenderId { get; set; }
    public decimal Quotation { get; set; }
    public int Interval { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime BidDate { get; set; }
}