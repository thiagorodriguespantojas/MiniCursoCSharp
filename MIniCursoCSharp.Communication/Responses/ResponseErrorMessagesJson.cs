﻿namespace MIniCursoCSharp.Communication.Responses
{
    public class ResponseErrorMessagesJson
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessagesJson(string message)
        {
            Errors = [message];
        }
    }
    }
}