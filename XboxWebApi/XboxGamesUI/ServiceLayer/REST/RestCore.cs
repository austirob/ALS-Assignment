using RestSharp;
using System;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Threading;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using XboxGamesUI.ServiceLayer.Dtos;

namespace XboxGamesUI.ServiceLayer.REST
{
    public class RestCore  
    {
       
        private const int RestRequestTimeout = 600000;        
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer(); // Safe to share between threads.
        private static readonly JsonDeserializer JsonDeserializer = new JsonDeserializer();

       
        private readonly RestClient _client;  
        private readonly Object _clientLock = new Object();
        public RestCore()
        {
            _client = CreateRestClient(ConfigurationManager.AppSettings["ServerHostname"], 
                ConfigurationManager.AppSettings["ServerPort"]);
        }


       
        public TOutput SendJsonWithBody<TBody, TOutput>(TBody body, Method method, string url) where TOutput : new()
        {
            var request = new RestRequest(url, method)
            {
                JsonSerializer = JsonSerializer,
                RequestFormat = DataFormat.Json,
            };

            request.AddBody(body);
            return ExecuteRequest<TOutput>(request);
        }

        public T ExecuteRequest<T>(RestRequest request) where T : new()
        {

            var currentThreadCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            
            request.OnBeforeDeserialization = OnBeforeDeserialization();
            IRestResponse<T> response;
            // RestClient is not thread-safe, as per https://groups.google.com/forum/?fromgroups=#!topic/restsharp/X8JPtcfnSlo so synchronise access to it

            lock (_clientLock)
            {
                response = _client.Execute<T>(request);
            }
            HandleResponse(response);
            Thread.CurrentThread.CurrentCulture = currentThreadCulture;
            return response.Data;
        }


        internal IRestResponse ExecuteRequest(IRestRequest request)
        {            
            request.Timeout = RestRequestTimeout;
            
            var currentThreadCulture = Thread.CurrentThread.CurrentCulture;
         
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            
            IRestResponse response;
            // RestClient is not thread-safe, as per https://groups.google.com/forum/?fromgroups=#!topic/restsharp/X8JPtcfnSlo so synchronise access to it
            lock (_clientLock)
            {
                response = _client.Execute(request);
            }
            ParseExceptionMessage(response);
            HandleResponse(response);

            Thread.CurrentThread.CurrentCulture = currentThreadCulture;
           

            return response;
        }



       

        public T ExecuteRequest<T>(string url) where T : new()
        {       
            
            var request = new RestRequest(url);

            request.Timeout = RestRequestTimeout;
            var currentThreadCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
           
            request.OnBeforeDeserialization = OnBeforeDeserialization();
            IRestResponse<T> response;
            // RestClient is not thread-safe, as per https://groups.google.com/forum/?fromgroups=#!topic/restsharp/X8JPtcfnSlo so synchronise access to it

            lock (_clientLock)
            {
                response = _client.Execute<T>(request);
            }
            HandleResponse(response);

            Thread.CurrentThread.CurrentCulture = currentThreadCulture;
            return response.Data;

        }

                       
       

        private Action<IRestResponse> OnBeforeDeserialization()
        {
            return ParseExceptionMessage;
        }

        void HandleResponse(IRestResponse response)
        {
     

            var url = GetFullUrl(response.Request);
            if (response == null)
            {
                throw new XboxGamesServiceException("No response returned from call to '" + url + "'!");
            }

            if (response.StatusCode.Equals(HttpStatusCode.NoContent)) // 204
            {
                return; // No content in the response, so don't look for any parsing exceptions.
            }
            if (response.ErrorException != null)
            {
                throw new XboxGamesServiceException("An exception occurred when calling '" + url + "'! Exception: " + response.ErrorException.Message,
                    response.ErrorException);
            }
            if (response.ResponseStatus != ResponseStatus.Completed || !IsSuccessStatus(response.StatusCode))
            {
                throw new XboxGamesServiceException("Invalid status returned from call to '" + url + "'. ResponseStatus: "
                                                   + response.ResponseStatus + ", StatusCode: " + response.StatusCode + ", ErrorMessage: " + response.ErrorMessage);
            }                                          

        }

               /*
         * Indicates a 20x HTTP status code
         */
        static bool IsSuccessStatus(HttpStatusCode statusCode)
        {
            return ((int)statusCode).CompareTo(200) >= 0 && ((int)statusCode).CompareTo(300) < 0;
        }

        void ParseExceptionMessage(IRestResponse response)
        {
            // Anything other than a 20x status code     

            if (!IsSuccessStatus(response.StatusCode))
            {

                if (HttpStatusCode.Forbidden == response.StatusCode)
                {
                    throw new XboxGamesServiceException("Access to " + GetFullUrl(response.Request) + " is unauthorised for this user!");
                }

                var message = response.ErrorException != null ? response.ErrorException.Message : response.Content;
                ExceptionResponseDTO exceptionResponse = null;
                try
                {
   
                    //try to get a meaningful message from the server.                   
                    var deserializer = new JsonDeserializer();
                    exceptionResponse = deserializer.Deserialize<ExceptionResponseDTO>(response);
                    message = exceptionResponse.Message;
                }
                catch (Exception e)
                {                    
                    Console.WriteLine(e.ToString());
                    throw e;
                }
                throw new XboxGamesServiceException(
                    "Call to " + GetFullUrl(response.Request) + " failed! Status " + response.StatusCode + " returned. Exception: " + message, exceptionResponse);
            }
        }

        String GetFullUrl(IRestRequest request)
        {
            return _client.BaseUrl + "/" + request.Resource;
        }

        private static RestClient CreateRestClient(String serverHostname, 
                                                    String serverPort = null)
        {
         
            var url = "http://" + serverHostname + (String.IsNullOrEmpty(serverPort) ? "" : ":" + serverPort) + "/";
            var rstClient = new RestClient(url);
            
            rstClient.AddHandler("application/json", JsonDeserializer);

            return rstClient;
        }
    }
}
