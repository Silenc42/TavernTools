using System.ComponentModel.DataAnnotations;

namespace PersistenceSupabase;

public class PocEntity
{
    public required Guid Id { get; init; }
    
    [MaxLength(128)]
    public required string Name { get; init; }
}