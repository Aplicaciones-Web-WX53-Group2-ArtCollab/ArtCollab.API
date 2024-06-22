namespace Shared;

public class TemplateWithTheSameTitleAlreadyExistException : Exception
{
    public TemplateWithTheSameTitleAlreadyExistException() : base("Template with the same title already exists.")
    {
    }
}