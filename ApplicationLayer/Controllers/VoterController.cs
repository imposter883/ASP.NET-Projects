using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    [RoutePrefix("api/voter")]
    public class VoterController : ApiController
    {
        //CRUD
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll() 
        {
            try
            {
                var data = VoterService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = VoterService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Voter not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(VoterDTO voter) 
        {
            try
            {
                var data = VoterService.Create(voter);
                return Request.CreateResponse(HttpStatusCode.OK, "Voter created successfully");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse (HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Route("Update/{id}")]
        public HttpResponseMessage Update(int id,VoterDTO voter) 
        {
            try
            {
                voter.VoterId = id;
                var data = VoterService.Update(voter);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Voter not found or update failed");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Voter updated successfully");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);            
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id) 
        {
            try
            {
                var success = VoterService.Delete(id);
                if (!success) 
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,"Voter not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK,"Voter deleted successfully");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError ,ex.Message);
            }
        }

        //Feature Searching

        [HttpGet]
        [Route("search/{name}")]
        public HttpResponseMessage SearchByName(string name) 
        {
            try
            {
                var data = VoterService.SearchByName(name);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Voter with this name not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError , ex.Message);
            }
        }

        [HttpGet]
        [Route("email/{*email}")]
        public HttpResponseMessage GetByEmail(string email) 
        {
            try
            {
                var data = VoterService.GetByEmail(email);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Voter with this email not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError , ex.Message);
            }
        }
    }
}
