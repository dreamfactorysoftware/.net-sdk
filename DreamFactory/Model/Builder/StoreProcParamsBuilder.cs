namespace DreamFactory.Model.Builder
{
    using DreamFactory.Model.Database;
    using global::System;
    using global::System.Collections.Generic;

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
                Name = name,
                ParamType = "IN",
                Type = TypeMap.GetTypeName(typeof (TParam)),
                Value = value.ToString(),
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
                Name = name,
                ParamType = "INOUT",
                Type = TypeMap.GetTypeName(typeof (TParam)),
                Value = Equals(value, default(TParam)) ? null : value.ToString(),
                Length = length
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
                Name = name,
                ParamType = "OUT",
                Type = TypeMap.GetTypeName(typeof(TParam)),
                Length = length
            };

            parameters.Add(parameter);

            return this;
        }

        /// <inheritdoc />
        public StoredProcParam[] Build()
        {
            return parameters.ToArray();
        }
    }
}