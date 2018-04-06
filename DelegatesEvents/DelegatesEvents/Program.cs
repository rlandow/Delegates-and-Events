using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    //https://www.youtube.com/watch?v=jQgwEsJISy0
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher

            var mailServive = new MailSevice(); //subscriber

            var messageService = new Messageservice(); //subscriber

            videoEncoder.VideoEncoded += mailServive.OnVideoEncoded; //the pointer
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded; //the pointer

            videoEncoder.Encode(video);

            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }

    public class MailSevice 
        {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Email sent..." + e.Video.Title);
        }

    
    }

    public class Messageservice
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MessageService: Seneind a text msssage...." + e.Video.Title);
        }
    }
        

}
