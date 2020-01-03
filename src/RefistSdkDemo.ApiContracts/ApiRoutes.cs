using System;
using System.Collections.Generic;
using System.Text;

namespace RefistSdkDemo.ApiContracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Todos
        {
            public const string GetAll = Base + "/todo";
            public const string Get = Base + "/todo/{todoId}";
            public const string Create = Base + "/todo";
            public const string Update = Base + "/todo/{todoId}";
            public const string Delete = Base + "/todo/{todoId}";
        }
    }
}
