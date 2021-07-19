using Autofac;
using MarsRoverPositioner.Data.DAL;
using MarsRoverPositioner.Business.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MarsRoverPositioner.Business.Services.Tests
{
    [TestClass()]
    public class NavigatorTests
    {
        private static IContainer container;
        private static INavigator navigatorService;

        [TestInitialize]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().As<IDataContext>();
            builder.RegisterType<Navigator>().As<INavigator>();
            builder.RegisterType<CommandRepository>().As<ICommandRepository>();
            container = builder.Build();

            navigatorService = container.Resolve<INavigator>();
            navigatorService.SetGrid(new Grid (5,5));
            navigatorService.SetRover(new Rover(0, 0, 'N'));
        }

        [TestMethod()]
        public void MoveRigthCommandTest()
        {
            navigatorService.SetCommand('R');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('E', navigatorService.LastLocation.Heading);

            navigatorService.SetCommand('R');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('S', navigatorService.LastLocation.Heading);

            navigatorService.SetCommand('R');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('W', navigatorService.LastLocation.Heading);

            navigatorService.SetCommand('R');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('N', navigatorService.LastLocation.Heading);
        }

        [TestMethod()]
        public void MoveLeftCommandTest()
        {
            navigatorService.SetCommand('L');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('W', navigatorService.LastLocation.Heading);

            navigatorService.SetCommand('L');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('S', navigatorService.LastLocation.Heading);

            navigatorService.SetCommand('L');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('E', navigatorService.LastLocation.Heading);

            navigatorService.SetCommand('L');
            navigatorService.ExecuteCommand();
            Assert.AreEqual('N', navigatorService.LastLocation.Heading);
        }

        [TestMethod()]
        public void MoveForwardToValidBoundaryTest()
        {
            navigatorService.SetCommand('M');
            navigatorService.ExecuteCommand();
            Assert.AreEqual(1, navigatorService.LastLocation.Y);
            Assert.AreEqual(0, navigatorService.LastLocation.X);

            navigatorService.SetCommand('R');
            navigatorService.ExecuteCommand();
            navigatorService.SetCommand('M');
            navigatorService.ExecuteCommand();
            Assert.AreEqual(1, navigatorService.LastLocation.Y);
            Assert.AreEqual(1, navigatorService.LastLocation.X);
        }

        [TestMethod()]
        public void MoveForwardToInvalidBoundaryTest()
        {
            navigatorService.SetCommand('L');
            navigatorService.ExecuteCommand();
            navigatorService.SetCommand('M');
            navigatorService.ExecuteCommand();
            Assert.AreEqual(0, navigatorService.LastLocation.Y);
            Assert.AreEqual(-1, navigatorService.LastLocation.X);
        }


        [TestCleanup]
        public void TearDown()
        {
            container.Dispose();
        }

    }
}