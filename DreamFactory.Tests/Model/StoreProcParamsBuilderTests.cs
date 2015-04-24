namespace DreamFactory.Tests.Model
{
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
            param.name.ShouldBe("name");
            param.type.ShouldBe("integer");
            param.param_type.ShouldBe("IN");
            param.value.ShouldBe("123");
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
            param.name.ShouldBe("name");
            param.type.ShouldBe("string");
            param.param_type.ShouldBe("INOUT");
            param.value.ShouldBe("value");
            param.length.ShouldBe(100);
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
            param.name.ShouldBe("name");
            param.type.ShouldBe("boolean");
            param.param_type.ShouldBe("OUT");
            param.value.ShouldBe(null);
            param.length.ShouldBe(100);
        }
    }
}