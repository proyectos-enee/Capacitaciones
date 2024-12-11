// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Carter;
using Capacitaciones.Api.Controllers.Version.GetVersion;

namespace Capacitaciones.Api.Controllers.Version;

public class Endpoints : CarterModule
{
    public Endpoints() : base("/api/version")
    {
        this.WithTags("Version");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.GetVersion();
    }
}
