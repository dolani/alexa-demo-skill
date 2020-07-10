using Alexa.NET.Request;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrayerSkill.Abstract
{
    public interface ILaunchRequestHandler
    {
        Task<SkillResponse> Launch(Session session);
    }
}
