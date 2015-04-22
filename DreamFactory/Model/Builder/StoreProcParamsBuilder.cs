namespace DreamFactory.Model.Builder
{
    using System;
    using System.Collections.Generic;
    using DreamFactory.Model.Database;

    /// <summary>
    /// Stored Proc (Func) parameters builder.
    /// </summary>
    public class StoreProcParamsBuilder : IStoreProcParamsBuilder
    {
        private readonly List<StoredProcParam> parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreProcParamsBuilder"/>.
        /// </summary>
        public StoreProcParamsBuilder()
        {
            parameters = new List<StoredProcParam>();
        }

        /// <inheritdoc />
        public IStoreProcParamsBuilder WithInParam<TParam>(string name, TParam value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            StoredProcParam parameter = new StoredProcParam
            {
                name = name,
                param_type = "IN",
                type = TypeMap.GetTypeName(typeof (TParam)),
                value = value.ToString(),
            };

            parameters.Add(parameter);

            return this;
        }

        /// <inheritdoc />
        public IStoreProcParamsBuilder WithInOutParam<TParam>(string name, TParam value = default(TParam), int? length = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            StoredProcParam parameter = new StoredProcParam
            {
                name = name,
                param_type = "INOUT",
                type = TypeMap.GetTypeName(typeof (TParam)),
                value = Equals(value, default(TParam)) ? null : value.ToString(),
                length = length
            };

            parameters.Add(parameter);

            return this;
        }

        /// <inheritdoc />
        public IStoreProcParamsBuilder WithOutParam<TParam>(string name, int? length = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            StoredProcParam parameter = new StoredProcParam
            {
                name = name,
                param_type = "OUT",
                type = TypeMap.GetTypeName(typeof(TParam)),
                length = length
            };

            parameters.Add(parameter);

            return this;
        }

        /// <inheritdoc />
        public IList<StoredProcParam> Build()
        {
            return parameters;
        }
    }
}