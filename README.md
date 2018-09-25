Microservices Architecture based Online Store Application

## Prerequisite
Please make sure .net core sdk is installed

## Running the applications
- in root folder run start-services.bat to start 
- Identity.Api on http://localhost:5000 (Identity Provider Server - used to authenticate user and provide jwt token to access Catalog and Basket Api resources. For production usage, would change to use an OpenID Connect and OAuth 2.0 identity provider like IdentityServer4)
- Catalog.Api on http://localhost:5001 (Product Storage), 
- Basket.Api on http://localhost:5002  (User Basket)
- Web Spa on http://localhost:4200 (Client app built on angular)

Wait for all processes to start before testing. Usually Web spa will take longer time to start as need to install node modules.

Once all services are running, open http://localhost:4200 and start testing.

Available user credentials.
- Username:Bob Password:Bob
- Username:Ana Password:Ana
