using System;
using System.Reflection;

namespace n01397767_Assignment2_WebApiMethods.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}