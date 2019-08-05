using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

using System.Web.Http;
using System.Text.RegularExpressions;

namespace ChunckAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string Get()
        {

            string text = "John Davis-Clarke's 5 pets only beh-ave when there is food present.";

            string[] words = text.Split(' ');

            int len = words.Length;

            var regex = new Regex("^[a-zA-Z0-9 ]*$");

            var wordregex = new Regex("^[a-zA-Z0-9 '-]*$");

            string str = string.Empty;

            if (regex.IsMatch(words[0]))
            {

                if (words[len - 1].Contains(".") || words[len - 1].Contains("?"))
                {

                    for (int i = 0; i <= len - 1; i++)
                    {

                        if (i != len - 1)
                        {
                            if (!wordregex.IsMatch(words[i]))
                            {
                                return string.Empty;
                            }
                        }

                        else
                        {
                            int len1 = words[i].Length;
                            str = words[i].Substring(len1 - 1);
                            words[i] = words[i].Remove(len1 - 1);
                            if (!wordregex.IsMatch(words[i]))
                            {
                                return string.Empty;
                            }
                        }
                    }
                    for (int i = 0; i < words.Length / 2; i++)
                    {
                        string tmp = words[i];
                        words[i] = words[words.Length - i - 1];
                        words[words.Length - i - 1] = tmp;
                    }

                    text = string.Join(" ", words) + str;
                    return text;
                }
                else
                    return string.Format("String not meeting the constraints.");
           }
            return string.Format(" String not meeting the constraints.");
        }

        //public List<string> Get(string para)
        //{
        //    List<string> outputlist = new List<string>();
        //    return outputlist;
        //}

        // POST api/values
        // public String Post([FromBody]string value)
        //  {

        //     return "Sucess";
        // }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class APIOutput
    {
        public string chunckoutput { get; set; }

    }
}