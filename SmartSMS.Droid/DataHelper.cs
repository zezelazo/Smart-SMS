using System;
using System.Collections.Generic;
using RestSharp;

namespace SmartSMS.Droid
{
    public sealed class DataHelper
    {
        private RestClient _cli;
        private string _url;
        public IEnumerable<string> GetSmsJob(string url)
        {
            
            var request = new RestRequest("api/smses", Method.POST);
            request.AddParameter("pending", "true");

            var response =  GetClient(url).Execute<IEnumerable<String>>(request);


        }

        public void SmsSent(int smsId, string url)
        {

        }

        public void SmsDelivered(int smsId,string url)
        {

        }

        private RestClient GetClient(string url)
        {
            if (_cli ==null || _url != url)
            {
                _cli = new RestClient(_url);
            }
            return _cli;

        }

        #region Singleton Implementation


        private static readonly DataHelper instance= new DataHelper();

        static DataHelper()
        {
        }

        private DataHelper()
        {
        }

        
        public static DataHelper Instance
        {
            get
            {

                return instance;
            }
        }
        #endregion

    }

}

