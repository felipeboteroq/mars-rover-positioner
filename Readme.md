### **Welcome to the Mars Rover Positioner project**

The main goal of the aplication is to position a Rover in Mars after landing by sending the descripion of the landing zone, initial position and set of instructions describing the movements. Please check the definition of the challenge for more detail.

### **Architecture**

The solution has 3 main layers:

- Presentation: Console interface that captures inputs and show results (MarsRoverPositioner).
- Bussiness: Main logic to perform the actions (MarsRoverPositioner.Business).
- Data Access: Stores the operations performed to retrieve them and be shown to the user at the end of each operation (MarsRoverPositioner.Data).

The application is built using services resolved using dependency injection to implement IoC. This way separation of concerns, single responsibility and testeability are achieved.

- NavigationService: Moves the rover along the grid. Follows the Command pattern to execute instructions defined by the instruction set. The command derived classes are resolved using the Factory Method pattern.
- ValidationService: Performs input validations.

The data is temporarily perisisted using the repository patern.  

Only tests for the to services were implemented in MarsRoverPositioner.Bussiness.Tests because of time restrictions.

### **Assumptions:**

- The commands different from R, L and M are invalid and will be just ignored.
- The user already knows that only possitive values > 1 can be used as boundaries for the grid
- The user already knows that the possitions in the grid have integer values
- The user already knows that the only valid heading values are N, E, S and W.
- If a movement goes outside of the boundaries it will be executed but a warning message must be shown.
- Two rovers can be in the same location at the same time because they have a special coupling system, the route taken by one rover will not affect others' route.
- The user knows that only valid options are Y/N when asked if he wants to send another Rover.
- The user knows that the set of instrucctions cannot be empty.
- The rover's initial position must always fall inside the grid boundaries

### **Usage:**
Clone the repository and open mars-rover-positioner\MarsRoverPositioner.sln solution using VS2019