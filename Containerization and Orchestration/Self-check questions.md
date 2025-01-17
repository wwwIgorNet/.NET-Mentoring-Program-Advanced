## 1. What is orchestration?
Orchestration in the context of containerization refers to the automated management, coordination, and arrangement of computer systems, applications, and services. As applications become more complex and are deployed across multiple containers and even multiple servers, managing all these components manually becomes increasingly inefficient and error-prone.
Orchestration tools help in: Container Management, Resource Allocation, Load Balancing, Health Monitorin, Configuration and Scheduling.

## 2. What is containerization and the pros and cons of using it?
Pros:
  Portability: Containers run consistently across different environments.
  Efficiency: Lighter and require less startup time than virtual machines.
  Scalability: Facilitates easy and quick scaling.
  Isolation: Improves security by isolating applications.
Cons:
  Security Risks: Shared OS kernel can pose vulnerabilities.
  Data Persistence: Challenges in managing persistent data.
  Complex Networking: Networking can be intricate in large-scale deployments.
  Monitoring Challenges: Ephemeral nature can complicate logging and monitoring.

## 3. What is the difference between containerization and virtualization?
Virtualization: Involves simulating hardware to run multiple virtual machines with full operating systems, leading to higher resource demands.
Containerization: Packages applications with their dependencies but shares the host's OS kernel, making it more lightweight and efficient than virtualization.

## 4. Explain the usage flow of Docker & Kubernetes.
Docker Usage Flow:
  Create Dockerfile: Script detailing how to build your Docker image, including dependencies and environment setup.
  Build Image: Use Docker commands to create an image from the Dockerfile.
  Run Container: Launch a container from the image for application execution.

## 5. What are the best practices for containerization?
  Use Minimal Base Images: Opt for smaller base images to reduce vulnerability and resource use.
  Treat Containers as Immutable: Always redeploy containers instead of updating them to maintain consistency.
  Keep Containers Stateless: Design containers without internal state, using external storage for data persistence.
  Single Responsibility: Each container should handle one task to simplify management and scaling.
  Implement Logging and Monitoring: Set up centralized logging and monitoring for efficient troubleshooting.
  Integrate with CI/CD: Automate container builds and deployments through a CI/CD pipeline.
  Use Version Control: Manage Dockerfiles and configuration files through version control systems.

## 6. How is Docker CI different from classic CI pipeline?
Docker CI integrates Docker into the continuous integration pipeline, distinguishing it from classic CI in several ways:
  Consistency: Docker ensures identical environments across development, testing, and production, reducing the "works on my machine" issue.
  Isolation: Each phase of the CI process can run in separate containers, minimizing dependency conflicts.
  Portability: Containers can easily move across different systems, simplifying deployments.
  Speed: Docker uses caching and layers, speeding up builds and deployments since only changed layers are processed.
In contrast, classic CI might face environment discrepancies, less isolation, and dependency on specific system configurations, potentially leading to compatibility issues.
