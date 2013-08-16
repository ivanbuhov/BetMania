using BetMania.AvatarUploader;
using BetMania.Notifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotificationsTest
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {

            Notifications.Publish("Test");
            AvatarUploader avatarUploder = new AvatarUploader();

            string pathOfTheAvatar = AvatarUploader.Upload("Sasho", @"C:\google.jpeg");
            //Notifications.Publish(pathOfTheAvatar);
            Console.WriteLine(pathOfTheAvatar);
        }
    }
}
