using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    [RoutePrefix("api/candidate")]
    public class CandidateController : ApiController
    {
        //CRUD

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = CandidateService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = CandidateService.Get(id);
                if (data == null) 
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Candidate not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(CandidateDTO candidate)
        {
            try
            {
                var data = CandidateService.Create(candidate);
                if(data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,"Candidate not Found");
                }
                return Request.CreateResponse(HttpStatusCode.Created,"Candidate Created Successfully");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, CandidateDTO candidate) 
        {
            try
            {
                candidate.CandidateId = id;
                var data = CandidateService.Update(candidate);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Candidate not found or update failed");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Candidate Updated Succesffuly");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id) 
        {
            try
            {
                var success = CandidateService.Delete(id);
                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Candidate Not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Candidate deleted Succesffuly");
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        //Feature
        [HttpGet]
        [Route("election/{eId}")]
        public HttpResponseMessage CandidateByElection(int eId)
        {
            try
            {
                var data = CandidateService.CandidateByElection(eId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("search/{name}")]
        public HttpResponseMessage Search(string name)
        {
            try
            {
                var data = CandidateService.SearchByName(name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
