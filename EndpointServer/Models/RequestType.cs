using System;
namespace EndpointServer.Models
{
    public enum RequestType
    {
        GetStandardOAuth,
        GetSignupOAuth,
        RegisterNewUser,
        RegisterAnnoymousUser,
        ValidateConsistuency,
        GetEndpoint

    }
}
