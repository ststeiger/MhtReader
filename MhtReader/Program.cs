
namespace MhtReader
{


    // https://github.com/smithimage/MIMER/blob/master/MIMERTests/MHT/MhtTests.cs
    // https://github.com/smithimage/MIMER/
    static class Program
    {


        public static string MapVisualStudioProjectPath(string filename)
        {
            string loc = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            loc = System.IO.Path.Combine(loc, "../..");
            loc = System.IO.Path.GetFullPath(loc);
            loc = System.IO.Path.Combine(loc, filename);

            return loc;
        }


        public static void GetMainText(string filename)
        {
            System.IO.Stream m_Stream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            MIMER.RFC2045.MailReader reader = new MIMER.RFC2045.MailReader();
            MIMER.IEndCriteriaStrategy endofmessage = new MIMER.RFC2045.BasicEndOfMessageStrategy();
            MIMER.RFC2045.IMimeMailMessage message = reader.ReadMimeMessage(ref m_Stream, endofmessage);


            System.Collections.Generic.IDictionary<string, string> allContents = message.Body;

            string strFile = allContents["text/html"];


            foreach (System.Collections.Generic.KeyValuePair<string, string> kvp in allContents)
            {
                System.Console.WriteLine(kvp.Key);
                System.Console.WriteLine(kvp.Value);
            } // Next kvp 

        }


        public static void GetMailMainText(string filename)
        {
            System.IO.Stream m_Stream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            MIMER.IMailReader reader = new MIMER.RFC2045.MailReader();
            MIMER.IEndCriteriaStrategy endofmessage = new MIMER.RFC2045.BasicEndOfMessageStrategy();
            MIMER.IMailMessage message = reader.Read(ref m_Stream, endofmessage);

            System.Console.WriteLine(message.TextMessage);
        }


        static void Main()
        {

            string path = MapVisualStudioProjectPath("whatismht.mht");
            GetMainText(path);
            GetMailMainText(path);

            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        } // End Sub Main 


    }


}
