## 1. What are the cons and pros of the Monolith architectural style?
### Pros of Monolithic Architecture:
Simplicity: A monolithic application is a single and it easier to test, deploy.
Performance: Since components are tightly integrated and run in the same process, there are no inter-process communication delays.
Easier to implement logging, rate limiting, and security features since all components are managed within the same application.
Easier to start new project.

### Cons of Monolithic Architecture:
Scalability: Scaling a monolithic application can be challenging.
Reliability: If one component of the application fails, it can potentially bring down the entire application.
Technology Stack Dependency: It's often locked to a specific technology stack, which can make it difficult to adopt new technologies or frameworks.
Development Constraints: Large monolithic applications can become complex and difficult to understand, making the development process slower as the application grows.
Code Entanglement: As the codebase grows, different modules can become tightly coupled, making it difficult to make changes without affecting other parts of the system.

## 2. What are the cons and pros of the Microservices architectural style?
### Pros of Microservices:
Scalability: Each microservice can be scaled independently based on demand for the specific service.
Microservices promote the use of small, autonomous teams, which can develop, deploy, and scale their respective services independently.
Resilience: Failure in one microservice does not necessarily impact the availability of other services.
Microservices encourage teams to work on different functionalities simultaneously without waiting for changes in other parts of the system.
Better Modularity: Microservices allow splitting software applications into manageable, logical components that can be maintained more easily.
Technology Diversity: Each microservice can potentially be built using different technological stacks best suited for the service's specific requirements.

### Cons of Microservices:
Complexity: Managing and orchestrating microservices can be complex, particularly when it comes to handling interservice communication, data consistency, and fault tolerance.
Deployment Overhead: Handling multiple deployment pipelines and continuous delivery processes for each microservice can be challenging.
Monitoring and Logging: Collecting logs and monitoring different services distributed across the network is more intricate than in a monolithic architecture.
Increased Network Latency: Communication between microservices over a network can add latency.
Data Management: Data consistency and management become challenging as data might be distributed across various databases belonging to different microservices.

## 3. What is the difference between SOA and Microservices?
Both architectural styles that are used to design and build software applications as a collection of services.

Scope: SOA is typically used for integrating various large and complex enterprise systems, while Microservices are used to develop individual and independently deployable services.
Communication: SOA services often communicate with each other through an Enterprise Service Bus (ESB) which can add complexity, while Microservices communicate directly using lightweight protocols such as HTTP/REST or message queues.
Granularity: SOA services are usually encompass broader business functionalities. In contrast, Microservices are finer-grained and focus on specific, smaller functionalities.
Deployment: In SOA, services are usually deployed as a monolith, whereas Microservices are deployed independently, allowing for easier scaling, updates, and maintenance.
Technology: SOA often enforces the use of specific enterprise standards, while Microservices allow for using different technologies and programming languages best suited for specific services.
Microservices offer a more flexible, scalable, and resilient approach, making it popular for modern cloud-based applications.

## 4. What does hybrid architectural style mean? Think of your current and previous projects and try to describe which architectural styles they most likely followed.
Hybrid architectural style in the context of software architecture refers to the combination of two or more distinct architectural styles to leverage the benefits of each.
In describing past projects, one might recognize a project that primarily followed a monolithic architecture, where the application was built as a single and indivisible unit, often leading to challenges with scalability and maintainability as the application grew. Another project may have implemented a service-oriented architecture (SOA), focusing on providing services across different platforms and allowing for interoperability, which would be crucial for enterprise-level applications that require integration of diverse software systems.

## 5. Name several examples of the distributed architectures. What do ACID and BASE terms mean.
Distributed architectures are systems in which components are located on different networked computers and communicate by passing messages. Examples include:
client-server, service-oriented (SOA), microservices, serverless.

ACID and BASE are terms related to transaction processing systems. ACID stands for Atomicity, Consistency, Isolation, and Durability. These properties ensure that database transactions are processed reliably even in the event of failure:

Atomicity ensures that a transaction is fully completed or not at all.
Consistency ensures that a transaction brings the database from one valid state to another.
Isolation ensures that concurrent transactions do not interfere with each other.
Durability ensures that once a transaction is committed, it will not be lost.

BASE stands for Basically Available, Soft state, and Eventual consistency. It is a more relaxed approach compared to ACID properties and is often used in distributed systems where high availability and scalability are prioritized:
Basically Available indicates that the system is available, but there might be some latency.
Soft state means that the state of the system could change over time, even without input.
Eventual consistency means that the system will become consistent over time but does not guarantee immediate consistency after a transaction.

## 6. Name several use cases where Serverless architecture would be beneficial.
Allow developers to quickly create and scale APIs without the need to manage server infrastructure.
Event-driven applications: Serverless architecture is well-suited for applications that respond to events or triggers.
Microservices: Serverless architecture facilitates the development and deployment of microservices by allowing each service to independently scale and operate without the need for server management.
Automation and orchestration: as sending automated emails or processing files.
Data processing: Serverless architecture is efficient for data processing tasks, such as image or video processing, data transformation, and batch processing jobs.
