using System;
using System.Threading;
using System.Linq;
using Autofac;
using MarsRoverPositioner.Data.DAL;
using MarsRoverPositioner.Business.Services;
using MarsRoverPositioner.Business.Entities;

namespace MarsRoverPositioner
{
    /// <summary>
    /// Console application
    /// </summary>
    class Program
    {
        private static IContainer container;
        private static Grid grid;
        private static bool exitRequested = false;

        /// <summary>
        /// Main routine to perform Mars Rover positioning
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                //Register the services and implementations for DI mechaninsm
                var builder = new ContainerBuilder();
                builder.RegisterType<DataContext>().As<IDataContext>();
                builder.RegisterType<Navigator>().As<INavigator>();
                builder.RegisterType<Validator>().As<IValidator>();
                builder.RegisterType<CommandRepository>().As<ICommandRepository>();
                //Build the container of the services
                container = builder.Build();

                //Read the user inputs and start the execution of the program
                PerformTasks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General exception, the program will exit {ex.Message} ");
                Console.ReadKey();
            }

         }

        /// <summary>
        /// Get the definition of the grid and allows to position multiple rovers on mars.
        /// </summary>
        public static void PerformTasks()
        {
            var validatorService = container.Resolve<IValidator>();

            while (!exitRequested)
            {
                Console.WriteLine("Please enter X (East) boundary of the plateau (int. number)");
                var xBoundaryRaw = Console.ReadLine();                               

                Console.WriteLine("Please enter Y (North) boundary of the plateau (int. number)");
                var yBoundaryRaw = Console.ReadLine();

                if (!validatorService.IsValidBoundary(xBoundaryRaw) ||
                    !validatorService.IsValidBoundary(yBoundaryRaw))                
                {
                    Console.WriteLine("Invalid bonundaries please check and enter again");
                    continue;
                }

                var xBoundary = Convert.ToInt32(xBoundaryRaw);
                var yBoundary = Convert.ToInt32(yBoundaryRaw);
                grid = new Grid(xBoundary, yBoundary);

                //After having the definition of the grid ask to send the rovers one by one
                ProcessRovers();
            }

        }

        /// <summary>
        /// Position the rovers on mars and send back the position
        /// </summary>
        public static void ProcessRovers()
        {
            var validatorService = container.Resolve<IValidator>();

            while (!exitRequested)
            {
                Console.WriteLine("Please enter the initial X coordinate of the rover (int. number)");
                var x = Console.ReadLine();

                Console.WriteLine("Please enter the initial Y coordinate of the rover (int. number)");
                var y = Console.ReadLine();

                Console.WriteLine("Please initial heading of the rover (N,E,S,W)");
                var heading = Console.ReadLine();

                Console.WriteLine("Please enter the instruction set as not separated string R=Rotate Rigth, L=Rotate Left, M=MoveForward (ex. MMRMMRMRRM)");
                var instructionSet = Console.ReadLine();

                if (!validatorService.IsValidPosition(x, grid.XBoundary) ||
                    !validatorService.IsValidPosition(y, grid.YBoundary))
                {
                    Console.WriteLine("Invalid position please check and enter again");
                    continue;
                }

                if (!validatorService.IsValidHeading(heading))
                {
                    Console.WriteLine("Invalid heading please check and enter again");
                    continue;
                }

                if (!validatorService.IsValidInstructionSet(instructionSet))
                {
                    Console.WriteLine("Invalid instruction set please check and enter again");
                    continue;
                }

                var rover = new Rover(Convert.ToInt32(x), Convert.ToInt32(y), heading[0]);
                
                //Position a concrete rover using the instruction set
                SendRover(rover, instructionSet.ToCharArray());
            }
        }

        /// <summary>
        /// Position a concrete Rover on Mars
        /// </summary>
        /// <param name="rover">The rover</param>
        /// <param name="instructions">The array describing the instructions</param>
        public static void SendRover(Rover rover, char[] instructions)
        {
            var navigatorService = container.Resolve<INavigator>();

            navigatorService.ReInit();
            navigatorService.SetGrid(grid);
            navigatorService.SetRover(rover);

            foreach (var command in instructions)
            {
                navigatorService.SetCommand(command);
                navigatorService.ExecuteCommand();        
            }

            var summary = navigatorService.GetSummary();
            var text = string.Join("\n", summary);
            Console.WriteLine(text);

            Console.WriteLine(" -------------------------------------");
            Console.WriteLine("Last position of the rover will be returned to earth:");
            Console.WriteLine(navigatorService.LastLocation);
            Console.WriteLine(" -------------------------------------\n");

            Console.WriteLine(" Do you want to send another Rover? Y/N");
            var response = Console.ReadKey();

            switch (response.KeyChar)
            {
                case 'N':
                    Console.WriteLine("\nExit was requested");                    
                    exitRequested = true; 
                    Thread.Sleep(3000);
                    break;
                case 'Y':
                    Console.WriteLine("\nPreparing new rover to be sent...");
                    break;
                default:
                    Console.WriteLine("\nInvalid input the program will exit");
                    exitRequested = true;
                    Thread.Sleep(3000);
                    break;
            }
        }
    }
}
