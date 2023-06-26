echo Get all owned cars for customer with id "1":
curl -X "GET" "http://localhost:5138/ClientAppService/FindAllOwnedCars/1" -H "accept: text/plain"

echo Get customer info with id "1":
curl -X "GET" "http://localhost:5138/ClientAppService/CustomerInfo/1" -H "accept: text/plain"

echo Get service info for carid 1:
curl -X "GET" "http://localhost:5138/ClientAppService/ServiceInfo/1" -H "accept: text/plain"

echo Get all services:
curl -X "GET" "http://localhost:5138/ClientAppService/ServiceInfo/AllService" -H "accept: text/plain"

echo Modify customer with id 100:
curl -X "POST" "http://localhost:5138/ClientAppService/ServiceInfo/ModifyCustomer?id=100&name=Name&address=Address&phone=Phone&email=Email" -H "accept: */*" -d ""

echo Get customer info with id "100":
curl -X "GET" "http://localhost:5138/ClientAppService/CustomerInfo/100" -H "accept: text/plain"

echo Modify customer with id 100:
curl -X "POST" "http://localhost:5138/ClientAppService/ServiceInfo/ModifyCustomer?id=100&name=Imie&address=Adres&phone=Telefon&email=Email" -H "accept: */*" -d ""

echo Get customer info with id "100":
curl -X "GET" "http://localhost:5138/ClientAppService/CustomerInfo/100" -H "accept: text/plain"
pause
