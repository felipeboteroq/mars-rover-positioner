using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using MarsRoverPositioner.Data.DAL;

namespace MarsRoverPositioner.Business.Services.Tests
{
    [TestClass()]
    public class ValidatorTests
    {

        private static IContainer container;
        private static IValidator validatorService;

        [TestInitialize]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().As<IDataContext>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<CommandRepository>().As<ICommandRepository>();
            container = builder.Build();
            validatorService = container.Resolve<IValidator>();
        }


        [TestMethod()]
        public void IsValidBoundaryTest()
        {
            Assert.AreEqual(false, validatorService.IsValidBoundary("-1"));
            Assert.AreEqual(true, validatorService.IsValidBoundary("5"));
        }

        [TestMethod()]
        public void IsValidPositionTest()
        {
            Assert.AreEqual(false, validatorService.IsValidPosition("-1", 5));
            Assert.AreEqual(false, validatorService.IsValidPosition("5", 5));
        }

        [TestMethod()]
        public void IsValidHeadingTest()
        {
            Assert.AreEqual(false, validatorService.IsValidHeading("H"));
            Assert.AreEqual(true, validatorService.IsValidHeading("N"));
            Assert.AreEqual(true, validatorService.IsValidHeading("E"));
            Assert.AreEqual(true, validatorService.IsValidHeading("S"));
            Assert.AreEqual(true, validatorService.IsValidHeading("W"));

        }

        [TestMethod()]
        public void IsValidInstructionSetTest()
        {
            Assert.AreEqual(true, validatorService.IsValidInstructionSet("RRMMLLRR"));
            Assert.AreEqual(false, validatorService.IsValidInstructionSet("RRMMLWK*-RR"));
        }
    }
}