using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BetMania.Notifier
{
    public static class Notifications
    {
        public const string PUBLISH_KEY = "pub-c-f4fde725-6da4-4350-b8f1-ec891116f55a";
        public const string SUBSCRIBE_KEY = "sub-c-8743658c-04be-11e3-a5e8-02ee2ddab7fe";
        public const string SECRET_KEY = "sec-c-NjMxZTYxMTAtZGM5NC00NWQ2LTliMzUtODNlZmY4M2Q4Zjhj";
        public const bool SSL_ON = true;
        public static Pubnub pubnub = new Pubnub(PUBLISH_KEY, SUBSCRIBE_KEY, SECRET_KEY, SSL_ON);
        public const string Channel = "The_Joker";
              
        public static void Publish(string message)
        {
            pubnub.publish(Channel, message);
        }
    }
   
}
