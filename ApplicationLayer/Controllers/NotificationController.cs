using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("unread/{voterId}")]
        public HttpResponseMessage GetUnread(int voterId)
        {
            try
            {
                var data = NotificationService.UnreadNotifications(voterId);
                return Request.CreateResponse(HttpStatusCode.OK, "Mark as Unread");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("read/{id}")]
        public HttpResponseMessage MarkAsRead(int id)
        {
            try
            {
                var data = NotificationService.MarkAsRead(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Mark as Read");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
