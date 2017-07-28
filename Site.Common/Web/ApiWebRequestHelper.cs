using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Site.Common.Web
{
    public class ApiWebRequestHelper
    {
        /// <summary>
        /// Gets a request from an external JSON formatted API and returns a deserialized object of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public static T GetJsonRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string jsonOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        jsonOutput = sr.ReadToEnd();

                    var jsResult = JsonConvert.DeserializeObject<T>(jsonOutput, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    if (jsResult != null)
                        return jsResult;

                    return default(T);
                }

                return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Gets a request from an external XML formatted API and returns a deserialized object of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="headerValues"></param>
        /// <returns></returns>
        public static T GetXmlRequest<T>(string requestUrl, NameValueCollection headerValues = null)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);

                // Add web request header values if they exist.
                if (headerValues?.Count > 0)
                    apiRequest.Headers.Add(headerValues);

                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string xmlOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        xmlOutput = sr.ReadToEnd();

                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));

                    var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

                    if (xmlResult != null)
                        return xmlResult;

                    return default(T);
                }

                return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// A web request is created and returns contents as a string.
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="headerValues"></param>
        /// <returns></returns>
        public static string GetApiRequestAsString(string requestUrl, NameValueCollection headerValues = null)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);

                // Add web request header values if they exist.
                if (headerValues?.Count > 0)
                    apiRequest.Headers.Add(headerValues);

                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string jsonOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        jsonOutput = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(jsonOutput))
                        return jsonOutput;

                    return string.Empty;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// A web request is reated and returns a deserialized object of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static T PostApiRequest<T>(string requestUrl, string postData = "")
        {
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();

                byte[] data = encoding.GetBytes(postData);

                HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create(requestUrl);

                apiRequest.Method = "POST";
                apiRequest.ContentType = "application/x-www-form-urlencoded";
                apiRequest.ContentLength = data.Length;

                Stream newStream = apiRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string jsonOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        jsonOutput = sr.ReadToEnd();

                    var jsResult = JsonConvert.DeserializeObject<T>(jsonOutput, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    if (jsResult != null)
                        return jsResult;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }

            return default(T);
        }
    }
}