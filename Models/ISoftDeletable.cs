namespace calculadora_custos.Models;

public interface ISoftDeletable
{
    DateTime? DeletedAt { get; set; }
}