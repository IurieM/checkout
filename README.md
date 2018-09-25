Microservices Architecture based Online Store Application

## Running the applications
-in root folder run start-services.bat to start 
Identity.Api on http://localhost:5000 (Identity Provider Server - used to authenticate user and provide jwt token to access Catalog and Basket Api resources), 
Catalog.Api on http://localhost:5001 (Product Storage), 
Basket.Api on http://localhost:5002  (User Basket)
Web Spa on http://localhost:4200 (Client app built on angular)

Wait for all processes to start before testing. Usually Web spa will take longer time to start as need to install node modules.