## 1.Which NFRs are affected by the code quality? What are the code quality metrics?
### Non-Functional Requirements (NFRs) influenced by code quality include:
Maintainability: Code quality affects how easily software can be modified or extended.
Reliability: Higher code quality reduces defects and errors.
Efficiency: Quality code often leads to better performance and resource use.
Portability: Well-crafted code adapts more easily to different environments.
Usability: Indirectly impacted through reliability and efficiency, influencing user satisfaction.
Scalability: Quality code supports scaling the software with minimal issues.
### Code Quality Metrics consist of:
Cyclomatic Complexity: Counts the number of linearly independent paths through a program.
Lines of Code (LOC): Tallies the number of lines written.
Code Coverage: Measures the percentage of code tested to ensure reliability.
Technical Debt: Extra development work caused by short-term solutions.
Duplication: Tracks repeated code, which can complicate maintenance.
Code Churn: Measures how often code is modified, indicating potential instability.
Code Smells: Identifies parts of the code that may indicate deeper problems.
Bug Rate: Counts bugs per line of code or module to assess stability.

## 2. What are the goals of static code analysis? How many code analyzers can be used on a project?
### Static code analysis aims to:
Detect Bugs Early: Catch errors before production.
Improve Code Quality: Ensure adherence to standards.
Reduce Technical Debt: Identify and address complex or poor code.
Enhance Security: Spot potential security vulnerabilities.
Ensure Compliance: Meet industry or regulatory standards.
Optimize Performance: Find and fix inefficient code patterns.
Educate Developers: Provide feedback for better coding practices.
### There's no set limit on how many code analyzers can be used on a project.

## 3. How to ensure every team member will follow a style guide? How to apply style guide for the legacy projects?
### To ensure every team member follows a style guide:
Document the Style Guide: Clearly document and make the style guide easily accessible to all team members.
Integrate into Development Tools: Utilize linters and formatters that automatically apply the style guide rules in development environments and IDEs.
Code Reviews: Include style adherence in code review processes.
Automate: Set up continuous integration to check and enforce style compliance automatically.
### For applying a style guide to legacy projects:
Incremental Approach: Apply the style guide to new or modified code first, gradually refactoring older code.
Focus on Key Areas: Start with the most frequently modified or critical parts of the code.
Automation: Utilize tools for automatic code formatting and linting across the project.

## 4. Which are the pros and cons of the SonarQube analyzer?
### Pros of SonarQube:
Comprehensive Analysis: Detects bugs, vulnerabilities, and code smells.
Customizable Rules.
Integration: Compatible with CI/CD pipelines and development environments.
Multi-Language Support.
Quality Gates: Set thresholds for passing code quality checks.
### Cons of SonarQube:
Performance Impact: Can be slow on large codebases.
Complex Setup: Configuration can be intricate and time-consuming.
Cost: Free version available but larger setups may require costly licenses.

## 5. What are the quality gates?
Quality Gates are predefined criteria that code must meet to progress through stages of software development, ensuring only high-quality code is deployed. They are typically part of CI/CD pipelines and automatically evaluate code against metrics like coverage, complexity, and adherence to standards.
