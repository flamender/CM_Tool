﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CmTool.Domain.Models;

namespace CmTool.WebApi.Controllers
{
    public class JenkinsController : ApiController
    {
        // GET:  JenkinsBuildModel
        public IEnumerable<JenkinsBuildModel> Get()
        {
            //var rep = new 
            return new JenkinsBuildModel[] { new JenkinsBuildModel { CustomerName = "MIGROS" } , new JenkinsBuildModel { CustomerName = "WF-Energie" }};
        }

        // GET JenkinsBuildModel/5
        public string Get(int id)
        {
            return "Hallo";
        }

        // POST JenkinsBuildModel
        public void Post([FromBody]string value)
        {
        }

        // PUT JenkinsBuildModel
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE JenkinsBuildModel/5
        public void Delete(int id)
        {
        }
    }
}