Self-check questions: 

1. Name examples of the layered architecture. Do they differ or just extend each other?
Two examples of layered architectures are the Model-View-Controller (MVC) and Model-View-ViewModel (MVVM) architectures.
MVC Architecture:

Model: Manages the data, logic, and rules of the application.
View: Represents the output or presentation layer, displaying data to the user.
Controller: Interprets user inputs and makes calls to model objects to retrieve data or affect changes.
MVVM Architecture:

Model: Similar to the MVC model, it deals with data and business logic.
View: Like MVC, it's concerned with displaying data to the user and has no knowledge of the model.
ViewModel: Acts as an intermediary between the View and the Model, handling data presentation and converting the model's data. It also manages the View's state and logic.


2. Is the below layered architecture correct and why? Is it possible from C to use B? from A to use C?

   In a typical layered architecture, layers are organized in a way that higher layers can use services provided by lower layers but not vice versa.
   From Layer C, it is not possible to directly use services from Layer B.
   From Layer A, it is not possible to directly use services from Layer C. However, Layer A can indirectly use services from Layer C through Layer B, which acts as an intermediary.

3. Is DDD a type of layered architecture? What is Anemic model? Is it really an antipattern?

    Domain-Driven Design (DDD) often employs a type of layered architecture. In typical DDD implementations, the code is organized into layers such as Presentation, Application, Domain, and Infrastructure, each having specific responsibilities.

4. What are architectural anti-patterns? Discuss at least three, think of any on your current or previous projects.

   Architectural anti-patterns are recurring poor practices or designs in software architecture that can hinder a system's performance, maintainability, scalability, and reliability.
    1. Spaghetti Architecture: This anti-pattern is characterized by a lack of structure and planning, where components and services are haphazardly interconnected without a clear, logical organization. This can make the system difficult to understand, maintain, and extend.
    2. Reinventing the Wheel: This anti-pattern involves developing custom solutions for problems that already have well-established and tested solutions.
    3. The Blob (or God Object): This anti-pattern involves placing most of the system's functionality into a single class or component, resulting in an overly complex, unmanageable monolith. It becomes a bottleneck for maintenance and evolution as changes in one part of the Blob can affect the entire component.

5. What do Testability, Extensibility and Scalability NFRs mean. How would you ensure you reached them? Does Clean Architecture cover these NFRs?

   Testability, Extensibility, and Scalability are non-functional requirements (NFRs) that contribute to the overall quality of a software system.
   1. Testability: Refers to how easily a software system can be tested.
   2. Extensibility: Refers to how easily new features or functionalities can be added to the software without affecting its existing behavior. It is a key factor in allowing software to evolve and adapt to new requirements.
   3. Scalability: Refers to the ability of a software system to handle increased loads or to be enlarged to accommodate that growth. It can be related to the number of users, amount of data processed, or the computational power required.
   
