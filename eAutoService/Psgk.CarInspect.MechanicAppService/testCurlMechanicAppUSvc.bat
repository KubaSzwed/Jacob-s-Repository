echo Get all mechanics:
curl -X "GET" "http://localhost:5138/ClientAppService/DisplayMechanics" -H "accept: text/plain"

echo Get mechanic with name "John":
curl -X "GET" "http://localhost:5138/ClientAppService/FindMechanicByName/John" -H "accept: text/plain"

echo Get customer with id "1":
curl -X "GET" "http://localhost:5138/ClientAppService/CustomerInfo/1" -H "accept: text/plain"

echo Get cars with customer id "1":
curl -X "GET" "http://localhost:5138/ClientAppService/FindAllClientsCars/client/1" -H "accept: text/plain"

echo Get all services:
curl -X "GET" "http://localhost:5138/ClientAppService/ServiceInfo/All" -H "accept: text/plain"

echo Get service with id "1":
curl -X "GET" "http://localhost:5138/ClientAppService/ServiceInfo/1" -H "accept: text/plain"

echo Edit customer with id 99:
curl -X "POST" "http://localhost:5138/ClientAppService/EditCustomer?id=99&name=Name&address=Adress&phone=Phone&email=Email" -H "accept: */*" -d ""

echo Get customer with id "99":
curl -X "GET" "http://localhost:5138/ClientAppService/CustomerInfo/99" -H "accept: text/plain"

echo Edit customer with id 99:
curl -X "POST" "http://localhost:5138/ClientAppService/EditCustomer?id=99&name=Imie&address=Adres&phone=Telefon&email=Mail" -H "accept: */*" -d ""

echo Get customer with id "99":
curl -X "GET" "http://localhost:5138/ClientAppService/CustomerInfo/99" -H "accept: text/plain"
pause
