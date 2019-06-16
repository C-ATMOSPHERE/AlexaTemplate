using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaTemplate.Interface
{
    public interface IRequestHandler
    {
        string Name { get; }
        SkillResponse Run(Request pRequest);
    }
}
