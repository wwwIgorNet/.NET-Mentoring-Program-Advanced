## 1. 
### What is Message Based Architecture?
Message-based architecture is a software design pattern where components within a system communicate with each other using asynchronous messages rather than direct method calls. This approach allows for loose coupling between components, enabling them to operate independently and improving system scalability and resilience.

### What is the difference between Message Based Architecture and Event Based Architecture?
Message-based architecture and event-based architecture are two ways components in a system can communicate, but they're a bit different.
Message-Based Architecture: Different parts send messages to each other, often expecting replies. They need to know what kind of messages to send and receive.
Event-Based Architecture: This is more about broadcasting important changes or events in the system. Other parts listen and react to these events without directly sending a response back.
So, message-based is like having a conversation, while event-based is like announcing something to a room and seeing who reacts.

## 2. What is Message Broker? How do message brokers work?
A message broker is a tool that helps different computer programs talk to each other by sending messages. Here's how it works:
Routing: The message broker gets messages from a sender and sends them to the right receiver based on some rules.
Queuing: It holds messages in a line (queue) until the receiver is ready to handle them. This way, no messages are lost if the receiver is busy.
Delivery: When the receiver is ready, the message broker sends the message.

## 3. When should you use message brokers?
Decoupling Services: When you have multiple services that need to communicate but you want to keep them independent of each other.
Asynchronous Communication: If your system components need to communicate without waiting for responses immediately (non-blocking).
Scalability: When your application needs to handle growth in data or user numbers, message brokers can manage increased loads by queueing messages and processing them efficiently.
Reliability: In cases where your application needs to ensure messages are not lost even if parts of your system fail, message brokers can ensure messages are safely stored and delivered when systems recover.
Handling Spikes in Traffic: If your application experiences variable traffic, message brokers can help absorb spikes by queueing incoming messages, allowing your application to process them at a manageable rate.

## 4. Name and describe any distribution pattern.
Common distribution pattern is the Publish-Subscribe (Pub-Sub) Pattern.
In the Publish-Subscribe model, messages are published by producers (or publishers) without the knowledge of which systems (or subscribers) will consume them. This model is managed typically by a message broker that handles the distribution of messages.

## 5. What are the advantages and disadvantages of using message broker?
### Advantages:
Decoupling: The sender and receiver of messages don’t need to know about each other, which simplifies system maintenance and scalability.
Reliability: Message brokers can store messages and retry sending them until the receiving service is available.
Flexibility: Systems can easily subscribe or unsubscribe to message channels/topics.
Asynchronous Communication: Producers of the data do not need to wait for consumers to process messages.
Scalability: It is easier to scale applications horizontally by adding more producers or consumers without significant changes to the application logic.

## 6. What is the difference between Queue and Topic?
### Queue:
Point-to-Point Communication: Messages sent to a queue are consumed by only one recipient.
Delivery Guarantee: This means that no matter how many consumers are subscribed to the queue, each message is guaranteed to be delivered, and processed once and only once.
Use Case: Queues are ideal for tasks that require guaranteed delivery to only one recipient, such as order processing or job scheduling.
### Topic:
Publish-Subscribe Communication: When a message is sent to a topic, it can be consumed by multiple subscribers.
Scalability for Broadcast: Making it scalable for scenarios where messages need to be consumed by many subscribers.
Use Case: Topics are used for broadcasting updates or events, such as price changes in stock markets.

## 7. What are the typical failures in MBA? How can you address them? What is Saga pattern?
Failed Return Result: When a system processes a request but returns an error because it can't fulfill the request (e.g., a credit card is declined). This requires a process to detect and handle the error.
Remote Service Down: If a linked service is out of operation, requests sent to it get stuck in a queue, potentially overloading the queuing mechanism.
Event Routing Fails: Misalignment between an event and its intended process can cause events to never be picked up by the correct system, resulting in no response.
Event-Handling System Down: A failure in the message queuing system prevents messages from being passed along, even if the sender and receiver are functioning correctly.
### Ways to Address These Failures:
Dead Letter Queues: Utilize dead letter queues to store messages that were never processed. Periodically review this queue to resolve issues and potentially notify senders of failures.
Saga Pattern: Implement the Saga pattern with a controller mechanism that manages events and ensures proper communication between services. This pattern is useful for rolling back changes if part of a transaction fails.
Logs and Alerts: Set up logs and alarms for system failures. These should provide enough context for system administrators to debug and fix issues effectively.
### What is Saga pattern?
The Saga pattern is an architectural design approach used to manage long-running, distributed business processes or transactions, particularly in microservices architectures where data consistency must be maintained across multiple services.
