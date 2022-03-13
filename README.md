<h1>Microservice architecture project</h1>
Technologies:
<br>
- .NET 5<br>
- ASP .NET<br>
- Entity Framework Core<br>
- InMemory database<br>
- Ocelot<br>
- AutoMapper<br>
- MediatR<br>
- CQRS<br>
<h2>Short description</h2>
<h3>Implemented 2 microservies:</h3>
1)The first microservice: Brands<br>
Architecture: Onion <br>
4 layers: Domain -> Persistance -> Application -> Presentation
<br>
<br>
2)The second microservice: Product<br>
Architecture: 3-layer with anemic model <br>
3 layers: data layer -> business layer -> presentation layer <br>
<br>
Implemented API  Gateway using ocelot. <br>
<br>
Things to do:<br>
- Unit testing <br>
- Login service <br>
- Docker support <br>
- Documentation
