# E-CommerceAPI

<div align="center">
<img alt="BatuhanB" width="200" height="200" src="https://user-images.githubusercontent.com/56514839/200259435-347a3bdd-e062-4338-b2e3-21f86c547106.png"/>

<h3>What have been used for this project ?</h3>
 <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/>
 <img src="https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white"/>
</div>

## Project Architecture 
The E-Commerce API project will have multiple architectures. However, this is due to the fact that only Onion Architecture is currently being used at the beginning of the project.
### The Explanation of Onion Architecture 

<div>
<p>The onion architecture is a software design approach that organizes the code for a software application into layers, with the application's core business logic at the center and infrastructure code at the outer layers. The layers are organized in a way that resembles an onion, with the core business logic at the center and the infrastructure code at the outer layers.</p>

<div align= center>
<img src="https://user-images.githubusercontent.com/56514839/210178188-4fd82151-8744-445e-924e-b218561a17f3.png" width=400 height=350>
</div>

<ol>
<li><strong>Domain:</strong> This layer contains the core business logic of the application. It is the central layer of the onion architecture, and all other layers depend on it.</li>

<li><strong>Application:</strong> This layer contains the code that coordinates the different parts of the application. It provides a layer of abstraction between the domain layer and the infrastructure layer, and it is responsible for applying business rules and orchestrating the flow of data through the application.</li>

<li><strong>Infrastructure:</strong> This layer contains the code that interacts with the underlying infrastructure of the application, such as databases, file systems, and external APIs. It provides a layer of abstraction between the application layer and the infrastructure, and it is responsible for implementing the technical details of interacting with the underlying infrastructure.</li>

<li><strong>Persistence:</strong> This layer is responsible for storing and retrieving data from a persistent storage, such as a database. It provides a layer of abstraction between the application layer and the persistence layer, and it is responsible for implementing the technical details of interacting with the persistent storage.</li>

<li><strong>Presentation:</strong> This layer is responsible for presenting the data and functionality of the application to the user. It may consist of a web application, a mobile app, or other types of user interfaces. It depends on the application and infrastructure layers to provide the data and functionality it needs to display to the user.</li>

</ol>




</div>
