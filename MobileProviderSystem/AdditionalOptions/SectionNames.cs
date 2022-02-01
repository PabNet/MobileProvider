using System.Collections.Generic;
using MobileProviderSystem.Enums;

namespace MobileProviderSystem.AdditionalOptions
{
    public class SectionNames
    {
        public static Dictionary<SectionKeys, string> Sections { get; } = new Dictionary<SectionKeys, string>()
        {
            [SectionKeys.DataBases] = "DataBases",
            [SectionKeys.Connections] = "ConnectionStrings",
            [SectionKeys.MobileProviderDataBase] = "MobileProviderDataBase",
            [SectionKeys.Routes] = "Routes",
            [SectionKeys.ErrorRoute] = "Error",
            [SectionKeys.DefaultRoute] = "Default",
            [SectionKeys.AuthorizationRoute] = "Authorization",
        };
    }
}