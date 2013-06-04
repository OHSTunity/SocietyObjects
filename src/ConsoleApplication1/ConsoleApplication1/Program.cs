using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    public class Program
    {
        private static com.proofhq.www.soapService _hq;

        public static com.proofhq.www.soapService HQ
        {
            get
            {
                if (_hq == null)
                {
                    _hq = new com.proofhq.www.soapService();
                }
                _hq.Url = @"https://www.proofhq.com/12_7_0/soap/";
                _hq.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                return _hq;
            }
        }
        private static com.proofhq.www.SOAPLoginObject _login = null;


        public static com.proofhq.www.SOAPLoginObject CheckSession()
        {
            try
            {
                try
                {
                    if (_login != null)
                    {
                        if (HQ.checkSession(_login.session))
                        {
                            return _login;
                        }
                    }
                }
                catch
                {
                }

                _login = HQ.doLogin("mattias@tunity.se","makmak99");
                return _login;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            com.proofhq.www.SOAPLoginObject login = CheckSession();
            int id = 1841394;
           // com.proofhq.www.SOAPFileObject obj = HQ.getProofDetails(login.session, id);

            com.proofhq.www.SOAPRecipientObject[] reviewers = HQ.getProofReviewers(login.session, id.ToString());

            Console.WriteLine(HQ.SoapVersion);

            string url = HQ.getProofURL(login.session, id);
            Console.WriteLine(url);

            List<com.proofhq.www.SOAPFileRecipientObject> list = new List<com.proofhq.www.SOAPFileRecipientObject>();
            com.proofhq.www.SOAPFileRecipientObject so = new com.proofhq.www.SOAPFileRecipientObject();
            so.name = "David Rosendahl";
            so.email = "david.rosendah@gmail.com";
            so.role = "5";
            //Five years forward
            DateTime fiveyears = DateTime.Now + new TimeSpan(1576800000000000);
            so.deadline = fiveyears.ToString("yyyy-MM-dd HH:mm");
            so.notifications = "9";               
            list.Add(so);

            Boolean result = HQ.addProofReviewers(login.session, id, list.ToArray());

            Console.WriteLine(result);

         /*   List<int> obj = new List<int>();
            obj.Add(1790821);
            object[] test = new object[obj.Count];
            for (int i = 0; i < obj.Count; i++)
            {
                test[i] = obj[i];
            }
            DateTime deadlineD = DateTime.Now + new TimeSpan(50, 50, 50, 50, 50);
             string deadline = deadlineD.ToString("yyyy-MM-dd HH:mm");
                      
            HQ.addReviewerToProofs(login.session, test, "david.rosendahl@gmail.com",
                          "david.rosendahl@gmail.com", "", deadline, "5", "9", false, "false"); */
                       
            
        }

        private static void handleNewComment(XmlNode node)
        {
            String id =  node.SelectSingleNode("//comment_id").InnerText;
            String file_id = node.SelectSingleNode("//file_id").InnerText;
            String author = node.SelectSingleNode("//author").InnerText;
            String comment = node.SelectSingleNode("//comment").InnerText;
            String timestamp = node.SelectSingleNode("//timestamp").InnerText;
        }

    }
    public class ProofHqUploadedFile
    {
        public String fileHash;
        public String fileName;
        public String md5;
        public String errorcode;

        public Boolean Valid
        {
            get
            {
                return ((fileHash != null) && (fileHash.Length > 0)) &&
                    ((errorcode == null) || (errorcode.Length == 0));
            }
        }
    }
}
