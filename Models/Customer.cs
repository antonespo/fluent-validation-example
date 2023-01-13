namespace FluentValidationExample.Models;

internal class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Status { get; set; }
    public Address Address { get; set; }
}