namespace Library.BusinessLogic.Exceptions;

public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="NotFoundException"/>
    /// </summary>
    public NotFoundException()
    {
        
    }
    
    /// <summary>
    /// Initializes a new instance of <see cref="NotFoundException"/>
    /// </summary>
    /// <param name="message">The message</param>
    public NotFoundException(string message) : base(message)
    {
        
    }
    
    /// <summary>
    /// Initializes a new instance of <see cref="NotFoundException"/>
    /// </summary>
    /// <param name="message">The message</param>
    /// <param name="ex">The excetpion</param>
    public NotFoundException(string message, Exception ex) : base(message, ex)
    {
        
    }
}