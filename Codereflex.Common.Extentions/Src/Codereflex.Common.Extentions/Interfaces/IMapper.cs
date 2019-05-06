namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Defines  Mapper
    /// </summary>
    public interface IMapper<TMap>
    {
        /// <summary>
        /// Returns  token which matches  <paramref name="path"/> expression
        /// </summary>
        /// <param name="path">json path expression</param>
        /// <returns></returns>
        IToken<IMapper<TMap>> From(TMap path);

    }
}