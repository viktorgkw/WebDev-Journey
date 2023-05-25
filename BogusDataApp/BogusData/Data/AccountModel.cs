namespace BogusData.Data;

public record AccountModel
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsAdult { get; set; }
    public AccountQuality AccountQuality { get; set; }
}