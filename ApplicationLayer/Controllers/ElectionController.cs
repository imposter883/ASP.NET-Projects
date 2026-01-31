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
    [RoutePrefix("api/election")]
    public class ElectionController : ApiController
    {

        // ---------- CRUD ----------
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ElectionService.Get();
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
                var data = ElectionService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Election not found");
                }   
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ElectionDTO election)
        {
            try
            {
                var data = ElectionService.Create(election);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Election Not Found");
                }
                return Request.CreateResponse(HttpStatusCode.Created,"Election is Created Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage Update(int id, ElectionDTO election)
        {
            try
            {
                election.ElectionId = id;
                var data = ElectionService.Update(election);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Election Not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Election is Updated Successfully");
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
                var success = ElectionService.Delete(id);
                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Election not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Election deleted successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // ---------- FEATURES ----------
        [HttpGet]
        [Route("active")]
        public HttpResponseMessage ActiveElections()
        {
            try
            {
                var data = ElectionService.ActiveElections();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("end/{id}")]
        public HttpResponseMessage EndElection(int id)
        {
            try
            {
                var data = ElectionService.EndElection(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("search/{title}")]
        public HttpResponseMessage Search(string title)
        {
            try
            {
                var data = ElectionService.SearchElection(title);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

