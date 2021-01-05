using System.Collections.Generic;

namespace KeelNotice
{
    public class ServerChanOptions
    {
        public string Api { set; get; }

        public List<string> ScKeys { set; get; } = new();
    }
}