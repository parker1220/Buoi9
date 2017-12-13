using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LucNguyenPhuc_Buoi9
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            string log = "";

            client.Connect("mail.emailserver.vn", 25);

            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            log += "Server: " + sr.ReadLine() + "\n";

            string data = "HELO";//một vài server yêu cầu phải HELO sender hostname

            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();

            log += "Server: " + sr.ReadLine() + "\n";

            //Khai báo địa chỉ người gửi
            data = "MAIL FROM: <" + "nguyxxdoxxphoxx.it@gmail.com" + ">";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";

            //Khai báo địa chỉ người nhận
            data = "RCPT TO: <" + "phong.nd@emailserver.vn" + ">";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";

            //Gửi yêu cầu báo hiệu sẽ gửi nội dung bức thư
            data = "DATA";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";

            //Khai báo nội dung bức thư
            data = emailContent + "\r\n" + ".";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";

            //Ngắt kết nối với SMTP Server hoặc Email Server
            data = "QUIT";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";

            sr.Close();
            sw.Close();
            client.Close();
        }

        public static string emailContent { get; set; }
    }
}
