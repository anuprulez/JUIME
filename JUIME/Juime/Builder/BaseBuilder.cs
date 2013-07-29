
namespace Juime.Builder
{
    /// <summary>
    /// Base class for all the builder objects
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    public abstract class BaseBuilder<TBuilder> where TBuilder : BaseBuilder<TBuilder>
    {

    }
}
