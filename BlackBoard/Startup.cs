﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackBoard.Startup))]
namespace BlackBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); // from here you set the login and the registration 
        }
    }
}
