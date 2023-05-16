using Grpc.Net.Client;
using gRoom.gRPC.Messages;

using var channel = GrpcChannel.ForAddress("http://localhost:5207");
var client = new Groom.GroomClient(channel);
Console.WriteLine("Enter room name to register: ");
var roomName = Console.ReadLine();

var res = client.RegisterToRoom(new RoomRegistrationRequest { RoomName = roomName});
var roomId = res.RoomId;
Console.WriteLine($"Room ID: {roomId}");
Console.ReadLine();