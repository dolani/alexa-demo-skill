using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using DemoPrayerSkill.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrayerSkill.Contract
{
    public class LaunchRequestHandler : ILaunchRequestHandler
    {
        public Task<SkillResponse> Launch(Session session)
        {
            string msg = $"Welcome, would you like a daily reminder at one p.m. to pickup an apple from the stand?";
            Reprompt rp = new Reprompt(msg);
            var response = ResponseBuilder.Ask(msg, rp, session);
            return Task.FromResult(response);
        }
    }
}
