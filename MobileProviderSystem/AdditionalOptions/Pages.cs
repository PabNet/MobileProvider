using System.Collections.Generic;
using MobileProviderSystem.Enums;

namespace MobileProviderSystem.AdditionalOptions
{
    public class Pages
    {
        public static Dictionary<PageKeys,string> Names = new Dictionary<PageKeys,string>
        {
            [PageKeys.SystemInformation] = "О проекте",
            [PageKeys.Contacts] = "Контакты",
            [PageKeys.PersonalArea] = "Личный кабинет"
        };
    }
}