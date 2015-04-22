namespace DreamFactory.Model.Builder
{
    using System.Collections.Generic;
    using DreamFactory.Model.Database;

    /// <summary>
    /// Represents a builder of <see cref="StoredProcParam"/> array.
    /// </summary>
    public interface IStoreProcParamsBuilder
    {
        /// <summary>
        /// Adds IN parameter.
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="value">Value of the parameter.</param>
        /// <typeparam name="TParam">Type of the parameter.</typeparam>
        /// <returns>Interface chaining.</returns>
        IStoreProcParamsBuilder WithInParam<TParam>(string name, TParam value);

        /// <summary>
        /// Adds INOUT parameter.
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="value">Value of the parameter.</param>
        /// <param name="length">The requested length for the returned value.</param>
        /// <typeparam name="TParam">Type of the parameter.</typeparam>
        /// <returns>Interface chaining.</returns>
        IStoreProcParamsBuilder WithInOutParam<TParam>(string name, TParam value = default(TParam), int? length = null);

        /// <summary>
        /// Adds OUT parameter.
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="length">The requested length for the returned value.</param>
        /// <typeparam name="TParam">Type of the parameter.</typeparam>
        /// <returns>Interface chaining.</returns>
        IStoreProcParamsBuilder WithOutParam<TParam>(string name, int? length = null);

        /// <summary>
        /// Builds the array of <see cref="StoredProcParam"/>.
        /// </summary>
        /// <returns>Array of <see cref="StoredProcParam"/>.</returns>
        IList<StoredProcParam> Build();
    }
}