namespace GameStore.Contracts
{
    public record GamesRequest(
        string Name,
        string Description,
        decimal Price );
}
