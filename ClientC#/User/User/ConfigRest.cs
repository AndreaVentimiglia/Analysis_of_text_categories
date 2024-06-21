using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class ConfigRest
    {
        private static readonly string hostName = "localhost";
        private static readonly string portNumber8080 = "8080";
        private static readonly string insertNewTextRest = "/insert-new-text";
        private static readonly string wordCloudRest = "/word-cloud";
        private static readonly string frequencyGraphsRest = "/frequency-graphs";
        private static readonly string textComparisonRest = "/text-comparison";
        private static readonly string retrieveTextListRest = "/retrieve-text-list";
        private static readonly string retrieveShutdownRest = "/shutdown";
        private static readonly string textSearchRest = "/text-search";


        public static string UrlInsertNewText
        {
            get { return "http://" + hostName + ":" + portNumber8080 + insertNewTextRest; }
        }

        public static string UrlWordCloud
        {
            get { return "http://" + hostName + ":" + portNumber8080 + wordCloudRest; }
        }

        public static string UrlFrequencyGraphs
        {
            get { return "http://" + hostName + ":" + portNumber8080 + frequencyGraphsRest; }
        }

        public static string UrlTextComparison
        {
            get { return "http://" + hostName + ":" + portNumber8080 + textComparisonRest; }
        }

        public static string UrlRetrieveTextList
        {
            get { return "http://" + hostName + ":" + portNumber8080 + retrieveTextListRest; }
        }
        
        public static string UrlRetrieveShutdown
        {
            get { return "http://" + hostName + ":" + portNumber8080 + retrieveShutdownRest; }
        }
        public static string UrlTextSearch
        {
            get { return "http://" + hostName + ":" + portNumber8080 + textSearchRest; }
        }
        

    }
}
