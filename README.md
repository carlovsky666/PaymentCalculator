# PaymentCalculator
The PaymentCalculator is a three layers aplication. From top to bottom:

Presentation Layer.- Composed by the clases that allow us to enter the data for processing, and after display the results.

Application Layer.- Composed by the clases that implements use cases logic and implements it at a higher level than the domain level.

Domain Layer.- Composed by the clases that model the domain with the inherent logic associated to this clases.

The complete solution implements patterns to favor high cohesion and low coupling, applying SOLID principles.

The solution was developed using TDD techniques, and the test classes are in the same location of each class.

The entry point is the Main method of the Program class.

When executing the application through the command line, the "Works.txt" file that contains the records to be processed must be passed as a parameter.
