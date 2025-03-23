namespace MIniCursoCSharp.Communication.Responses
{
    public class ResponseErrorMessagesJson
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessagesJson(string message)
        {
            Errors = new List<string> { message };
        }
    }

    public class ResponseClientJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class ResponseResponseJson : ResponseResponseJsonBase
    {
        public ResponseResponseJson() { }
        public ResponseResponseJson(string message)
        {
            Message = message;
        }

        public ResponseResponseJson(string message, string message2)
        {
            Message = message + message2;
        }

        public ResponseResponseJson(string message, string message2, string message3)
        {
            Message = message + message2 + message3;
        }

        public ResponseResponseJson(string message, string message2, string message3, string message4)
        {
            Message = message + message2 + message3 + message4;
        }
 }
