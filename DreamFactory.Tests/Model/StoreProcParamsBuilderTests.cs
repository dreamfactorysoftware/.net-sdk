namespace DreamFactory.Tests.Model
{
    using System;
    using System.Linq;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Database;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class StoreProcParamsBuilderTests
    {
        [TestMethod]
        public void ShouldBuildWithInParam()
        {
            // Arrange
            IStoreProcParamsBuilder builder = new StoreProcParamsBuilder();

            // Act
            builder.WithInParam("name", 123);

            // Assert
            StoredProcParam param = builder.Build().First();
            param.Name.ShouldBe("name");
            param.Type.ShouldBe("integer");
            param.ParamType.ShouldBe("IN");
            param.Value.ShouldBe("123");
        }

        [TestMethod]
        public void ShouldBuildWithInOutParam()
        {
            // Arrange
            IStoreProcParamsBuilder builder = new StoreProcParamsBuilder();

            // Act
            builder.WithInOutParam("name", "value", 100);

            // Assert
            StoredProcParam param = builder.Build().First();
            param.Name.ShouldBe("name");
            param.Type.ShouldBe("string");
            param.ParamType.ShouldBe("INOUT");
            param.Value.ShouldBe("value");
            param.Length.ShouldBe(100);
        }

        [TestMethod]
        public void ShouldBuildWithOutParam()
        {
            // Arrange
            IStoreProcParamsBuilder builder = new StoreProcParamsBuilder();

            // Act
            builder.WithOutParam<bool>("name", 100);

            // Assert
            StoredProcParam param = builder.Build().First();
            param.Name.ShouldBe("name");
            param.Type.ShouldBe("boolean");
            param.ParamType.ShouldBe("OUT");
            param.Value.ShouldBe(null);
            param.Length.ShouldBe(100);
        }

        [TestMethod]
        public void ShouldThrowIfNameIsNull()
        {
            // Arrange
            IStoreProcParamsBuilder builder = new StoreProcParamsBuilder();

            // Act & Assert
            Should.Throw<ArgumentNullException>(() => builder.WithOutParam<bool>(null, 100));
            Should.Throw<ArgumentNullException>(() => builder.WithInParam<bool>(null, true));
            Should.Throw<ArgumentNullException>(() => builder.WithInOutParam<bool>(null, true, 100));
        }
    }
}