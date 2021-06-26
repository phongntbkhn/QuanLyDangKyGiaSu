using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models.Session;

namespace TutoringCenter.VN.Controllers
{
    public class BaseController : Controller
    {
        const string SESSION_ID = "_session_id";
        const string SESSION_NAME = "_session_name";
        const string SESSION_ROLE = "_session_role";
        const string SESSION_PERSONID = "_session_personid";

        public Session GetSession()
        {
            Session session = new Session();
            session.Id = HttpContext.Session.GetString(SESSION_ID);
            session.UserName = HttpContext.Session.GetString(SESSION_NAME);
            session.RoleHome = HttpContext.Session.GetString(SESSION_ROLE);
            session.idPerson = HttpContext.Session.GetString(SESSION_PERSONID);

            if (session.Id == null)
            {
                return null;
            }
            return session;
        }

        public void SetSession(Session session)
        {
            HttpContext.Session.SetString(SESSION_ID, session.Id);
            HttpContext.Session.SetString(SESSION_NAME, session.UserName);
            HttpContext.Session.SetString(SESSION_ROLE, session.RoleHome);
            HttpContext.Session.SetString(SESSION_PERSONID, session.idPerson);
        }

        public void RemoveSession()
        {
            HttpContext.Session.Remove(SESSION_ID);
            HttpContext.Session.Remove(SESSION_NAME);
            HttpContext.Session.Remove(SESSION_ROLE);
            HttpContext.Session.Remove(SESSION_PERSONID);
        }
    }
}
