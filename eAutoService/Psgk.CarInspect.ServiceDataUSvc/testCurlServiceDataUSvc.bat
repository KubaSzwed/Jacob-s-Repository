echo Get all services:
curl -X "GET" "https://localhost:7098/Service/GetAllServices" -H "accept: text/plain"

echo Service with id number 1:
curl -X "GET" "https://localhost:7098/Service/GetServiceById/1" -H "accept: text/plain"

echo Service with id number 2:
curl -X "GET" "https://localhost:7098/Service/GetServiceById/2" -H "accept: text/plain"

echo Adding service(id=99; name=OilChange; price=2138; carid = [0,2,3]):
curl -X "POST" "https://localhost:7098/Service/AddService?Id=99&Name=OilChange&Price=2138" -H "accept: */*" -H "Content-Type: application/json" -d "[0,2,3]"

echo Get all services:
curl -X "GET" "https://localhost:7098/Service/GetAllServices" -H "accept: text/plain"

echo Delete service with id 99:
curl -X "POST" "https://localhost:7098/Service/DeleteService/99" -H "accept: */*" -d ""

echo Get all services:
curl -X "GET" "https://localhost:7098/Service/GetAllServices" -H "accept: text/plain"
pause
