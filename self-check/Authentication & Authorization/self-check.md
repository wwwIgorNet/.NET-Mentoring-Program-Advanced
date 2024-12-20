## 1. What is the difference between authentication and authorization?
### Authentication: 
This is the process of verifying the identity of a user, device, or entity.
### Authorization: 
Once a user's identity is authenticated, authorization is the process that determines what resources a user can access and what they can do with those resources.

## 2. What authorization approaches can you list? What is role-based access control?
### Role-Based Access Control (RBAC): 
Each role has specific permissions associated with it, and when a user is assigned a role, they inherit those permissions.
### Claims-Based Authorization: 
A claim is a statement about a user (like name, age, or role), and claims are issued by a trusted authority. The application then uses these claims to decide access levels.
### Policy-Based Authorization: 
Policies are defined in terms of requirements that specify what conditions must be met for access to be granted. For example, a policy might require that a user must have a certain claim and must also satisfy a certain condition (like being over a certain age).
### Resource-Based Authorization: 
Authorization decisions depend on the specific resource being accessed. For example, a user may be allowed to view a document if they created it or if they are a part of a group that has access to it

## 3. What exactly is Identity Management (Identity and Access Management)?
Identity Management, often referred to as Identity and Access Management (IAM), is a framework of policies and technologies ensuring that the right individuals have the appropriate access to technology resources. IAM systems are designed to manage identities (user profiles), their authentication, authorization, roles

## 4. What authentication/authorization protocols do you know? What is the difference between OAuth & OpenID?
### OAuth 2.0: 
This is an authorization framework that allows third-party services to exchange web resources on behalf of a user. It's commonly used to allow users to authorize third-party applications to access their server resources without exposing their credentials.
### OpenID Connect (OIDC): 
This is a simple identity layer on top of the OAuth 2.0 protocol. It allows clients to verify the identity of the end-user based on the authentication performed by an authorization server, as well as to obtain basic profile information about the end-user in an interoperable and REST-like manner.
### SAML (Security Assertion Markup Language): 
This is an XML-based framework for authentication and authorization between two entities: a Service Provider and an Identity Provider. It's commonly used for enterprise-level single sign-on (SSO).
### JWT (JSON Web Tokens): 
JWT is a compact, URL-safe means of representing claims to be transferred between two parties. It can be used in OAuth 2.0 and OpenID Connect protocols to pass the authenticated user identity from the identity provider to the application.

## 5. What is Authentication/Authorization Token. What is JWT token? What other approaches except authentication/authorization, can we use with security token?
### An Authentication/Authorization Token 
is a security token that a server generates to indicate that a user or client application has successfully authenticated. Tokens often contain metadata or claims about the user and serve as credentials to access specific resources.
### JWT (JSON Web Token) 
is a type of token that encapsulates information about a user in a JSON format. JWTs are compact, URL-safe, and can be passed in HTTP headers, URL parameters, or HTTP bodies. They typically consist of three parts: a header, a payload, and a signature.
### Beyond authentication and authorization, security tokens like JWT can be used for:
JWTs can securely transfer information between parties.
JWTs are often used in single sign-on (SSO) solutions because they enable the client to use the same authentication credentials across multiple independent applications or services.
Session Management: Although session management traditionally relies on session cookies, JWTs provide a stateless way to manage sessions.
JWTs can be used to grant temporary access to certain resources. 

## 6. What is Single Sign-On (SSO)? Name the steps to implement SSO. What are the benefits of SSO?
Single Sign-On (SSO) is an authentication process that allows a user to access multiple applications with one set of login credentials (such as username and password). 
### Steps to Implement SSO
Begin by identifying which applications and services should be included in the SSO implementation.
Choose an appropriate SSO protocol that meets your needs. Common choices include SAML (Security Assertion Markup Language), OAuth2.0, and OpenID Connect.
Choose an Identity Provider (IdP)
Modify each application (service provider) to delegate authentication requests to the IdP.
Configure SSO on Each Service
### Benefits of SSO
Reduces the number of times users need to log in to access multiple applications.
Users spend less time managing multiple sets of credentials.
Reduces the likelihood of password fatigue (the tendency to reuse passwords across many sites), which can weaken security.
Easier for the IT department to manage and monitor user accesses and permissions across multiple services from a single point.

## 7. What is the difference between Two-Factor Authentication and Multi-Factor Authentication?
### Two-Factor Authentication (2FA)
Something you know: This could be a password, PIN, or another piece of personal knowledge.
Something you have: This generally involves something like a mobile device, a security token, or a smart card.
Something you are: This involves biometrics such as fingerprints, facial recognition, or iris scans.
### Multi-Factor Authentication (MFA)
MFA extends 2FA by requiring two or more verification factors, which enhances security further. 

## 8. Which of the OAuth flows can be used for user (customer) and which for client (server) authentication?
### Flows for User (Customer) Authentication:
Authorization Code Flow: The user authenticates and authorizes the application, which then receives an authorization code. This code is exchanged for an access token from the authorization server.
Implicit Flow: Previously recommended for clients without a server component (like some JavaScript-based applications), where the application can't securely store a secret because the application and its storage can be easily accessed.
Authorization Code Flow with PKCE (Proof Key for Code Exchange): This is an enhancement of the Authorization Code Flow designed for applications that cannot securely store the client secret, such as native mobile apps and single-page applications (SPAs).
### Flows for Client (Server) Authentication:
Client Credentials Flow: This is used when the authentication is completely client-based and does not involve user interaction. Typical scenarios include machine-to-machine (M2M) communication where a client needs to access server resources. Here, the client authenticates with its client ID and secret to receive an access token directly.
