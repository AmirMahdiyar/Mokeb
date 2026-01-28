namespace Mokeb.Application.CommandHandler.AdminCommands.AddingRoom
{
    public class AddingRoomCommandResponse
    {
        public static AddingRoomCommandResponse Succeeded = new() { Success = true };
        public bool Success { get; set; }
    }
}
