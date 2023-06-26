echo Get all cars:
curl -X "GET" "https://localhost:7100/Car/GetCars" -H "accept: text/plain"

echo Car with registration number WN2222:
curl -X "GET" "https://localhost:7100/Car/FindCarByRegistrationNumber/WN2222" -H "accept: text/plain"

echo Car with brand Opel:
curl -X "GET" "https://localhost:7100/Car/FindCarByBrand/Opel" -H "accept: text/plain"

echo Car with model E36:
curl -X "GET" "https://localhost:7100/Car/FindCarByModel/E36" -H "accept: text/plain"

echo Adding car Opel Vectra:
curl -X "POST" "https://localhost:7100/Car/AddCar/9/Opel%20/Vectra/WN1234" -H "accept: */*" -d ''

echo Checking if Opel Vectra was added:
curl -X "GET" "https://localhost:7100/Car/GetCars" -H "accept: text/plain"

echo Deleting car with registration number WN1234:
curl -X "POST" "https://localhost:7100/Car/DeleteCar/WN1234" -H "accept: */*" -d ''

echo Checking if car with registration number WN1234 was deleted :
curl -X "GET" "https://localhost:7100/Car/GetCars" -H "accept: text/plain"

pause