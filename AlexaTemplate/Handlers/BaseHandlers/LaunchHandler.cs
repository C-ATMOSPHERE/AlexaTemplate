using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaTemplate.Helpers;
using AlexaTemplate.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaTemplate.Handlers.BaseHandlers
{
    class LaunchHandler : IRequestHandler
    {
        //This is not needed and can be left null on any non intent handlers
        public string Name => "LaunchHandler";

        public SkillResponse Run(Request pRequest)
        {
            return ResponseHelper.CreateTextResponse("Welcome to my Alexa Template", false);
        }
    }
}
