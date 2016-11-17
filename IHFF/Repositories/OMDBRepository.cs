using IHFF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace IHFF.Repositories
{
    public class OMDBRepository
    {
        public static OMDBMovie OMDBResponse(string movieName, string year)
        {
            movieName = movieName.Replace(' ', '+');
            string url = "http://www.omdbapi.com/?t=" + movieName + "&y=" + year + "&plot=full&r=json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    OMDBMovie movieInfo = new OMDBMovie();
                    JsonConvert.PopulateObject(reader.ReadToEnd(), movieInfo);
                    return movieInfo;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

    }
}