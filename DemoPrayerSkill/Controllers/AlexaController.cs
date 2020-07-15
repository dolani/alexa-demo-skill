using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using DemoPrayerSkill.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoPrayerSkill.Controllers
{
    [Route("api/[controller]")]
    public class AlexaController : Controller
    {
        private readonly IAddPrayerIntentHandler _addPrayerIntentHandler;
        private readonly IClearPrayerIntentHandler _clearPrayerIntentHandler;
        private readonly IViewPrayerIntentHandler _viewPrayerIntentHandler;
        private readonly ISavePrayerIntentHandler _savePrayerIntentHandler;
        private readonly ILaunchRequestHandler _launchRequest;
        private readonly IArchivePrayerIntentHandler _archivePrayerIntentHandler;
        private readonly IAmazonYesIntentHandler _amazonYesIntentHandler;

        readonly ILogger<AlexaController> _log;
        public AlexaController(IAmazonYesIntentHandler amazonYesIntentHandler, IClearPrayerIntentHandler clearPrayerIntentHandler, IAddPrayerIntentHandler addPrayerIntentHandler, IViewPrayerIntentHandler viewPrayerIntentHandler, ISavePrayerIntentHandler savePrayerIntentHandler, ILaunchRequestHandler launchRequest, IArchivePrayerIntentHandler archivePrayerIntentHandler, ILogger<AlexaController> log)
        {
            _addPrayerIntentHandler = addPrayerIntentHandler;
            _clearPrayerIntentHandler = clearPrayerIntentHandler;
            _viewPrayerIntentHandler = viewPrayerIntentHandler;
            _savePrayerIntentHandler = savePrayerIntentHandler;
            _amazonYesIntentHandler = amazonYesIntentHandler;
            _launchRequest = launchRequest;
            _archivePrayerIntentHandler = archivePrayerIntentHandler;
            _log = log;
        }

        [HttpPost]
        public SkillResponse bestil([FromBody]SkillRequest request)
        {

            Session session = request.Session;
            if (session.Attributes == null)
                session.Attributes = new Dictionary<string, object>();

            SkillResponse response = ResponseBuilder.Empty();
            _log.LogInformation("Hello, world!");
            if (request.GetRequestType() == typeof(LaunchRequest))
            {
                response = _launchRequest.Launch(session).Result;
            }
            else if (request.GetRequestType() == typeof(IntentRequest))
            {
                var intentRequest = (IntentRequest)request.Request;
                switch (intentRequest.Intent.Name)
                {
                    case "AddPrayerIntent":
                        response = _addPrayerIntentHandler.HandleIntent(intentRequest, session, request).Result;
                        break;
                    case "ClearPrayerIntent":
                        response = _clearPrayerIntentHandler.HandleIntent(intentRequest, session, request).Result;
                        break;
                    case "AMAZON.YesIntent":
                        response = _amazonYesIntentHandler.HandleIntent(intentRequest, session, request).Result;
                        break;
                    case "SavePrayerIntent":
                        response = _savePrayerIntentHandler.HandleIntent(intentRequest, session, request).Result;
                        break;
                    case "ArchivePrayerIntent":
                        response = _archivePrayerIntentHandler.HandleIntent(intentRequest, session, request).Result;
                        break;
                    case "ViewPrayerIntent":
                        response = _viewPrayerIntentHandler.HandleIntent(intentRequest, session, request).Result;
                        break;
                }
            }

            return response;
        }

    }
}