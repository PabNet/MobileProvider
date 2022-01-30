using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MobileProviderSystem.Enums;

namespace MobileProviderSystem.AdditionalOptions
{
    public class SectionNames
    {
        public static Dictionary<SectionKeys, string> Sections { get; } = new Dictionary<SectionKeys, string>()
        {
            [SectionKeys.Files] = "Files",
            [SectionKeys.Data] = "Data",
            [SectionKeys.Description] = "Description",
            [SectionKeys.DataBases] = "DataBases",
            [SectionKeys.Connections] = "ConnectionStrings",
            [SectionKeys.LogFiles] = "Logs",
            [SectionKeys.DataBaseLogs] = "DataBases",
            [SectionKeys.MobileProviderDataBaseLog] = "MobileProviderDataBaseLogFile",
            [SectionKeys.MobileProviderDataBase] = "MobileProviderDataBase",
            [SectionKeys.Routes] = "Routes",
            [SectionKeys.ErrorRoute] = "Error",
            [SectionKeys.DefaultRoute] = "Default",
            [SectionKeys.AuthorizationRoute] = "Authorization"
        };
    }
}