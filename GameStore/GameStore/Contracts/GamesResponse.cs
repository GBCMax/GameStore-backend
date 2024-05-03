namespace GameStore.Contracts
{
    public record GamesResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price);
}
