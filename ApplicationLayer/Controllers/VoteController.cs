using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    [RoutePrefix("api/vote")]
    public class VoteController : ApiController
    {
        [HttpPost]
        [Route("cast")]
        public HttpResponseMessage CastVote(int voterId, int electionId, int candidateId)
        {
            try
            {
                if (VoteService.HasVoterVoted(voterId, electionId))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Voter has already voted in this election");
                }
                var success = VoteService.CastVote(voterId, electionId, candidateId);
                return Request.CreateResponse(HttpStatusCode.OK, success);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("result/{electionId}")]
        public HttpResponseMessage GetResult(int electionId)
        {
            try
            {
                var data = VoteService.GetResult(electionId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("winner/{electionId}")]
        public HttpResponseMessage GetWinner(int electionId)
        {
            try
            {
                var data = VoteService.Winner(electionId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
