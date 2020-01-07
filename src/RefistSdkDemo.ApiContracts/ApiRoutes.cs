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
            public const string GetAll = Base + "/todos";
            public const string Get = Base + "/todos/{todoId}";
            public const string Create = Base + "/todos";
            public const string Update = Base + "/todos/{todoId}";
            public const string Delete = Base + "/todos/{todoId}";
        }
    }
}
